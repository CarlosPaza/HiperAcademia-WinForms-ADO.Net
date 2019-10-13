using CadastroClienteAcademiaCsharp.Data;
using CadastroClienteAcademiaCsharp.Domain;
using System;
using System.Data;

namespace CadastroClienteAcademiaCsharp.Services
{
    public class ClienteService
    {
        public DataTable GetClientes()
        {
            return new ClienteDAO().GetClientes();
        }

        public DataTable GetClientesByNome(string nome)
        {
            return string.IsNullOrEmpty(nome) ?
                GetClientes() :
                new ClienteDAO().GetClientesByNome(nome);
        }

        public DataTable GetClientesById(string id)
        {
            return new ClienteDAO().GetClientesById(Guid.Parse(id));
        }

        public int SaveCliente(string clienteId, string nome, string cidade, string telefone)
        {
            var cidadeId = string.IsNullOrWhiteSpace(cidade) ? Guid.Empty : Guid.Parse(cidade);
            var id = clienteId is null ? Guid.Empty : Guid.Parse(clienteId);
            var cliente = new Cliente()
            {
                Id = id,
                Nome = nome,
                CidadeId = cidadeId,
                Telefone = telefone
            };

            if (cliente.Id == Guid.Empty)
            {
                return new ClienteDAO().InsertCliente(cliente);
            }

            return new ClienteDAO().EditCliente(cliente);
        }

        public int DeleteCliente(string clienteId)
        {
            return new ClienteDAO().DeleteCliente(Guid.Parse(clienteId));
        }
    }
}
