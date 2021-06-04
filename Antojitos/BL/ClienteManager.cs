using Antojitos.Web.Host.Data;
using Antojitos.Web.Host.DTO;
using Antojitos.Web.Host.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Antojitos.Web.Host.BL
{
    public class ClienteManager
    {
        private readonly AntojitosContext _context;

        public ClienteManager(AntojitosContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna todos los clientes registrados en la BD pero con el formato del DTO para no retornar toda la información de la entidad o modelo
        /// </summary>
        /// <returns></returns>
        public List<ClienteOutputDto> GetTestClientes()
        {
            var clientesDto = (from cliente in _context.TestClientes.ToList()
                               select new ClienteOutputDto()
                                {
                                    IdCliente = cliente.IdCliente,
                                    Nombres = cliente.Nombres,
                                    Apellidos = cliente.Apellidos
                               }).ToList();
            return clientesDto;
        }

        /// <summary>
        /// Consulta si en la Base de datos existe con la identificación consultada
        /// </summary>
        /// <param name="identificacion">Número de identificación del cliente</param>
        /// <returns></returns>
        public Boolean GetTestClienteByIdentification(decimal identificacion)
        {
            TestCliente client = _context.TestClientes.Where(x => x.Identifiacion == identificacion).FirstOrDefault();
            if (client != null)
                return true;
            else
                return false;
        }
    }
}
