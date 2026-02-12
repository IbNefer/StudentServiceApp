using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Infrastructure.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            // 1. Configurar para leer el appsettings.json
            // Asumimos que el appsettings está en la carpeta del proyecto API (un nivel arriba y luego en API)
            // Ajusta la ruta si tu estructura de carpetas es diferente.
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .Build();

            // 2. Construir las opciones
            var builder = new DbContextOptionsBuilder<AppDbContext>();

            // 3. Obtener el Connection String
            // NOTA: Si al ejecutar Remove-Migration no encuentra el string, 
            // puedes ponerlo aquí "hardcoded" temporalmente solo para salir del error:
            // var connectionString = "Server=TU_SERVER;Database=TU_DB;Trusted_Connection=True;TrustServerCertificate=True;";
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);

            // 4. Retornar el contexto
            return new AppDbContext(builder.Options);
        }
    }
}