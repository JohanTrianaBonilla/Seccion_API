using Business.Interfaces;
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



        //// GET: api/<ClaseController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<ClaseController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ClaseController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ClaseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClaseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
