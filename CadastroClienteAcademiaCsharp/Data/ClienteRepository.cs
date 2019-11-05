using CadastroClienteAcademiaCsharp.Domain;
using System;
using System.Data;

namespace CadastroClienteAcademiaCsharp.Data
{
    public class ClienteRepository
    {
        public DataTable GetClientes(string nome)
        {
            return new DataTable();
        }

        public DataTable GetClientesById(Guid id)
        {
            return new DataTable();
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