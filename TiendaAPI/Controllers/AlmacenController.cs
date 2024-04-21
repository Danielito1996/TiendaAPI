using Microsoft.AspNetCore.Mvc;
using TiendaAPI.Modelos.AreaAlmacen;
using TiendaAPI.Servicios;
using TiendaAPI.Servicios.Aplicacion.BaseDatos;
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
        private IPorSQLite _bd;
        private IAlmacen _almacen;

        public AlmacenController(IServicios servicios, IAlmacen almacen)
        {
            _almacen = almacen;
            _servicios = servicios;
            _serviciosAlmacen=_servicios.ObtenerServiciosDeNegocios().ObtenerServiciosDeAlmacen();
            _bd = _servicios.ObtenerServiciosDeAplicacion().ObtenerAccesoBD();
              
        }

        // GET: api/<AlmacenController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AlmacenController>/5
        [HttpGet("{id}")]
        public async Task<string> Get(int id)
        {
            return "OK";
        }

        // POST api/<AlmacenController>
        /*[HttpPost]
        public async Task<IActionResult> InsertarListaDeMateriasPrimas([FromBody] List<MateriaPrimaAdapter> materiaprima)
        {
           
            return Ok();

        }*/
        [HttpPost]
        public async Task<IActionResult> InsertarMateriaPrima([FromBody] MateriaPrimaAdapter materiaprima)
        {
            try
            {
                await _serviciosAlmacen.RecepcionarMateriaPrima(materiaprima);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
            var a = _almacen.Inventario;
            var l = a.MateriaPrima;

            return Ok();

        }

        // PUT api/<AlmacenController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AlmacenController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
