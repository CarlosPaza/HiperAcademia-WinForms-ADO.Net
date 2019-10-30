using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroClienteAcademiaCsharp.Data
{
    public class ConexaoBd
    {
        protected const string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=AulaBancoDeDados;Trusted_connection=true;";

        private List<SqlParameter> _parametros = new List<SqlParameter>();

        public void AddParametro(string name, object value)
        {
            _parametros.Add(new SqlParameter(name, value));
        }

        public int ExecuteNonQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                {
                    _parametros.ForEach(x => sqlCommand.Parameters.Add(x));
                    try
                    {
                        connection.Open();
                        return sqlCommand.ExecuteNonQuery();
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public DataTable ExecuteReader(string query)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                {
                    _parametros.ForEach(x => sqlCommand.Parameters.Add(x));
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
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}
