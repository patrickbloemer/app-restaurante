namespace Harvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClasseHistoricoAtividade : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HistoricoDeAtividades",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        dataHorario = c.DateTime(nullable: false),
                        acao = c.String(),
                        funcionario_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Funcionarios", t => t.funcionario_id)
                .Index(t => t.funcionario_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HistoricoDeAtividades", "funcionario_id", "dbo.Funcionarios");
            DropIndex("dbo.HistoricoDeAtividades", new[] { "funcionario_id" });
            DropTable("dbo.HistoricoDeAtividades");
        }
    }
}
