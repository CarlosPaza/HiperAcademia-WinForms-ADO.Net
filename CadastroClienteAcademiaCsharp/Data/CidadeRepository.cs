using CadastroClienteAcademiaCsharp.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CadastroClienteAcademiaCsharp.Data
{
    public class CidadeRepository : ConexaoBd
    {
        public IEnumerable<Cidade> GetCidades()
        {
            using(var entityModel = new EntityModel())
            {
                return entityModel.Cidades
                    .OrderBy(x => x.Nome)
                    .ToList();
            }
        }

        public IEnumerable<Cidade> GetCidadesByNome(string nome)
        {
            using(var entityModel = new EntityModel())
            {
                return entityModel.Cidades
                    .Where(x => x.Nome.Contains(nome))
                    .OrderBy(x => x.Nome)
                    .ToList();
            }
        }
    }
}
