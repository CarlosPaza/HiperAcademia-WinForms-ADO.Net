namespace EntityFrameworkTest1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class criacao_coluna_ehvalido : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PedidoDeVendas", "EhValido", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PedidoDeVendas", "EhValido");
        }
    }
}
