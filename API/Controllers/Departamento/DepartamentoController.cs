using Application.DTOs.Request.Departamento; // Asumiendo que tienes este DTO, si no usa el genérico o crea uno
using Application.DTOs.Response;
using Application.DTOs.Response.Departamento; // Ajusta según tus namespaces
using AutoMapper;
using Domain.Entity;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController(IDepartamentoRepository repository, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartamentoResponseDTO>>> GetAll()
        {
            var data = await repository.GetAllAsync();
            return Ok(mapper.Map<IEnumerable<DepartamentoResponseDTO>>(data));
        }

        [HttpPost]
        public async Task<ActionResult<GenericResponse>> Create(CreateDepartamentoRequestDTO model) // Asegurate de tener este DTO
        {
            // Un DTO simple: public class CreateDepartamentoRequestDTO { public string Nombre { get; set; } }
            if (!ModelState.IsValid) return BadRequest("Modelo inválido");
            try
            {
                var entity = mapper.Map<Departamento>(model);
                await repository.AddAsync(entity);
                return Ok(new GenericResponse(true, "Departamento creado"));
            }
            catch (Exception ex) { return BadRequest(new GenericResponse(false, ex.Message)); }
        }
    }
}