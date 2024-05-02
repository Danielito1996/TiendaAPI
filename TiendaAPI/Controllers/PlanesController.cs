using Microsoft.AspNetCore.Mvc;
using TiendaAPI.Modelos.AreaElaboracion;
using TiendaAPI.Servicios.Aplicacion.Logs;
using TiendaAPI.Servicios.Negocios;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TiendaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanesController : ControllerBase
    {
        private IServiciosNegocios _negocios;
        private IServiciosLogs _logs;
        public PlanesController(IServiciosNegocios serviciosNegocios, IServiciosLogs logs)
        {
            _negocios = serviciosNegocios;
            _logs = logs;
        }
        // GET: api/<PlanesController>
        [HttpGet]
        public async Task<string> Get()
        {
            return "Jka";
        }

        // GET api/<PlanesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PlanesController>
        [HttpPost]
        public async Task<string> PostPlanGeneral([FromBody] List<PlanIndividual> planesIndividuales)
        {
            try
            {
                await _negocios.ObtenerServiciosDeElaboracion().ConstruirPlanGeneral(planesIndividuales);

            }
            catch (Exception ex)
            {
                await _logs.Log($"Error a la hora de costruir el plan general{ex.Message}");
                return $"Error a la hora de costruir el plan general{ex.Message}";
            }
            return "Plan construido correctamente";
        }

        // PUT api/<PlanesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PlanesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }
    }
}
