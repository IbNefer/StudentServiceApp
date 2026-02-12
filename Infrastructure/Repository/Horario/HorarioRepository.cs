using Domain.Entity;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class HorarioRepository(AppDbContext context) : GenericRepository<Horario>(context), IHorarioRepository { }
}