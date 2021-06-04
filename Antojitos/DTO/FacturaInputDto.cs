using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Antojitos.Web.Host.DTO
{
    public class FacturaInputDto
    {
        public decimal Identifiacion { get; set; }
        public List<FacturaDetalleDto> FacturaDetalle { get; set; }
    }
}
