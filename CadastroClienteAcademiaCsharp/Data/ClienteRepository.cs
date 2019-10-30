using CadastroClienteAcademiaCsharp.Domain;
using System;
using System.Data;

namespace CadastroClienteAcademiaCsharp.Data
{
    public class ClienteRepository : ConexaoBd
    {
        public DataTable GetClientes(string nome)
        {
            var conexaoBd = new ConexaoBd();
            conexaoBd.AddParametro("@nome", nome);

            var sql = @"SELECT a.Id
                                  ,a.Codigo
                                  ,a.Nome
                                  ,b.Nome as Cidade
                                  ,a.Telefone
                                  ,a.DataCadastro as Cadastro
                              FROM Cliente a
                              LEFT JOIN Cidade b ON b.Id = a.CidadeId
                             WHERE a.Nome like '%' + @nome + '%'
                             ORDER BY a.Codigo";

            return conexaoBd.ExecuteReader(sql);
        }

        public DataTable GetClientesById(Guid id)
        {
            var conexaoBd = new ConexaoBd();
            conexaoBd.AddParametro("@id", id);

            var sql = @"SELECT a.Id
                                  ,a.Codigo
                                  ,a.Nome
                                  ,b.Id as CidadeId
                                  ,b.Nome as Cidade
                                  ,a.Telefone
                                  ,a.DataCadastro as Cadastro
                              FROM Cliente a
                              LEFT JOIN Cidade b ON b.Id = a.CidadeId
                             WHERE a.Id = @id";

            return conexaoBd.ExecuteReader(sql);

        }

        public int InsertCliente(Cliente cliente)
        {
            var conexaoBd = new ConexaoBd();
            conexaoBd.AddParametro("@nome", cliente.Nome);
            conexaoBd.AddParametro("@cidade", cliente.CidadeId == Guid.Empty ? (object)DBNull.Value : cliente.CidadeId);
            conexaoBd.AddParametro("@telefone", cliente.Telefone);

            var sql = @"INSERT INTO Cliente (Nome, CidadeId, Telefone)
                             VALUES (@nome, @cidade, @telefone)";

            return conexaoBd.ExecuteNonQuery(sql);

        }

        public int EditCliente(Cliente cliente)
        {
            var conexaoBd = new ConexaoBd();
            conexaoBd.AddParametro("@nome", cliente.Nome);
            conexaoBd.AddParametro("@cidade", cliente.CidadeId == Guid.Empty ? (object)DBNull.Value : cliente.CidadeId);
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
