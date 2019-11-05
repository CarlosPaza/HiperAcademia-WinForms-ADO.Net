namespace CadastroClienteAcademiaCsharp.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cliente")]
    public partial class Cliente
    {
        public Guid Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        public Guid? CidadeId { get; set; }

        [StringLength(20)]
        public string Telefone { get; set; }

        public DateTime DataCadastro { get; set; }

        public virtual Cidade Cidade { get; set; }
    }
}
