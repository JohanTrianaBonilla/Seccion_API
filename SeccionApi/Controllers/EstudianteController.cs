using Business.Interfaces;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SeccionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {


        private readonly IEstudianteServices _Estudiante;
        public EstudianteController(IEstudianteServices Estudiante)
        {
            _Estudiante = Estudiante;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var listaServicio = _Estudiante.ConsultarEstudiantes();
                return Ok(listaServicio);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // GET api/<EstudianteController>/5
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(String Id)
        {
            try
            {
                var item = _Estudiante.Buscar(Id);
                if (item == null)
                {
                    return NotFound();
                }
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<EstudianteController>
        [HttpPost]
        public async Task<ActionResult> Post(Estudiante registro)
        {
            try
            {
                String estudiante = "";
                estudiante = _Estudiante.Agregar(registro);
                return Ok(estudiante);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<EstudianteController>/5
        [HttpPut("{Id}")]
        public async Task<IActionResult> put(String Id, Estudiante registro)
        {
            try
            {
                String estudiante = "";
                estudiante = _Estudiante.Actualizar(Id, registro);
                return Ok(estudiante);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE api/<EstudianteController>/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(string Id)
        {
            try
            {
                String id = "";
                id = _Estudiante.Eliminar(Id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
