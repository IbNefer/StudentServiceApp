using Application.DTOs.Request.Titulacion; // Asumiendo que existe
using Application.DTOs.Response;
using Application.DTOs.Response.Titulacion;
using AutoMapper;
using Domain.Entity;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitulacionController(ITitulacionRepository repository, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TitulacionResponseDTO>>> GetAll()
        {
            var data = await repository.GetAllAsync();
            return Ok(mapper.Map<IEnumerable<TitulacionResponseDTO>>(data));
        }

        [HttpPost]
        public async Task<ActionResult<GenericResponse>> Create(CreateTitulacionRequestDTO model)
        {
            // DTO: public class CreateTitulacionRequestDTO { public string Nombre {get;set;} public int DepartamentoId {get;set;} }
            if (!ModelState.IsValid) return BadRequest("Modelo inválido");
            try
            {
                var entity = mapper.Map<Titulacion>(model);
                await repository.AddAsync(entity);
                return Ok(new GenericResponse(true, "Titulación creada"));
            }
            catch (Exception ex) { return BadRequest(new GenericResponse(false, ex.Message)); }
        }
    }
}