namespace Harvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class horarioentrega : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedidos", "horarioEntrega", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pedidos", "horarioEntrega");
        }
    }
}
