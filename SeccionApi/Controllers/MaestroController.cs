using Business.Interfaces;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SeccionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaestroController : ControllerBase
    {
        private readonly IMaestroServices _Maestros;
        public MaestroController(IMaestroServices Maestro)
        {
            _Maestros = Maestro;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var listaServicio = _Maestros.ConsultarServicios();
                return Ok(listaServicio);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //GET api/<MaestroController>/5
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(String Id)
        {
            try
            {
                var item = _Maestros.Buscar(Id);
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

        // POST api/<MaestroController>
        [HttpPost]
        public async Task<ActionResult> Post(Maestro registro)
        {
            try
            {
                String maestro = "";
                maestro = _Maestros.Agregar(registro);
                return Ok(maestro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // PUT api/<MaestroController>/5
        [HttpPut("{Id}")]
        public async Task<IActionResult> put(String Id, Maestro registro)
        {
            try
            {
                String maestro = "";
                maestro = _Maestros.Actualizar(Id,registro);
                return Ok(maestro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE api/<MaestroController>/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(string Id)
        {
            try
            {
                String id = "";
                id = _Maestros.Eliminar(Id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
