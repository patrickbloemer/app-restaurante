namespace Harvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionaImagem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categorias", "imagem", c => c.String(nullable: false));
            AddColumn("dbo.Clientes", "imagem", c => c.String(nullable: false));
            AddColumn("dbo.Funcionarios", "imagem", c => c.String(nullable: false));
            AddColumn("dbo.Produtos", "imagem", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produtos", "imagem");
            DropColumn("dbo.Funcionarios", "imagem");
            DropColumn("dbo.Clientes", "imagem");
            DropColumn("dbo.Categorias", "imagem");
        }
    }
}
