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
            serviciosGenerales = Servicios.ObtenerServiciosDeNegocios().ObtenerServiciosGenerales();
            _logs = Servicios.ObtenerServiciosDeAplicacion().ObtenerServiciosLogs();
        }

        // GET: api/<ProductosController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var lis = await serviciosGenerales.ObtenerInformacionProductos();
                return Ok(lis);
            }
            catch (Exception ex)
            {
                await _logs.Log($"Error a la hora de optener datos {ex.Message}");
                return Problem($"Error a la hora de optener datos {ex.Message}");
            }
        }

        // GET api/<ProductosController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var lis = await serviciosGenerales.ObtenerInformacionProductos(id);
                return Ok(lis);
            }
            catch (Exception ex)
            {
                await _logs.Log($"Error a la hora de optener datos {ex.Message}");
                return Problem($"Error a la hora de optener datos {ex.Message}");
            }
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
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Producto producto)
        {
            try
            {
                await serviciosGenerales.ModificarProducto(producto);
                return Ok("Producto Modificado");
            }
            catch (Exception ex)
            {
                await _logs.Log($"Error al modificar Productos : {ex.Message}");
                return Problem($"Error al modificar Productos : {ex.Message}");
            }

        }

        // DELETE api/<ProductosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await serviciosGenerales.EliminarProductos(id);
                return Ok("Producto Modificado");
            }
            catch (Exception ex)
            {
                await _logs.Log($"Error al modificar Productos : {ex.Message}");
                return Problem($"Error al modificar Productos : {ex.Message}");
            }
        }
    }
}
