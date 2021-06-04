using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Antojitos.Web.Host.DTO
{
    public class ClienteOutputDto
    {
        public decimal IdCliente { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
    }
}
