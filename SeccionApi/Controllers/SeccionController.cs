using Business.Interfaces;
using Core.ModelView;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SeccionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeccionController : ControllerBase
    {


        private readonly ISeccionesServices _Seccion;
        public SeccionController(ISeccionesServices Seccion)
        {
            _Seccion = Seccion;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var listaServicio = _Seccion.ConsultarSecciones();
                return Ok(listaServicio);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<SeccionController>/5
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(String Id)
        {
            try
            {
                var item = _Seccion.Buscar(Id);
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

        // POST api/<SeccionController>
        [HttpPost]
        public async Task<ActionResult> Post(SeccionesView registro)
        {

            try
            {
                string seccion = "";
                seccion = _Seccion.Agregar(registro);
                return Ok(seccion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        // PUT api/<SeccionController>/5
        [HttpPut("{Id}")]
        public async Task<IActionResult> put(String Id, SeccionesView registro)
        {
            try
            {
                
                var seccionActualizada = _Seccion.Actualizar(Id, registro);
                return Ok(seccionActualizada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE api/<SeccionController>/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(string Id)
        {
            try
            {
                String id = "";
                id = _Seccion.Eliminar(Id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
