using Domain.Entity;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class DepartamentoRepository(AppDbContext context) : GenericRepository<Departamento>(context), IDepartamentoRepository { }
}