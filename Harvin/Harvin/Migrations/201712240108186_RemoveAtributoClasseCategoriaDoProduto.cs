namespace Harvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAtributoClasseCategoriaDoProduto : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Produtos", "categoriaId", "dbo.Categorias");
            DropIndex("dbo.Produtos", new[] { "categoriaId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Produtos", "categoriaId");
            AddForeignKey("dbo.Produtos", "categoriaId", "dbo.Categorias", "CategoriaId", cascadeDelete: true);
        }
    }
}
