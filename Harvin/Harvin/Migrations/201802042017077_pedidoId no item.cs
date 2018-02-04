namespace Harvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pedidoIdnoitem : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Itens", new[] { "Pedido_pedidoId" });
            CreateIndex("dbo.Itens", "pedido_pedidoId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Itens", new[] { "pedido_pedidoId" });
            CreateIndex("dbo.Itens", "Pedido_pedidoId");
        }
    }
}
