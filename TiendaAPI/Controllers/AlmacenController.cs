using Microsoft.AspNetCore.Mvc;
using TiendaAPI.Modelos.AreaAlmacen;
using TiendaAPI.Servicios;
using TiendaAPI.Servicios.Aplicacion.BaseDatos;
using TiendaAPI.Servicios.Aplicacion.Logs;
using TiendaAPI.Servicios.Negocios;
using TiendaAPI.Servicios.Negocios.AreaAlmacen;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TiendaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlmacenController : ControllerBase
    {
        private IServicios _servicios;
        private IServiciosAlmacen _serviciosAlmacen;
        private IServiciosLogs _logs;
        private IPorSQLite _bd;
        private IAlmacen _almacen;

        public AlmacenController(IServicios servicios, IAlmacen almacen)
        {
            _almacen = almacen;
            _servicios = servicios;
            _logs=_servicios.ObtenerServiciosDeAplicacion().ObtenerServiciosLogs();
            _serviciosAlmacen=_servicios.ObtenerServiciosDeNegocios().ObtenerServiciosDeAlmacen();
            _bd = _servicios.ObtenerServiciosDeAplicacion().ObtenerAccesoBD();
        }

        // GET: api/<AlmacenController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<MateriaPrima> materiasPrimas = await _serviciosAlmacen.MostrarMateriasPrimas();
                return Ok(materiasPrimas);
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
        public async Task<IActionResult> ObtenerUnaMateriaPrima(int id)
        {

            try
            {
                MateriaPrima materiasPrimas = await _serviciosAlmacen.InformaciondeMateriaPrima(id);
                return Ok(materiasPrimas);
            }
            catch (Exception ex)
            {
                // Aquí puedes manejar la excepción como prefieras
                await _logs.Log($"Error a la hora de obtener datos {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertarMateriaPrima([FromBody] MateriaPrimaAdapter materiaprima)
        {
            try
            {
                await _serviciosAlmacen.RecepcionarMateriaPrima(materiaprima);
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
        public async Task<IActionResult> ModificarMateriaPrima([FromBody] MateriaPrima value)
        {
            try
            {
                MateriaPrima aModificar = await _almacen.ObtenerDatosDeMateriasPrimas(value.Id);
                aModificar = value;
                await _almacen.ModificarMateriasPrimas(aModificar);
                return Ok();
            }
            catch (Exception ex)
            {
                // Aquí puedes manejar la excepción como prefieras
                await _logs.Log($"Error a la hora de obtener datos {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        // DELETE api/<AlmacenController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var aEliminar=await _almacen.ObtenerDatosDeMateriasPrimas(id);   
                await _almacen.QuitarMateriasPrimas(aEliminar);
                return Ok();
            }
            catch (Exception ex)
            {
                // Aquí puedes manejar la excepción como prefieras
                await _logs.Log($"Error a la hora de obtener datos {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
