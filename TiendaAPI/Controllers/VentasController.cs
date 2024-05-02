using Microsoft.AspNetCore.Mvc;
using TiendaAPI.Modelos.AreaVenta;
using TiendaAPI.Servicios.Aplicacion.Logs;
using TiendaAPI.Servicios.Negocios.AreaVentas;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TiendaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private IServiciosVentas _serviciosVentas;
        private IServiciosLogs _logs;
        public VentasController(IServiciosVentas serviciosVentas, IServiciosLogs logs)
        {
            _serviciosVentas = serviciosVentas;
            _logs = logs;
        }
        // GET: api/<VentasController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _serviciosVentas.ObtenerVentas());
            }
            catch (Exception ex)
            {
                await _logs.Log($"No se pudo recuperar informacion de venta {ex.Message}");
                return Problem($"No se pudo recuperar informacion de venta {ex.Message}");
            }
        }

        // GET api/<VentasController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var venta = await _serviciosVentas.ObtenerVentas(id);
                return Ok(venta);
            }
            catch (Exception ex)
            {
                await _logs.Log($"No se pudo recuperar informacion de venta {ex.Message}");
                return Problem($"No se pudo recuperar informacion de venta {ex.Message}");
            }

        }

        // POST api/<VentasController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Venta venta)
        {
            try
            {
                await _serviciosVentas.VenderProducto(venta.Productos);
                await _serviciosVentas.GenerarReporteDeVentas(venta.Productos);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<VentasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VentasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
