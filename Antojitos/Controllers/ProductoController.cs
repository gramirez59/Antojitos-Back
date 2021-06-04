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
    public class ProductoController : ControllerBase
    {
        private readonly AntojitosContext _antojitosContext;
        public ProductoController(AntojitosContext antojitosContext)
        {
            _antojitosContext = antojitosContext;
        }
        
        /// <summary>
        /// Retorna todos los productos
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetProductos")]
        public List<ProductoOutputDto> GetProductos()
        {
            ProductoManager productoManager = new ProductoManager(_antojitosContext);
            List <ProductoOutputDto> productos = productoManager.GetTestProductos();
            return productos;
        }
    }
}
