using Business.Interfaces;
using Core.ModelView;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SeccionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarreraController : ControllerBase
    {

        private readonly ICarreraServices _Carrera;
        public CarreraController(ICarreraServices Carrera)
        {
            _Carrera = Carrera;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var listaServicio = _Carrera.ConsultarServicios();
                return Ok(listaServicio);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<CarreraController>/5
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById( int Id)
        {
            try
            {
                var item = _Carrera.Buscar(Id);
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

        // POST api/<CarreraController>
        [HttpPost]
        public async Task<ActionResult> Post(CarreraView registro)
        {
            try
            {
                int carrera = 0;
                carrera = _Carrera.Agregar(registro);
                return Ok(carrera);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CarreraController>/5
        [HttpPut("{Id}")]
        public async Task<IActionResult> put(int Id, CarreraView registro)
        {
            try
            {
                int carrera = 0;
                carrera = _Carrera.Actualizar(Id, registro);
                return Ok(carrera);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE api/<CarreraController>/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            try
            {
                int id = 0;
                id = _Carrera.Eliminar(Id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
