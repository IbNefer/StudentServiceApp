using Domain.Entity;
using Domain.Interfaces.Persona;
using Infrastructure.Data;


namespace Infrastructure.Repository
{
    public class ProfesorRepository(AppDbContext context) : GenericRepository<Profesor>(context), IProfesorRepository
    {
    }
}
