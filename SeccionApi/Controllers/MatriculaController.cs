using Business.Interfaces;
using Core.ModelView;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SeccionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {


        private readonly IMatriculaServices _Matricula;
        public MatriculaController(IMatriculaServices Matricula)
        {
            _Matricula = Matricula;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var listaServicio = _Matricula.ConsultarMatriculas();
                return Ok(listaServicio);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<MatriculaController>/5
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            try
            {
                var item = _Matricula.Buscar(Id);
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

        // POST api/<MatriculaController>
        [HttpPost]
        public async Task<ActionResult> Post(int Id, string IdEstudiante, string IdSeccion)
        {
            try
            {
                var matricula = _Matricula.Agregar(Id, IdEstudiante, IdSeccion);
                return Ok(matricula);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<MatriculaController>/5
        [HttpPut("{Id}")]
        public async Task<IActionResult> put(int Id, [FromBody] MatriculaView registro)
        {
            try
            {
               
               var matriculaActualizada = _Matricula.Actualizar(Id, registro);
                return Ok(matriculaActualizada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE api/<MatriculaController>/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            try
            {
                int id = 0;
                id = _Matricula.Eliminar(Id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
