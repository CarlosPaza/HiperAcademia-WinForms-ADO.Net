using System.Data.Entity.ModelConfiguration.Conventions;
using CadastroClienteAcademiaCsharp.Domain;

namespace CadastroClienteAcademiaCsharp
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=DatabaseContext")
        {
        }

        public virtual DbSet<Cidade> Cidades { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            Database.SetInitializer<DatabaseContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}