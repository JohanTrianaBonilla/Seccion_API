using Business.Interfaces;
using Core.ModelView;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SeccionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaseController : ControllerBase
    {

        private readonly IClaseServices _Clase;
        public ClaseController(IClaseServices Clase)
        {
            _Clase = Clase;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var listaServicio = _Clase.ConsultarClases();
                return Ok(listaServicio);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ClaseController>/5
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            try
            {
                var item = _Clase.Buscar(Id);
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

        // POST api/<ClaseController>
        [HttpPost]
        public async Task<ActionResult> Post(ClaseView registro)
        {
            try
            {
                int clase = 0;
                clase = _Clase.Agregar(registro);
                return Ok(clase);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ClaseController>/5
        [HttpPut("{Id}")]
        public async Task<IActionResult> put(int Id, ClaseView registro)
        {
            try
            {
                int clase = 0;
                clase = _Clase.Actualizar(Id, registro);
                return Ok(clase);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ClaseController>/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            try
            {
                int codigo = 0;
                codigo = _Clase.Eliminar(Id);
                return Ok(codigo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
