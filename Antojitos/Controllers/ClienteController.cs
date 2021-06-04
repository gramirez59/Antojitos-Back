using System.Collections.Generic;
using Antojitos.Web.Host.BL;
using Antojitos.Web.Host.Data;
using Antojitos.Web.Host.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Antojitos.Web.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly AntojitosContext _antojitosContext;

        public ClienteController(AntojitosContext antojitosContext)
        {
            _antojitosContext = antojitosContext;
        }
        
        /// <summary>
        /// Retorna todos los clientes registrados en la BD
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetClientes")]
        public List<ClienteOutputDto> GetClientes()
        {
            ClienteManager clienteManager = new ClienteManager(_antojitosContext);
            List<ClienteOutputDto> clientes = clienteManager.GetTestClientes();
            return clientes;
        }
    }
}
