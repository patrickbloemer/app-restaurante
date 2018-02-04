namespace Harvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MESA : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Mesas", "cliente_id", "dbo.Clientes");
            DropForeignKey("dbo.Pedidos", "mesaId", "dbo.Mesas");
            DropIndex("dbo.Pedidos", new[] { "mesaId" });
            DropIndex("dbo.Mesas", new[] { "cliente_id" });
            DropColumn("dbo.Mesas", "cliente_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Mesas", "cliente_id", c => c.Int());
            CreateIndex("dbo.Mesas", "cliente_id");
            CreateIndex("dbo.Pedidos", "mesaId");
            AddForeignKey("dbo.Pedidos", "mesaId", "dbo.Mesas", "mesaId", cascadeDelete: true);
            AddForeignKey("dbo.Mesas", "cliente_id", "dbo.Clientes", "id");
        }
    }
}
