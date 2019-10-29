using CadastroClienteAcademiaCsharp.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace CadastroClienteAcademiaCsharp.Data
{
    public class ClienteDAO : ConexaoBd
    {
        public IEnumerable<Cliente> GetClientes()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var sql = @"SELECT a.Id
                                  ,a.Codigo
                                  ,a.Nome
                                  ,a.Telefone
                                  ,a.DataCadastro as Cadastro
                                  ,a.CidadeId
                                  ,b.Id
                                  ,b.Nome
                                  ,b.Estado
                              FROM Cliente a
                              LEFT JOIN Cidade b ON b.Id = a.CidadeId
                             ORDER BY a.Codigo";

                return connection.Query<Cliente, Cidade, Cliente>(sql, (cliente, cidade) =>
                {
                    cliente.Cidade = cidade;
                    return cliente;
                });
            }
        }

        public IEnumerable<Cliente> GetClientesByNome(string nome)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var sql = @"SELECT a.Id
                                  ,a.Codigo
                                  ,a.Nome
                                  ,a.Telefone
                                  ,a.DataCadastro as Cadastro
                                  ,a.CidadeId
                                  ,b.Id
                                  ,b.Nome
                                  ,b.Estado
                              FROM Cliente a
                              LEFT JOIN Cidade b ON b.Id = a.CidadeId
                             WHERE a.Nome like '%' + @nome + '%'
                             ORDER BY a.Codigo";

                return connection.Query<Cliente, Cidade, Cliente>(sql, (cliente, cidade) =>
                {
                    cliente.Cidade = cidade;
                    return cliente;
                }, new { nome = nome });
            }
        }

        public Cliente GetClienteById(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var sql = @"SELECT a.Id
                                  ,a.Codigo
                                  ,a.Nome
                                  ,a.CidadeId
                                  ,a.Telefone
                                  ,a.DataCadastro as Cadastro
                                  ,b.Id
                                  ,b.Nome
                                  ,b.Estado
                              FROM Cliente a
                              LEFT JOIN Cidade b ON b.Id = a.CidadeId
                             WHERE a.Id = @id";

                return connection.Query<Cliente, Cidade, Cliente>(sql, (cliente, cidade) =>
                {
                    cliente.Cidade = cidade;
                    return cliente;
                }, new { id = id }).FirstOrDefault();
            }
        }

        public int InsertCliente(Cliente cliente)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var sql = @"INSERT INTO Cliente (Nome, CidadeId, Telefone)
                             VALUES (@nome, @cidade, @telefone)";

                return connection.Execute(sql, new
                {
                    nome = cliente.Nome,
                    cidade = cliente.CidadeId,
                    telefone = cliente.Telefone
                });
            }
        }

        public int EditCliente(Cliente cliente)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var sql = @"UPDATE Cliente
                               SET Nome = @nome,
                                   CidadeId = @cidade,
                                   Telefone = @telefone
                             WHERE Id = @id";

                return connection.Execute(sql, new
                {
                    id = cliente.Id,
                    nome = cliente.Nome,
                    cidade = cliente.CidadeId,
                    telefone = cliente.Telefone
                });
            }
        }

        public int DeleteCliente(Guid clienteId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var sql = @"DELETE FROM Cliente
                             WHERE Id = @id";

                return connection.Execute(sql, new
                {
                    id = clienteId
                });
            }
        }
    }
}