using Domain.Entity;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class AsignaturaIncompatibilidadRepository(AppDbContext context) : GenericRepository<AsignaturaIncompatibilidad>(context), IAsignaturaIncompatibilidadRepository { }
}