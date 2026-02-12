using Application.Contracts.Account;
using Application.DTOs.Request.Account;
using Application.DTOs.Response;
using Application.DTOs.Response.Account;
using Domain.Entity.Authentication;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Mapster;

namespace Infrastructure.Repository
{
    public class AccountRepository(
       RoleManager<IdentityRole> roleManager,
       UserManager<ApplicationUser> userManager,
       IConfiguration config,
       SignInManager<ApplicationUser> signInManager,
       AppDbContext context
       ) : IAccount
    {
        private async Task<ApplicationUser?> GetUserByEmailAsync(string email)
        {
            return await userManager.FindByEmailAsync(email);
        }

        private async Task<IdentityRole?> GetRoleByNameAsync(string roleName)
        {
            return await roleManager.FindByNameAsync(roleName);
        }

        private static string GenerateRefreshToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
        }

        public async Task<GenericResponse> LoginAccountAsync(LoginDTO model)
        {
            // Busca el usuario por email
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return new GenericResponse(false, "Usuario o contraseña inválidos");

            // Verifica la contraseña
            var checkPassword = await userManager.CheckPasswordAsync(user, model.Password);
            if (!checkPassword)
                return new GenericResponse(false, "Usuario o contraseña inválidos");

            return new GenericResponse(true, "Login exitoso (Token pendiente)");
        }

        private async Task<string> GenerateToken(ApplicationUser user)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var userClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName ?? "Unknown"),
                    new Claim(ClaimTypes.Email, user.Email ?? "Unknown"),
                    new Claim("FullName", user.Name ?? "Unknown"),
                    new Claim(ClaimTypes.NameIdentifier, user.Id)
                };

                var roles = await userManager.GetRolesAsync(user);
                foreach (var role in roles)
                {
                    userClaims.Add(new Claim(ClaimTypes.Role, role));
                }

                var token = new JwtSecurityToken(
                    issuer: config["Jwt:Issuer"],
                    audience: config["Jwt:Audience"],
                    claims: userClaims,
                    expires: DateTime.UtcNow.AddMinutes(60),
                    signingCredentials: credentials
                );
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                throw new Exception("Error generating token", ex);
            }
        }


        private async Task<GenericResponse> AssignUserToRole(ApplicationUser applicationUser, IdentityRole identityRole)
        {
            if (applicationUser == null || identityRole == null)
            {
                return new GenericResponse(false, "Model state cannot be empty");
            }

            if (await GetRoleByNameAsync(identityRole.Name!) == null)
            {
                await CreateRoleAsync(new CreateRolDTO { Name = identityRole.Name! });
            }

            IdentityResult result = await userManager.AddToRoleAsync(applicationUser, identityRole.Name!);

            string error = CheckResponse(result);
            if (!string.IsNullOrEmpty(error))
            {
                return new GenericResponse(false, error);
            }

            return new GenericResponse(true, $"{applicationUser.Name} assigned to {identityRole.Name} role.");
        }

        private static string CheckResponse(IdentityResult result)
        {
            if (!result.Succeeded)
            {
                var errores = result.Errors.Select(e => e.Description);
                return string.Join(Environment.NewLine, errores);
            }
            return null!;
        }


        public async Task<GenericResponse> ChangeUserRole(ChangeUserRoleRequestDTO model)
        {
            if (await GetRoleByNameAsync(model.NewRole) is null)
                return new GenericResponse(false, "Role does not exist");

            var user = await GetUserByEmailAsync(model.Email);
            if (user == null)
                return new GenericResponse(false, "User does not exist");

            var previousRoles = await userManager.GetRolesAsync(user);
            if (previousRoles.Any())
            {
                var removeOldRole = await userManager.RemoveFromRolesAsync(user, previousRoles);
                var errorRemove = CheckResponse(removeOldRole);
                if (!string.IsNullOrEmpty(errorRemove)) return new GenericResponse(false, errorRemove);
            }

            var result = await userManager.AddToRoleAsync(user, model.NewRole);
            var response = CheckResponse(result);

            if (!string.IsNullOrEmpty(response))
                return new GenericResponse(false, response);

            return new GenericResponse(true, $"User {user!.Email} role changed to {model.NewRole} successfully.");
        }

        public async Task<GenericResponse> CreateAccountAsync(CreateAccountDTO model)
        {
            try
            {
                if (await GetUserByEmailAsync(model.Email) is not null)
                    return new GenericResponse(false, "User with this email already exists.");

                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Name = model.Name
                };

                var result = await userManager.CreateAsync(user, model.Password);
                string error = CheckResponse(result);

                if (!string.IsNullOrEmpty(error)) return new GenericResponse(false, error);

                var assignRole = await AssignUserToRole(user, new IdentityRole() { Name = model.Role });

                // Corrección: Usar el resultado de assignRole directamente
                return new GenericResponse(assignRole.Flag, assignRole.Message);
            }
            catch (Exception ex)
            {
                return new GenericResponse(false, ex.Message);
            }
        }

        public async Task<GenericResponse> CreateAdmin() 
        {
            try
            {
                if ((await GetRoleByNameAsync("Admin")) != null)
                {
                    return new GenericResponse(true, "El rol Admin ya existe, se omitió la creación."); // <--- CAMBIO 2: Retornar respuesta
                }

                var admin = new ApplicationUser
                {
                    UserName = "Admin",
                    Email = "admin@admin.com",
                    EmailConfirmed = true,
                    Name = "Admin General"
                };

                var result = await userManager.CreateAsync(admin, "Admin123!"); // Asegúrate de usar una contraseña fuerte

                if (!result.Succeeded)
                {
                    var error = CheckResponse(result);
                    return new GenericResponse(false, error ?? "Error creando admin");
                }

                // Crear el rol y asignar
                await AssignUserToRole(admin, new IdentityRole { Name = "Admin" });

                return new GenericResponse(true, "Usuario Admin creado exitosamente"); // <--- CAMBIO 3: Retornar éxito
            }
            catch (Exception ex)
            {
                return new GenericResponse(false, $"Error creating admin user: {ex.Message}");
            }
        }

        public async Task<GenericResponse> CreateRoleAsync(CreateRolDTO model)
        {
            try
            {
                if ((await GetRoleByNameAsync(model.Name)) != null)
                    return new GenericResponse(false, $"{model.Name} already exist.");

                var response = await roleManager.CreateAsync(new IdentityRole(model.Name));
                var error = CheckResponse(response);

                if (!string.IsNullOrEmpty(error))
                    return new GenericResponse(false, $"{model.Name} already created.");

                return new GenericResponse(true, $"{model.Name} created successfully.");
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating role", ex);
            }
        }

        public async Task<IEnumerable<GetRoleDTO>> GetRolesAsync()
        {
            return (await roleManager.Roles.ToListAsync()).Adapt<IEnumerable<GetRoleDTO>>();
        }

        public async Task<IEnumerable<GetUserWithRoleResponseDTO>> GetUserWithRolesAsync()
        {
            var allusers = await userManager.Users.ToListAsync();
            if (allusers is null) return new List<GetUserWithRoleResponseDTO>();

            var list = new List<GetUserWithRoleResponseDTO>();

            foreach (var user in allusers)
            {
                var getUserRole = (await userManager.GetRolesAsync(user)).FirstOrDefault();
                if (getUserRole == null) continue;

                var getRoleInfo = await roleManager.Roles.FirstOrDefaultAsync(r => r.Name!.ToLower() == getUserRole.ToLower());

                if (getRoleInfo != null)
                {
                    list.Add(new GetUserWithRoleResponseDTO
                    {
                        // --- AQUÍ ESTABA EL ERROR GRAVE ---
                        Name = user.Name, // ANTES DECÍA: nameof = user.Name (ESTO ROMPÍA EL EDITOR)
                        Email = user.Email,
                        RoleId = getRoleInfo.Id,
                        RoleName = getRoleInfo.Name
                    });
                }
            }
            return list;
        }

        public async Task<LoginResponse> LoginResponse(LoginDTO model)
        {
            try
            {
                var user = await GetUserByEmailAsync(model.Email);
                if (user == null)
                    return new LoginResponse(false, "User not found.");

                Microsoft.AspNetCore.Identity.SignInResult result;
                try
                {
                    // Corregido typos: CheckPasswordSignInAsync
                    result = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                }
                catch
                {
                    return new LoginResponse(false, "Error during sign in check");
                }

                if (!result.Succeeded)
                    return new LoginResponse(false, "Invalid Credentials");

                string jwtToken = await GenerateToken(user);
                string refreshToken = GenerateRefreshToken();

                if (string.IsNullOrEmpty(jwtToken) || string.IsNullOrEmpty(refreshToken))
                {
                    return new LoginResponse(false, "Error generating tokens");
                }

                var saveResult = await SaveRefreshToken(user.Id, refreshToken);
                if (!saveResult.Flag)
                {
                    return new LoginResponse(false, "Error saving refresh token");
                }

                return new LoginResponse(true, "Login Successful", jwtToken, refreshToken);
            }
            catch (Exception ex)
            {
                return new LoginResponse(false, ex.Message);
            }
        }

        public Task CreateTokken() => throw new NotImplementedException();


        public async Task<LoginResponse> RefreshTokenAsync(RefreshTokenDTO model)
        {
            var token = await context.RefreshTokens.FirstOrDefaultAsync(t => t.Token == model.RefreshToken);

            if (token == null)
                return new LoginResponse(false, "Refresh token not found");

            var user = await userManager.FindByIdAsync(token.UserId);
            if (user == null)
                return new LoginResponse(false, "User not found");

            string newToken = await GenerateToken(user);
            string newRefreshToken = GenerateRefreshToken();

            var saveResult = await SaveRefreshToken(user.Id, newRefreshToken);

            if (saveResult.Flag)
            {
                return new LoginResponse(true, "Token refreshed successfully", newToken, newRefreshToken);
            }
            else
            {
                return new LoginResponse(false, "Error saving new refresh token");
            }
        }

        private async Task<GenericResponse> SaveRefreshToken(string userId, string token)
        {
            try
            {
                // CORRECCIÓN 2: Usar FirstOrDefaultAsync
                var existingToken = await context.RefreshTokens.FirstOrDefaultAsync(t => t.UserId == userId);

                if (existingToken == null)
                {
                    // CORRECCIÓN 3: UserId (con d minúscula al final si así está en tu entidad)
                    context.RefreshTokens.Add(new RefreshToken() { UserId = userId, Token = token });
                }
                else
                {
                    existingToken.Token = token;
                }

                await context.SaveChangesAsync();
                return new GenericResponse(true, "Token saved");
            }
            catch (Exception ex)
            {
                return new GenericResponse(false, ex.Message);
            }
        }
    }
}