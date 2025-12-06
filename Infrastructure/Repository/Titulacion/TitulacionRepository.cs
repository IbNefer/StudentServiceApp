using Domain.Entity;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class TitulacionRepository(AppDbContext context) : GenericRepository<Titulacion>(context), ITitulacionRepository
    {
    }
}
