using CadastroClienteAcademiaCsharp.Data;
using System.Data;

namespace CadastroClienteAcademiaCsharp.Services
{
    public class CidadeService
    {
        public DataTable GetCidades()
        {
            return new CidadeRepository().GetCidades();
        }

        public DataTable GetCidadesByNome(string nome)
        {
            return string.IsNullOrEmpty(nome) ?
                GetCidades() :
                new CidadeRepository().GetCidadesByNome(nome);
        }
    }
}
