using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Antojitos.Web.Host.DTO
{
    public class ProductoOutputDto
    {
        public decimal IdProducto { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal ValorUnidad { get; set; }
        public int Stock { get; set; }
    }
}
