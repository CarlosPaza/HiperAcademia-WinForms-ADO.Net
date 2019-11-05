using CadastroClienteAcademiaCsharp.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CadastroClienteAcademiaCsharp.Data
{
    public class CidadeRepository
    {
        private IEnumerable<Cidade> Parser(DataTable dt)
        {
            var list = new List<Cidade>();

            foreach (DataRow item in dt.Rows)
            {
                var cidade = new Cidade();
                cidade.Id = Guid.Parse(item["Id"].ToString());
                cidade.Nome = item["Nome"].ToString();
                cidade.Estado = item["Estado"].ToString();

                list.Add(cidade);
            }

            return list;
        }

        public IEnumerable<Cidade> GetCidades()
        {
            var conexaoBd = new ConexaoBd();

            var sql = @"SELECT a.Id
                                ,a.Nome
                                ,a.Estado
                            FROM Cidade a
                            ORDER BY a.Nome";

            var dt = conexaoBd.ExecuteReader(sql);

            return Parser(dt);
        }

        public IEnumerable<Cidade> GetCidadesByNome(string nome)
        {
            var conexaoBd = new ConexaoBd();
            conexaoBd.AddParametro("@nome", nome);

            var sql = @"SELECT a.Id
                            ,a.Nome
                            ,a.Estado
                        FROM Cidade a
                        WHERE a.Nome like '%' + @nome + '%'
                        ORDER BY a.Nome";

            var dt = conexaoBd.ExecuteReader(sql);

            return Parser(dt);
        }
    }
}
