namespace EntityFrameworkTest1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("Model1")
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<PedidoDeVenda> PedidosDeVenda { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
