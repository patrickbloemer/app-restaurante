namespace Harvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pedidoseclientesnamesa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mesas", "cliente_id", c => c.Int());
            CreateIndex("dbo.Pedidos", "mesaId");
            CreateIndex("dbo.Mesas", "cliente_id");
            AddForeignKey("dbo.Mesas", "cliente_id", "dbo.Clientes", "id");
            AddForeignKey("dbo.Pedidos", "mesaId", "dbo.Mesas", "mesaId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pedidos", "mesaId", "dbo.Mesas");
            DropForeignKey("dbo.Mesas", "cliente_id", "dbo.Clientes");
            DropIndex("dbo.Mesas", new[] { "cliente_id" });
            DropIndex("dbo.Pedidos", new[] { "mesaId" });
            DropColumn("dbo.Mesas", "cliente_id");
        }
    }
}
