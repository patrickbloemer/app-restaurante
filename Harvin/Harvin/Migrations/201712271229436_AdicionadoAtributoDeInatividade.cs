namespace Harvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionadoAtributoDeInatividade : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cargos", "inativo", c => c.Boolean(nullable: false));
            AddColumn("dbo.Categorias", "inativo", c => c.Boolean(nullable: false));
            AddColumn("dbo.Clientes", "inativo", c => c.Boolean(nullable: false));
            AddColumn("dbo.FormasPagamentos", "inativo", c => c.Boolean(nullable: false));
            AddColumn("dbo.Funcionarios", "inativo", c => c.Boolean(nullable: false));
            AddColumn("dbo.Produtos", "inativo", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produtos", "inativo");
            DropColumn("dbo.Funcionarios", "inativo");
            DropColumn("dbo.FormasPagamentos", "inativo");
            DropColumn("dbo.Clientes", "inativo");
            DropColumn("dbo.Categorias", "inativo");
            DropColumn("dbo.Cargos", "inativo");
        }
    }
}
