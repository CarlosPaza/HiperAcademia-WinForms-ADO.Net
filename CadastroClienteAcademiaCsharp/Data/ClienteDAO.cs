using CadastroClienteAcademiaCsharp.Domain;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CadastroClienteAcademiaCsharp.Data
{
    public class ClienteDAO : ConexaoBd
    {
        public DataTable GetClientes()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var sql = @"SELECT a.Id
                                  ,a.Codigo
                                  ,a.Nome
                                  ,b.Nome as Cidade
                                  ,a.Telefone
                                  ,a.DataCadastro as Cadastro
                              FROM Cliente a
                              LEFT JOIN Cidade b ON b.Id = a.CidadeId
                             ORDER BY a.Codigo";

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
                        throw new Exception("Não foi possível carregar os clientes.");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public DataTable GetClientesByNome(string nome)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
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

                using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@nome", SqlDbType.VarChar));
                    sqlCommand.Parameters["@nome"].Value = nome;
                    //sqlCommand.Parameters.AddWithValue("@nome", nome);
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
                        throw new Exception("Não foi possível carregar os clientes.");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public DataTable GetClientesById(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
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

                using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.UniqueIdentifier));
                    sqlCommand.Parameters["@id"].Value = id;
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
                        throw new Exception("Não foi possível carregar o cliente.");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public int InsertCliente(Cliente cliente)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var sql = @"INSERT INTO Cliente (Nome, CidadeId, Telefone)
                             VALUES (@nome, @cidade, @telefone)";

                using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@nome", SqlDbType.VarChar));
                    sqlCommand.Parameters["@nome"].Value = cliente.Nome;
                    sqlCommand.Parameters.Add(new SqlParameter("@cidade", SqlDbType.UniqueIdentifier));
                    sqlCommand.Parameters["@cidade"].Value = cliente.CidadeId == Guid.Empty ? (object)DBNull.Value : cliente.CidadeId;
                    sqlCommand.Parameters.Add(new SqlParameter("@telefone", SqlDbType.VarChar));
                    sqlCommand.Parameters["@telefone"].Value = cliente.Telefone;
                    try
                    {
                        connection.Open();
                        return sqlCommand.ExecuteNonQuery();
                    }
                    catch
                    {
                        throw new Exception("Não foi possível inserir o cliente.");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
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

                using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@nome", SqlDbType.VarChar));
                    sqlCommand.Parameters["@nome"].Value = cliente.Nome;
                    sqlCommand.Parameters.Add(new SqlParameter("@cidade", SqlDbType.UniqueIdentifier));
                    sqlCommand.Parameters["@cidade"].Value = cliente.CidadeId == Guid.Empty ? (object)DBNull.Value : cliente.CidadeId;
                    sqlCommand.Parameters.Add(new SqlParameter("@telefone", SqlDbType.VarChar));
                    sqlCommand.Parameters["@telefone"].Value = cliente.Telefone;
                    sqlCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.UniqueIdentifier));
                    sqlCommand.Parameters["@id"].Value = cliente.Id;
                    try
                    {
                        connection.Open();
                        return sqlCommand.ExecuteNonQuery();
                    }
                    catch
                    {
                        throw new Exception("Não foi possível editar o cliente.");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public int DeleteCliente(Guid clienteId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var sql = @"DELETE FROM Cliente 
                             WHERE Id = @id";

                using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.UniqueIdentifier));
                    sqlCommand.Parameters["@id"].Value = clienteId;
                    try
                    {
                        connection.Open();
                        return sqlCommand.ExecuteNonQuery();
                    }
                    catch
                    {
                        throw new Exception("Não foi possível excluir o cliente.");
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
