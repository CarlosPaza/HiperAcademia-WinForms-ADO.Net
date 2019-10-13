using CadastroClienteAcademiaCsharp.Data;
using System.Data;

namespace CadastroClienteAcademiaCsharp.Services
{
    public class CidadeService
    {
        public DataTable GetCidades()
        {
            return new CidadeDAO().GetCidades();
        }

        public DataTable GetCidadesByNome(string nome)
        {
            return string.IsNullOrEmpty(nome) ?
                GetCidades() :
                new CidadeDAO().GetCidadesByNome(nome);
        }
    }
}
