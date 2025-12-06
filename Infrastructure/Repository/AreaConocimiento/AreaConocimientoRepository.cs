using Domain.Entity;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class AreaConocimientoRepository(AppDbContext context) : GenericRepository<AreaConocimiento>(context), IAreaConocimientoRepository { }
}
