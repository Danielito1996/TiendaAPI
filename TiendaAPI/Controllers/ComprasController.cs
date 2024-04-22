using Microsoft.AspNetCore.Mvc;
using TiendaAPI.Modelos.AreaFinanzas;
using TiendaAPI.Servicios;
using TiendaAPI.Servicios.Aplicacion.Logs;
using TiendaAPI.Servicios.Negocios.AreaAlmacen.AreaCompras;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TiendaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private IServiciosLogs _logs;
        private IServiciosCompras _serviciosCompras;
        public ComprasController(IServiciosLogs logs,IServiciosCompras compras)
        { 
            _logs= logs;
            _serviciosCompras= compras;
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
        public async void Post([FromBody] List<Compras> compras)
        {
            try
            {
               if(compras.Count>1)
                   await _serviciosCompras.GenerarNuevaAdquisicion(compras);
            }
            catch (Exception ex)
            { 

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
