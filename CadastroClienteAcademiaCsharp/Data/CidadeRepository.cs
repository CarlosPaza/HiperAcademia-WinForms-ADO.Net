using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CadastroClienteAcademiaCsharp.Data
{
    public class CidadeRepository
    {
        public DataTable GetCidades()
        {
            return StaticRepository.GetCidades();
        }

        public DataTable GetCidadesByNome(string nome)
        {
            var dt = StaticRepository.GetCidades().Select($" Nome like '%{nome}%' ");

            return dt.CopyToDataTable();
        }
    }
}
