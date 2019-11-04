using System;
using System.Data;
using System.Data.SqlClient;

namespace CadastroClienteAcademiaCsharp.Data
{
    public class CidadeRepository : ConexaoBd
    {
        public DataTable GetCidades()
        {
            var conexaoBd = new ConexaoBd();

            var sql = @"SELECT a.Id
                                ,a.Nome
                                ,a.Estado
                            FROM Cidade a
                            ORDER BY a.Nome";

            return conexaoBd.ExecuteReader(sql);
        }

        public DataTable GetCidadesByNome(string nome)
        {
            var conexaoBd = new ConexaoBd();
            conexaoBd.AddParametro("@nome", nome);

            var sql = @"SELECT a.Id
                            ,a.Nome
                            ,a.Estado
                        FROM Cidade a
                        WHERE a.Nome like '%' + @nome + '%'
                        ORDER BY a.Nome";
            
            return conexaoBd.ExecuteReader(sql);
        }
    }
}
