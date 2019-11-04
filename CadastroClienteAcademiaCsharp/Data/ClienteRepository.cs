using CadastroClienteAcademiaCsharp.Domain;
using System;
using System.Data;

namespace CadastroClienteAcademiaCsharp.Data
{
    public class ClienteRepository
    {
        public DataTable GetClientes(string nome)
        {
            var dt = StaticRepository.GetClientes().Select($" Nome like '%{nome}%' ");

            return dt.CopyToDataTable();
        }

        public DataTable GetClientesById(Guid id)
        {
            var dt = StaticRepository.GetClientes().Select($" Id= '{id.ToString()}' ");

            return dt.CopyToDataTable();
        }

        public int InsertCliente(Cliente cliente)
        {
            return StaticRepository.InsertCliente(cliente.Nome, cliente.CidadeId.ToString(), cliente.Telefone);
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