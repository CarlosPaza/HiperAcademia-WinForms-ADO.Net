using CadastroClienteAcademiaCsharp.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CadastroClienteAcademiaCsharp.Data
{
    public class ClienteRepository
    {
        public IEnumerable<Cliente> GetClientes(string nome)
        {
            return new List<Cliente>();
        }

        public Cliente GetClientesById(Guid id)
        {
            return null;
        }

        public int InsertCliente(Cliente cliente)
        {
            return 1;
        }

        public int EditCliente(Cliente cliente)
        {
            return 1;
        }

        public int DeleteCliente(Guid clienteId)
        {
            return 1;
        }
    }
}
