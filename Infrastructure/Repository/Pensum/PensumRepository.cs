using Domain.Entity;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class PensumRepository(AppDbContext context) : GenericRepository<Pensum>(context), IPensumRepository { }
}