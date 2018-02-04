namespace Harvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tiradadadataentrega : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Pedidos", "horarioEntrega");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pedidos", "horarioEntrega", c => c.DateTime(nullable: false));
        }
    }
}
