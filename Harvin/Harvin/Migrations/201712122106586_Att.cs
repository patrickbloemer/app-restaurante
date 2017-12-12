namespace Harvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Att : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cargos", "nome", c => c.String(nullable: false));
            AlterColumn("dbo.Cargos", "descricao", c => c.String(nullable: false));
            AlterColumn("dbo.Categorias", "nome", c => c.String(nullable: false));
            AlterColumn("dbo.Categorias", "descricao", c => c.String(nullable: false));
            AlterColumn("dbo.Clientes", "cep", c => c.String(nullable: false));
            AlterColumn("dbo.Clientes", "endereco", c => c.String(nullable: false));
            AlterColumn("dbo.Clientes", "complemento", c => c.String(nullable: false));
            AlterColumn("dbo.Clientes", "bairro", c => c.String(nullable: false));
            AlterColumn("dbo.Clientes", "cidade", c => c.String(nullable: false));
            AlterColumn("dbo.Clientes", "email", c => c.String(nullable: false));
            AlterColumn("dbo.Clientes", "senha", c => c.String(nullable: false));
            AlterColumn("dbo.FormasPagamentos", "nome", c => c.String(nullable: false));
            AlterColumn("dbo.FormasPagamentos", "descricao", c => c.String(nullable: false));
            AlterColumn("dbo.Funcionarios", "cep", c => c.String(nullable: false));
            AlterColumn("dbo.Funcionarios", "endereco", c => c.String(nullable: false));
            AlterColumn("dbo.Funcionarios", "complemento", c => c.String(nullable: false));
            AlterColumn("dbo.Funcionarios", "bairro", c => c.String(nullable: false));
            AlterColumn("dbo.Funcionarios", "cidade", c => c.String(nullable: false));
            AlterColumn("dbo.Funcionarios", "email", c => c.String(nullable: false));
            AlterColumn("dbo.Funcionarios", "senha", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Funcionarios", "senha", c => c.String());
            AlterColumn("dbo.Funcionarios", "email", c => c.String());
            AlterColumn("dbo.Funcionarios", "cidade", c => c.String());
            AlterColumn("dbo.Funcionarios", "bairro", c => c.String());
            AlterColumn("dbo.Funcionarios", "complemento", c => c.String());
            AlterColumn("dbo.Funcionarios", "endereco", c => c.String());
            AlterColumn("dbo.Funcionarios", "cep", c => c.String());
            AlterColumn("dbo.FormasPagamentos", "descricao", c => c.String());
            AlterColumn("dbo.FormasPagamentos", "nome", c => c.String());
            AlterColumn("dbo.Clientes", "senha", c => c.String());
            AlterColumn("dbo.Clientes", "email", c => c.String());
            AlterColumn("dbo.Clientes", "cidade", c => c.String());
            AlterColumn("dbo.Clientes", "bairro", c => c.String());
            AlterColumn("dbo.Clientes", "complemento", c => c.String());
            AlterColumn("dbo.Clientes", "endereco", c => c.String());
            AlterColumn("dbo.Clientes", "cep", c => c.String());
            AlterColumn("dbo.Categorias", "descricao", c => c.String());
            AlterColumn("dbo.Categorias", "nome", c => c.String());
            AlterColumn("dbo.Cargos", "descricao", c => c.String());
            AlterColumn("dbo.Cargos", "nome", c => c.String());
        }
    }
}
