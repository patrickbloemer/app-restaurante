namespace Harvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adicionadoMesaIdnoPedido : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pedidos", "Mesa_mesaId", "dbo.Mesas");
            DropIndex("dbo.Pedidos", new[] { "Mesa_mesaId" });
            RenameColumn(table: "dbo.Pedidos", name: "Mesa_mesaId", newName: "mesaId");
            AlterColumn("dbo.Pedidos", "mesaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Pedidos", "mesaId");
            AddForeignKey("dbo.Pedidos", "mesaId", "dbo.Mesas", "mesaId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pedidos", "mesaId", "dbo.Mesas");
            DropIndex("dbo.Pedidos", new[] { "mesaId" });
            AlterColumn("dbo.Pedidos", "mesaId", c => c.Int());
            RenameColumn(table: "dbo.Pedidos", name: "mesaId", newName: "Mesa_mesaId");
            CreateIndex("dbo.Pedidos", "Mesa_mesaId");
            AddForeignKey("dbo.Pedidos", "Mesa_mesaId", "dbo.Mesas", "mesaId");
        }
    }
}
