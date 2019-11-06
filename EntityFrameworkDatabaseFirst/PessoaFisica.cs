namespace EntityFrameworkDatabaseFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PessoaFisica")]
    public partial class PessoaFisica
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PessoaFisica()
        {
            PedidoDeVenda = new HashSet<PedidoDeVenda>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        [StringLength(50)]
        public string Sobrenome { get; set; }

        [StringLength(30)]
        public string Cpf { get; set; }

        [StringLength(20)]
        public string Rg { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PedidoDeVenda> PedidoDeVenda { get; set; }
    }
}
