using CadastroClienteAcademiaCsharp.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace CadastroClienteAcademiaCsharp.Data
{
    public class ClienteRepository : ConexaoBd
    {
        public IEnumerable<Cliente> GetClientes(string nome)
        {
            using (var entityModel = new EntityModel())
            {
                return entityModel.Clientes
                    .Include(x => x.Cidade)
                    .Where(x => x.Nome.Contains(nome))
                    .OrderBy(x => x.Codigo)
                    .ToList();
            }

        }

        public Cliente GetClientesById(Guid id)
        {
            using (var entityModel = new EntityModel())
            {
                return entityModel.Clientes
                    .Include(x => x.Cidade)
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
            }
        }

        public int InsertCliente(Cliente cliente)
        {
            using (var entityModel = new EntityModel())
            {
                entityModel.Clientes.Add(cliente);

                return entityModel.SaveChanges();
            }
        }

        public int EditCliente(Cliente cliente)
        {
            using (var entityModel = new EntityModel())
            {
                entityModel.Entry(cliente).State = EntityState.Modified;
                return entityModel.SaveChanges();
            }
        }

        public int DeleteCliente(Guid clienteId)
        {
            using (var entityModel = new EntityModel())
            {
                var cliente = entityModel.Clientes.FirstOrDefault(x => x.Id == clienteId);

                entityModel.Clientes.Remove(cliente);

                return entityModel.SaveChanges();
            }
        }
    }
}
