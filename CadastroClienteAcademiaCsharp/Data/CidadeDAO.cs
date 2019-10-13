using System;
using System.Data;
using System.Data.SqlClient;

namespace CadastroClienteAcademiaCsharp.Data
{
    public class CidadeDAO : ConexaoBd
    {
        public DataTable GetCidades()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var sql = @"SELECT a.Id
                                  ,a.Nome
                                  ,a.Estado
                              FROM Cidade a
                             ORDER BY a.Nome";

                using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            var dataTable = new DataTable();
                            dataTable.Load(dataReader);
                            dataReader.Close();
                            return dataTable;
                        }
                    }
                    catch
                    {
                        throw new Exception("Não foi possível carregar as cidades.");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public DataTable GetCidadesByNome(string nome)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var sql = @"SELECT a.Id
                                  ,a.Nome
                                  ,a.Estado
                              FROM Cidade a
                             WHERE a.Nome like '%' + @nome + '%'
                             ORDER BY a.Nome";

                using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@nome", SqlDbType.VarChar));
                    sqlCommand.Parameters["@nome"].Value = nome;
                    try
                    {
                        connection.Open();
                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            var dataTable = new DataTable();
                            dataTable.Load(dataReader);
                            dataReader.Close();
                            return dataTable;
                        }
                    }
                    catch
                    {
                        throw new Exception("Não foi possível carregar as cidades.");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}
