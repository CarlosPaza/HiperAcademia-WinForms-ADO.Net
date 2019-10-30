using CadastroClienteAcademiaCsharp.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace CadastroClienteAcademiaCsharp.Data
{
    public class ClienteRepository : ConexaoBd
    {
        public IEnumerable<Cliente> GetClientes(string nome)
        {
            using (var db = new DatabaseContext())
            {
                return db.Clientes
                    .Include(x => x.Cidade)
                    .Where(x => x.Nome.Contains(nome))
                    .OrderBy(x => x.Codigo).ToList();
            }
        }
        
        public Cliente GetClienteById(Guid id)
        {
            using (var db = new DatabaseContext())
            {
                return db.Clientes
                    .Include(x => x.Cidade)
                    .FirstOrDefault(x => x.Id == id);
            }
        }

        public int InsertCliente(Cliente cliente)
        {
            using (var db = new DatabaseContext())
            {
                db.Clientes.Add(cliente);
                return db.SaveChanges();
            }
        }

        public int EditCliente(Cliente cliente)
        {
            using (var db = new DatabaseContext())
            {
                db.Entry(cliente).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public int DeleteCliente(Guid clienteId)
        {
            using (var db = new DatabaseContext())
            {
                var cliente = db.Clientes.FirstOrDefault(x => x.Id == clienteId);

                db.Clientes.Remove(cliente);

                return db.SaveChanges();
            }
        }
    }
}