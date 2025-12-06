using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Persona
{
    public interface IEstudianteRepository : IGenericRepository<Estudiante>
    {
        // Task<Estudiante> GetByMatriculaAsync(string matricula);
    }
}
