using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroClienteAcademiaCsharp.Data
{
    public static class StaticRepository
    {
        private static DataTable dtCidade;
        private static DataTable dtCliente;

        public static DataTable GetClientes()
        {
            if (dtCliente is null) dtCliente = InicializarClientes();

            return dtCliente;
        }
                
        public static DataTable GetCidades()
        {
            if (dtCidade is null) dtCidade = InicializarCidades();

            return dtCidade;
        }

        public static int InsertCliente(string nome, string cidadeId, string telefone)
        {
            if (dtCliente is null) dtCliente = InicializarClientes();

            dtCliente.Rows.Add(Guid.NewGuid(), new Random().Next(0,100), nome, cidadeId, telefone, DateTime.Now);

            return 1;
        }

        public static DataTable InicializarClientes()
        {
            var dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Codigo");
            dt.Columns.Add("Nome");
            dt.Columns.Add("CidadeId");
            dt.Columns.Add("Telefone");
            dt.Columns.Add("DataCadastro");

            dt.Rows.Add(Guid.NewGuid(), "1", "Rafael Dalsenter", "1", "32670001", DateTime.Now);

            return dt;
        }

        public static DataTable InicializarCidades()
        {
            var dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Nome");
            dt.Columns.Add("Estado");

            dt.Rows.Add(Guid.NewGuid(), "Brusque", "SC");
            dt.Rows.Add(Guid.NewGuid(), "Blumenau", "SC");
            dt.Rows.Add(Guid.NewGuid(), "Guabiruba", "SC");
            dt.Rows.Add(Guid.NewGuid(), "São Paulo", "SP");
            dt.Rows.Add(Guid.NewGuid(), "Rio de Janeiro", "RJ");
            dt.Rows.Add(Guid.NewGuid(), "Belo Horizonte", "MG");
            dt.Rows.Add(Guid.NewGuid(), "Porto Alegre", "RS");
            dt.Rows.Add(Guid.NewGuid(), "Curitiba", "PR");

            return dt;
        }
    }
}
