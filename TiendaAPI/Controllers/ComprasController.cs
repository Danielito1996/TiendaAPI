using Microsoft.AspNetCore.Mvc;
using TiendaAPI.Modelos.AreaFinanzas;
using TiendaAPI.Servicios.Aplicacion.Logs;
using TiendaAPI.Servicios.Negocios.AreaAlmacen;
using TiendaAPI.Servicios.Negocios.AreaAlmacen.AreaCompras;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TiendaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private IServiciosLogs _logs;
        private IServiciosAlmacen _serviciosAlmacen;
        private IServiciosCompras _compras;
        public ComprasController(IServiciosLogs logs, IServiciosAlmacen serviciosAlmacen)
        {
            _logs = logs;
            _serviciosAlmacen = serviciosAlmacen;
            _compras = _serviciosAlmacen.ObtenerServiciosCompras();
        }
        // GET: api/<ComprasController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ComprasController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ComprasController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<Compras> compras)
        {
            try
            {
                await _serviciosAlmacen.RealizarCompra(compras);
                return Ok();
            }
            catch (Exception ex)
            {
                await _logs.Log($"Error a la hora de Insertar la adquisicion :{ex.Message}");
                return Problem($"Error a la hora de Insertar la adquisicion :{ex.Message}");
            }
        }

        // PUT api/<ComprasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ComprasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
