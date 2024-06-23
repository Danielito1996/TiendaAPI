using Microsoft.AspNetCore.Mvc;
using TiendaAPI.Modelos.AreaElaboracion;
using TiendaAPI.Servicios.Aplicacion.BaseDatos;
using TiendaAPI.Servicios.Aplicacion.Logs;
using TiendaAPI.Servicios.Negocios.AreaElaboracion;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TiendaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NormasTecnicasController : ControllerBase
    {
        private IServiciosLogs _log;
        private IServiciosElaboracion _elaboracion;
        private IPorSQLite _bd;
        public NormasTecnicasController(IServiciosElaboracion elaboracion,IServiciosLogs log,IPorSQLite bd)
        {
            _elaboracion = elaboracion;
            _log = log;
            _bd = bd;
        }

        // GET: api/<NormasTecnicasController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _bd.ObtenerListaDeElementos<NormasTecnicas>());
        }

        // GET api/<NormasTecnicasController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
             try
             {
                var normaTecnica = await _elaboracion.ObtenerNormasTecnicas(id);
                return Ok(normaTecnica);
             }
            catch (Exception ex)
            {
                await _log.Log($"Error al devolver Normas Tecnicas del producto con Id {id}");
                return Problem($"Error al devolver Normas Tecnicas del producto con Id {id}");
            }
        }

        // POST api/<NormasTecnicasController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<NormasTecnicas> normasTecnicas)
        {
            try
            {
                await _bd.GuardarListaDeElementos<NormasTecnicas>(normasTecnicas);
            
            }
            catch (Exception ex)
            {
                return Problem($"Problemas al insertar {ex.Message}");
            }
            return Ok();

        }

        // PUT api/<NormasTecnicasController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] NormasTecnicas normasTecnicas)
        {
            try
            {
                await _bd.ModificarElemento<NormasTecnicas>(normasTecnicas);
                
            }
            catch (Exception ex)
            {
                await _log.Log($"Error en la modificacion de Nomatecnica ID: {id}-> {ex.Message}");
                Problem($"Error en la modificacion de Nomatecnica ID: {id}-> {ex.Message}");
            }
            return Ok(id);
        }

        // DELETE api/<NormasTecnicasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
