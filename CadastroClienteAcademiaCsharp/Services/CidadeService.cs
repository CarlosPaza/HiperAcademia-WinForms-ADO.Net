using CadastroClienteAcademiaCsharp.Data;
using CadastroClienteAcademiaCsharp.Domain;
using System.Collections.Generic;
using System.Data;

namespace CadastroClienteAcademiaCsharp.Services
{
    public class CidadeService
    {
        public IEnumerable<Cidade> GetCidades()
        {
            return new CidadeRepository().GetCidades();
        }

        public IEnumerable<Cidade> GetCidadesByNome(string nome)
        {
             return new CidadeRepository().GetCidadesByNome(nome);
        }
    }
}
