using Application.Extensions;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components.Authorization;
using NetcodeHub.Packages.Extensions.LocalStorage;
using Application.Services.Titulacion;
using Application.Contracts.Departamento;
using Application.Contracts.Pensum;
using Application.Contracts.Asignatura;
using Application.Contracts.Horario;
using Application.Contracts.AreaConocimiento;
using Application.Contracts.AsignaturaIncompatibilidad;
using Application.Contracts.AsignaturaEquivalencia;

namespace Application.Contracts.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IServiceAccount, AccountService>();
            services.AddScoped<IEstudianteService, EstudianteService>();
            services.AddScoped<ITitulacionService, TitulacionService>();
            services.AddScoped<IProfesorService, ProfesorService>();
            services.AddScoped<IDepartamentoService, DepartamentoService>();
            services.AddScoped<IPensumService, PensumService>();
            services.AddScoped<IAsignaturaService, AsignaturaService>();
            services.AddScoped<IHorarioService, HorarioService>();
            services.AddScoped<IAreaConocimientoService, AreaConocimientoService>();
            services.AddScoped<IAsignaturaEquivalenciaService, AsignaturaEquivalenciaService>();
            services.AddScoped<IAsignaturaIncompatibilidadService, AsignaturaIncompatibilidadService>();

            services.AddAuthorizationCore();
            services.AddNetcodeHubLocalStorageService();
            services.AddScoped<Extensions.LocalStorageService>();

            services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

            services.AddTransient<CustomHttpHandler>();

            services.AddCascadingAuthenticationState();

            services.AddHttpClient("WebUiClient", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7243/");
            })
            .AddHttpMessageHandler<CustomHttpHandler>();

            return services;
        }
    }
}