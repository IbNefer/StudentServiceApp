using Application.DTOs.Request.Persona; // Tus DTOs
using Application.DTOs.Response;
using Application.DTOs.Response.Persona;
using AutoMapper;
using Domain.Entity;
using Domain.Interfaces; // Aquí está IEstudianteRepository
using Domain.Interfaces.Persona;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EstudianteController(IEstudianteRepository repository, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstudianteResponseDTO>>> GetAll()
        {

            var data = await repository.GetAllAsync();

            var response = mapper.Map<IEnumerable<EstudianteResponseDTO>>(data);

            return Ok(response);
        }

        // GET: api/Estudiante/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstudianteResponseDTO>> GetById(int id)
        {
            var data = await repository.GetByIdAsync(id);

            if (data == null) return NotFound("Estudiante no encontrado");

            var response = mapper.Map<EstudianteResponseDTO>(data);
            return Ok(response);
        }


        [HttpPost]
        public async Task<ActionResult<GenericResponse>> Create(CreateEstudianteRequestDTO model)
        {
            if (!ModelState.IsValid) return BadRequest("Modelo inválido");

            try
            {

                var entity = mapper.Map<Estudiante>(model);

                await repository.AddAsync(entity);

                return Ok(new GenericResponse(true, "Estudiante creado correctamente"));
            }
            catch (Exception ex)
            {
                return BadRequest(new GenericResponse(false, ex.Message));
            }
        }

        [HttpPut]
        public async Task<ActionResult<GenericResponse>> Update(CreateEstudianteRequestDTO model)
        {

            try
            {
                var entity = mapper.Map<Estudiante>(model);
                await repository.UpdateAsync(entity);
                return Ok(new GenericResponse(true, "Estudiante actualizado correctamente"));
            }
            catch (Exception ex)
            {
                return BadRequest(new GenericResponse(false, ex.Message));
            }
        }

        // DELETE: api/Estudiante/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GenericResponse>> Delete(int id)
        {
            try
            {
                await repository.DeleteAsync(id);
                return Ok(new GenericResponse(true, "Estudiante eliminado correctamente"));
            }
            catch (Exception ex)
            {
                return BadRequest(new GenericResponse(false, ex.Message));
            }
        }
    }
}