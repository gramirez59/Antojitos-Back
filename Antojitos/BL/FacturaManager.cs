using Antojitos.Web.Host.Data;

namespace Antojitos.Web.Host.BL
{
    public class FacturaManager
    {
        private readonly AntojitosContext _context;
        public FacturaManager(AntojitosContext context)
        {
            _context = context;
        }
    }
}
