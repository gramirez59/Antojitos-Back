using Antojitos.Web.Host.Data;
using Antojitos.Web.Host.DTO;
using System.Collections.Generic;
using System.Linq;

namespace Antojitos.Web.Host.BL
{
    public class ProductoManager
    {
        private readonly AntojitosContext _context;
        public ProductoManager(AntojitosContext context)
        {
            _context = context;
        }

        public List<ProductoOutputDto> GetTestProductos()
        {
            var productoDto = (from producto in _context.TestProductos.ToList()
                               select new ProductoOutputDto()
                               {
                                   IdProducto = producto.IdProducto,
                                   Codigo = producto.Codigo,
                                   Nombre = producto.Nombre,
                                   ValorUnidad = producto.ValorUnidad,
                                   Stock = producto.Stock
                               }).ToList();
            return productoDto;
        }
    }
}
