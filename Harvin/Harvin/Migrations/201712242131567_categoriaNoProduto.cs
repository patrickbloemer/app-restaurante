namespace Harvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoriaNoProduto : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Produtos", "categoriaId");
            AddForeignKey("dbo.Produtos", "categoriaId", "dbo.Categorias", "CategoriaId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtos", "categoriaId", "dbo.Categorias");
            DropIndex("dbo.Produtos", new[] { "categoriaId" });
        }
    }
}
