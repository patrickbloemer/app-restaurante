namespace Harvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntitiesAtt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "nome", c => c.String(nullable: false));
            AlterColumn("dbo.Clientes", "sobrenome", c => c.String(nullable: false));
            AlterColumn("dbo.Clientes", "cpf", c => c.String(nullable: false));
            AlterColumn("dbo.Funcionarios", "nome", c => c.String(nullable: false));
            AlterColumn("dbo.Funcionarios", "sobrenome", c => c.String(nullable: false));
            AlterColumn("dbo.Funcionarios", "cpf", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Funcionarios", "cpf", c => c.String());
            AlterColumn("dbo.Funcionarios", "sobrenome", c => c.String());
            AlterColumn("dbo.Funcionarios", "nome", c => c.String());
            AlterColumn("dbo.Clientes", "cpf", c => c.String());
            AlterColumn("dbo.Clientes", "sobrenome", c => c.String());
            AlterColumn("dbo.Clientes", "nome", c => c.String());
        }
    }
}
