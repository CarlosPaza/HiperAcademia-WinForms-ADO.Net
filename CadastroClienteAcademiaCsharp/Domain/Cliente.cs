using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroClienteAcademiaCsharp.Domain
{
    public class Cliente
    {
        public Guid Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; }

        public string Nome { get; set; }
        public Guid? CidadeId { get; set; }
        public virtual Cidade Cidade { get; set; }
        public string Telefone { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DataCadastro { get; set; }
    }
}