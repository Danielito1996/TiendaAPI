using Microsoft.AspNetCore.Mvc;
using TiendaAPI.Modelos.Generales;
using TiendaAPI.Servicios;
using TiendaAPI.Servicios.Aplicacion.Logs;
using TiendaAPI.Servicios.Negocios.ServiciosGenerales;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TiendaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private IServicios Servicios;
        private IServiciosGenerales serviciosGenerales;
        private IServiciosLogs _logs;
        public ProductosController(IServicios servicios) 
        {
            Servicios = servicios;
            serviciosGenerales=Servicios.ObtenerServiciosDeNegocios().ObtenerServiciosGenerales();
            _logs=Servicios.ObtenerServiciosDeAplicacion().ObtenerServiciosLogs();
        }    

        // GET: api/<ProductosController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ProductosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductosController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductoAdaptado producto)
        {
            try
            {
                await serviciosGenerales.AgregarProductos(producto);
                return Ok();
            }
            catch (Exception ex)
            {
                await _logs.Log($"Error al agregar Productos : {ex.Message}");
                return Problem($"Error al agregar Productos : {ex.Message}");
            }
        }

        // PUT api/<ProductosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
