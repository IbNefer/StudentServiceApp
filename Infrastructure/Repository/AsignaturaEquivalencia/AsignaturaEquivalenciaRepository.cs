using Domain.Entity;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class AsignaturaEquivalenciaRepository(AppDbContext context) : GenericRepository<AsignaturaEquivalencia>(context), IAsignaturaEquivalenciaRepository { }
}