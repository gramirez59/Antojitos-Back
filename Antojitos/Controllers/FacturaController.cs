using Antojitos.Web.Host.BL;
using Antojitos.Web.Host.Data;
using Antojitos.Web.Host.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Antojitos.Web.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly AntojitosContext _antojitosContext;

        public FacturaController(AntojitosContext antojitosContext)
        {
            _antojitosContext = antojitosContext;
        }

        /// <summary>
        /// Registra una venta en la BD
        /// </summary>
        /// <param name="facturaInputDto">Contiene el detalle de la venta, identificación del cliente y la lista de articulos</param>
        /// <returns></returns>
        [HttpPost("RegistrarVenta")]
        public IActionResult Post([FromBody] FacturaInputDto facturaInputDto)
        {
            ClienteManager clienteManager = new ClienteManager(_antojitosContext);
            if (!clienteManager.GetTestClienteByIdentification(facturaInputDto.Identifiacion))
                return StatusCode(500, "El cliente no existe en la Base de Datos");
            else
                return StatusCode(200, "Factura exitosa");
        }
    }
}
