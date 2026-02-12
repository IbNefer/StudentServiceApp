using Domain.Entity;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class AsignaturaRepository(AppDbContext context) : GenericRepository<Asignatura>(context), IAsignaturaRepository { }
}