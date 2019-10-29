using System;

namespace CadastroClienteAcademiaCsharp.Domain
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public Guid CidadeId { get; set; }
        public Cidade Cidade { get; set; }
        public string Telefone { get; set; }
        public DateTime DataDeCadastro { get; set; }
    }
}