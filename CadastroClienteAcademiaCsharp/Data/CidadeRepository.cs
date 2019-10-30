using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using CadastroClienteAcademiaCsharp.Domain;
using Dapper;

namespace CadastroClienteAcademiaCsharp.Data
{
    public class CidadeRepository : ConexaoBd
    {
        public IEnumerable<Cidade> GetCidades()
        {
            using (var db = new DatabaseContext())
            {
                return db.Cidades
                    .OrderBy(x => x.Nome).ToList();
            }
        }

        public IEnumerable<Cidade> GetCidadesByNome(string nome)
        {
            using (var db = new DatabaseContext())
            {
                return db.Cidades
                    .Where(x => x.Nome.Contains(nome))
                    .OrderBy(x => x.Nome).ToList();
            }
        }
    }
}