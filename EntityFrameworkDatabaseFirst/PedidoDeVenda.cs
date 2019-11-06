namespace EntityFrameworkDatabaseFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PedidoDeVenda")]
    public partial class PedidoDeVenda
    {
        public int Id { get; set; }

        public int? PessoaFisicaId { get; set; }

        [StringLength(200)]
        public string Observacao { get; set; }

        public virtual PessoaFisica PessoaFisica { get; set; }
    }
}
