namespace Harvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asddas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mesas", "numeroMesa", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Mesas", "numeroMesa");
        }
    }
}
