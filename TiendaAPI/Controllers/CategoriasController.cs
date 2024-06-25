using Microsoft.AspNetCore.Mvc;
using TiendaAPI.Servicios.Aplicacion.Logs;
using TiendaAPI.Servicios.Negocios.AreaAlmacen.AreaCompras;
using TiendaAPI.Servicios.Negocios.AreaAlmacen;
using TiendaAPI.Servicios.Negocios.AreaVentas.ZonaDeOfertas;
using TiendaAPI.Modelos.AreaAlmacen;
using TiendaAPI.Modelos.AreaVenta;

namespace TiendaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private IServiciosLogs _logs;
        private IRectorDeCategorias _categorias;
        public CategoriasController(IServiciosLogs serviciosLogs,IRectorDeCategorias categorias) 
        {
            _logs = serviciosLogs;
            _categorias = categorias;
        }

        // GET: api/<AlmacenController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listaCategorias =await _categorias.ObtenerCategoriasDeVentas();
                return Ok(listaCategorias);
            }
            catch (Exception ex)
            {
                // Aquí puedes manejar la excepción como prefieras
                await _logs.Log($"Error a la hora de obtener datos {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        // GET api/<AlmacenController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId(int id)
        {

            try
            {
                var categoria = await _categorias.ObtenerCategoriaPorID(id);
                return Ok(categoria);
            }
            catch (Exception ex)
            {
                // Aquí puedes manejar la excepción como prefieras
                await _logs.Log($"Error a la hora de obtener datos {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Categorias categoria)
        {
            try
            {
                await _categorias.InsertarCategoria(categoria);
            }
            catch (Exception ex)
            {
                return Problem($"Problemas al insertar {ex.Message}");
            }
            return Ok();
        }

        //Esto no esta funcionando
        // PUT api/<AlmacenController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ModificarMateriaPrima([FromBody] Categorias value)
        {
            try
            {
                await _categorias.ModificarCategoria(value);
                return Ok();
            }
            catch (Exception ex)
            {
                // Aquí puedes manejar la excepción como prefieras
                await _logs.Log($"Error a la hora de modificar datos {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        // DELETE api/<AlmacenController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                //await _categorias.EliminarCategoria(id);
                return Ok();
            }
            catch (Exception ex)
            {
                // Aquí puedes manejar la excepción como prefieras
                await _logs.Log($"Error a la hora de eliminar datos {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
