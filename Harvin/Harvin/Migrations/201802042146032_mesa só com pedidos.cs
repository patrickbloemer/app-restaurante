namespace Harvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mesasócompedidos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Mesas", "cliente_id", "dbo.Clientes");
            DropIndex("dbo.Mesas", new[] { "cliente_id" });
            DropColumn("dbo.Mesas", "cliente_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Mesas", "cliente_id", c => c.Int());
            CreateIndex("dbo.Mesas", "cliente_id");
            AddForeignKey("dbo.Mesas", "cliente_id", "dbo.Clientes", "id");
        }
    }
}
