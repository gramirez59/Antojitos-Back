using System;
using System.Collections.Generic;

#nullable disable

namespace Antojitos.Web.Host.Models
{
    public partial class TestFactura
    {
        public TestFactura()
        {
            TestFacturaDetalles = new List<TestFacturaDetalle>();
        }

        public decimal IdFactura { get; set; }
        public decimal IdCliente { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal ValorTotal { get; set; }

        public virtual TestCliente IdClienteNavigation { get; set; }
        public virtual List<TestFacturaDetalle> TestFacturaDetalles { get; set; }
    }
}
