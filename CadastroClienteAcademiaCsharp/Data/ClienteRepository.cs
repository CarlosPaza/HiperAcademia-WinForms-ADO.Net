using CadastroClienteAcademiaCsharp.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CadastroClienteAcademiaCsharp.Data
{
    public class ClienteRepository
    {
        private IEnumerable<Cliente> Parser(DataTable dt)
        {
            var list = new List<Cliente>();

            foreach (DataRow item in dt.Rows)
            {
                var cliente = new Cliente();
                cliente.Codigo = int.Parse(item["Codigo"].ToString());
                cliente.Id = Guid.Parse(item["Id"].ToString());
                cliente.Nome = item["Nome"].ToString();
                cliente.Telefone = item["Telefone"].ToString();
                cliente.DataDeCadastro = DateTime.Parse(item["DataCadastro"].ToString());
                cliente.CidadeId = Guid.Parse(item["CidadeId"].ToString());

                cliente.Cidade = new Cidade();
                cliente.Cidade.Id = Guid.Parse(item["CidadeId"].ToString());
                cliente.Cidade.Nome = item["CidadeNome"].ToString();
                cliente.Cidade.Estado = item["Estado"].ToString();

                list.Add(cliente);
            }

            return list;
        }

        public IEnumerable<Cliente> GetClientes(string nome)
        {
            var conexaoBd = new ConexaoBd();
            conexaoBd.AddParametro("@nome", nome);

            var sql = @"SELECT a.Id
                                  ,a.Codigo
                                  ,a.Nome
                                  ,b.Id as CidadeId
                                  ,b.Nome as CidadeNome
                                  ,b.Estado
                                  ,a.Telefone
                                  ,a.DataCadastro
                              FROM Cliente a
                              LEFT JOIN Cidade b ON b.Id = a.CidadeId
                             WHERE a.Nome like '%' + @nome + '%'
                             ORDER BY a.Codigo";

            var dt = conexaoBd.ExecuteReader(sql);

            return Parser(dt);
        }

        public Cliente GetClientesById(Guid id)
        {
            var conexaoBd = new ConexaoBd();
            conexaoBd.AddParametro("@id", id);

            var sql = @"SELECT a.Id
                                  ,a.Codigo
                                  ,a.Nome
                                  ,b.Id as CidadeId
                                  ,b.Nome as CidadeNome
                                  ,b.Estado
                                  ,a.Telefone
                                  ,a.DataCadastro
                              FROM Cliente a
                              LEFT JOIN Cidade b ON b.Id = a.CidadeId
                             WHERE a.Id = @id";

            var dt = conexaoBd.ExecuteReader(sql);

            return Parser(dt).FirstOrDefault();

        }

        public int InsertCliente(Cliente cliente)
        {
            var conexaoBd = new ConexaoBd();
            conexaoBd.AddParametro("@nome", cliente.Nome);
            conexaoBd.AddParametro("@cidade", cliente.CidadeId);
            conexaoBd.AddParametro("@telefone", cliente.Telefone);

            var sql = @"INSERT INTO Cliente (Nome, CidadeId, Telefone)
                             VALUES (@nome, @cidade, @telefone)";

            return conexaoBd.ExecuteNonQuery(sql);

        }

        public int EditCliente(Cliente cliente)
        {
            var conexaoBd = new ConexaoBd();
            conexaoBd.AddParametro("@nome", cliente.Nome);
            conexaoBd.AddParametro("@cidade", cliente.CidadeId);
            conexaoBd.AddParametro("@telefone", cliente.Telefone);
            conexaoBd.AddParametro("@id", cliente.Id);

            var sql = @"UPDATE Cliente 
                               SET Nome = @nome, 
                                   CidadeId = @cidade, 
                                   Telefone = @telefone
                             WHERE Id = @id";

            return conexaoBd.ExecuteNonQuery(sql);

        }

        public int DeleteCliente(Guid clienteId)
        {
            var conexaoBd = new ConexaoBd();
            conexaoBd.AddParametro("@id", clienteId);

            var sql = @"DELETE FROM Cliente 
                             WHERE Id = @id";

            return conexaoBd.ExecuteNonQuery(sql);
        }
    }
}
