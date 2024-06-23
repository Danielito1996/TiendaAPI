using Microsoft.AspNetCore.Mvc;
using TiendaAPI.Modelos.Generales;
using TiendaAPI.Servicios.Aplicacion.BaseDatos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TiendaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElaboracionController : ControllerBase
    {
        private IPorSQLite _porSQLite;
        public ElaboracionController(IPorSQLite porSQLite)
        {
            _porSQLite = porSQLite;
        }


        // GET: api/<ElaboracionController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ElaboracionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ElaboracionController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<Producto> productos)
        {
            try
            {
                await _porSQLite.GuardarListaDeElementos<Producto>(productos);
            }
            catch (Exception ex)
            {
                return Problem($"Problemas al insertar {ex.Message}");
            }
            return Ok();
              
        }

        // PUT api/<ElaboracionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ElaboracionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
