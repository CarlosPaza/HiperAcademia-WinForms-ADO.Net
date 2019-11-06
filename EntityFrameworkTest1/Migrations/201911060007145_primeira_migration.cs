namespace EntityFrameworkTest1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class primeira_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        EhVivo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PedidoDeVendas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Observacao = c.String(),
                        Cliente_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.Cliente_Id)
                .Index(t => t.Cliente_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PedidoDeVendas", "Cliente_Id", "dbo.Clientes");
            DropIndex("dbo.PedidoDeVendas", new[] { "Cliente_Id" });
            DropTable("dbo.PedidoDeVendas");
            DropTable("dbo.Clientes");
        }
    }
}
