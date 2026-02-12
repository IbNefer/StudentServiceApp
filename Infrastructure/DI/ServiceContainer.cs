using Application.Contracts.Account;
using Domain.Entity.Authentication;
using Domain.Interfaces;
using Domain.Interfaces.Persona;
using Infrastructure.Data;
using Infrastructure.Repository;
using Infrastructure.Repository.Persona;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace Infrastructure.DI
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(c => c.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentityCore<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddSignInManager();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddAuthorization();
            services.AddCors(options =>
            {
                options.AddPolicy("WebUi",
                    builder => builder
                    .WithOrigins("https://localhost:7243")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    );
            });

            services.AddScoped<IAccount, AccountRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IEstudianteRepository, EstudianteRepository>();
            services.AddScoped<ITitulacionRepository, TitulacionRepository>();
            services.AddScoped<IProfesorRepository, ProfesorRepository>();
            services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
            services.AddScoped<IPensumRepository, PensumRepository>();  
            services.AddScoped<IAsignaturaRepository, AsignaturaRepository>();
            services.AddScoped<IHorarioRepository, HorarioRepository>();
            services.AddScoped<IAreaConocimientoRepository, AreaConocimientoRepository>();
            services.AddScoped<IAsignaturaEquivalenciaRepository, AsignaturaEquivalenciaRepository>();
            services.AddScoped<IAsignaturaIncompatibilidadRepository, AsignaturaIncompatibilidadRepository>();


            return services;
        }
    }
}
