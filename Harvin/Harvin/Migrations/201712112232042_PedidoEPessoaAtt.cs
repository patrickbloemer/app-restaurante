namespace Harvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PedidoEPessoaAtt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Produtos", "nome", c => c.String(nullable: false));
            AlterColumn("dbo.Produtos", "descricao", c => c.String(nullable: false));
            AlterColumn("dbo.Produtos", "comentarios", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produtos", "comentarios", c => c.String());
            AlterColumn("dbo.Produtos", "descricao", c => c.String());
            AlterColumn("dbo.Produtos", "nome", c => c.String());
        }
    }
}
