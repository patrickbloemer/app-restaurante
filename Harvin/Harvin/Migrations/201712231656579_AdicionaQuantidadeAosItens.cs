namespace Harvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionaQuantidadeAosItens : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Itens", "quantidade", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Itens", "quantidade");
        }
    }
}
