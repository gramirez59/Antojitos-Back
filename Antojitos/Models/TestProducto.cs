using System;
using System.Collections.Generic;

#nullable disable

namespace Antojitos.Web.Host.Models
{
    public partial class TestProducto
    {
        public TestProducto()
        {
            TestFacturaDetalles = new List<TestFacturaDetalle>();
        }

        public decimal IdProducto { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal ValorUnidad { get; set; }
        public int Stock { get; set; }

        public virtual List<TestFacturaDetalle> TestFacturaDetalles { get; set; }
    }
}
