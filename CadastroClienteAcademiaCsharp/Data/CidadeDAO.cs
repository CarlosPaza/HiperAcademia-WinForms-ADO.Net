using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CadastroClienteAcademiaCsharp.Domain;
using Dapper;

namespace CadastroClienteAcademiaCsharp.Data
{
    public class CidadeDAO : ConexaoBd
    {
        public IEnumerable<Cidade> GetCidades()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var sql = @"SELECT a.Id
                                  ,a.Nome
                                  ,a.Estado
                              FROM Cidade a
                             ORDER BY a.Nome";

                return connection.Query<Cidade>(sql);
            }
        }

        public IEnumerable<Cidade> GetCidadesByNome(string nome)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var sql = @"SELECT a.Id
                                  ,a.Nome
                                  ,a.Estado
                              FROM Cidade a
                             WHERE a.Nome like '%' + @nome + '%'
                             ORDER BY a.Nome";

                return connection.Query<Cidade>(sql, new { nome = nome });
            }
        }
    }
}