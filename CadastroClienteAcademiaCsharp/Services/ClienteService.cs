using CadastroClienteAcademiaCsharp.Data;
using CadastroClienteAcademiaCsharp.Domain;
using System;
using System.Collections.Generic;
using System.Data;

namespace CadastroClienteAcademiaCsharp.Services
{
    public class ClienteService
    {
        public IEnumerable<Cliente> GetClientes(string nome = "")
        {
            return new ClienteRepository().GetClientes(nome);
        }

        public Cliente GetClienteById(string id)
        {
            return new ClienteRepository().GetClienteById(Guid.Parse(id));
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
                return new ClienteRepository().InsertCliente(cliente);
            }

            return new ClienteRepository().EditCliente(cliente);
        }

        public int DeleteCliente(string clienteId)
        {
            return new ClienteRepository().DeleteCliente(Guid.Parse(clienteId));
        }
    }
}
