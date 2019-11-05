using CadastroClienteAcademiaCsharp.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CadastroClienteAcademiaCsharp.Data
{
    public class CidadeRepository
    {
        public IEnumerable<Cidade> GetCidades()
        {
            return new List<Cidade>();
        }

        public IEnumerable<Cidade> GetCidadesByNome(string nome)
        {
            return new List<Cidade>();
        }
    }
}
