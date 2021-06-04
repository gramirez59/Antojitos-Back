using System.Collections.Generic;

namespace Antojitos.Web.Host.Models
{
    public partial class TestCliente
    {
        public TestCliente()
        {
            TestFacturas = new List<TestFactura>();
        }

        public decimal IdCliente { get; set; }
        public decimal Identifiacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public virtual List<TestFactura> TestFacturas { get; set; }
    }
}
