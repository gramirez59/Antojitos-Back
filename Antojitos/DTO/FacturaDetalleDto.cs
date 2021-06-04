using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Antojitos.Web.Host.DTO
{
    public class FacturaDetalleDto
    {
        public decimal IdProducto { get; set; }
        public int Cantidad { get; set; }
    }
}
