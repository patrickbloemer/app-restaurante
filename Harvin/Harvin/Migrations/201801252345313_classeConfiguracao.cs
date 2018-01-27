namespace Harvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class classeConfiguracao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Configuracao", "primeiroHorario", c => c.Boolean(nullable: false));
            AddColumn("dbo.Configuracao", "primeiroHorarioInicio", c => c.DateTime(nullable: false));
            AddColumn("dbo.Configuracao", "primeiroHorarioFinal", c => c.DateTime(nullable: false));
            AddColumn("dbo.Configuracao", "segundoHorario", c => c.Boolean(nullable: false));
            AddColumn("dbo.Configuracao", "segundoHorarioInicio", c => c.DateTime(nullable: false));
            AddColumn("dbo.Configuracao", "segundoHorarioFinal", c => c.DateTime(nullable: false));
            DropColumn("dbo.Configuracao", "horarioFuncionamento");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Configuracao", "horarioFuncionamento", c => c.DateTime(nullable: false));
            DropColumn("dbo.Configuracao", "segundoHorarioFinal");
            DropColumn("dbo.Configuracao", "segundoHorarioInicio");
            DropColumn("dbo.Configuracao", "segundoHorario");
            DropColumn("dbo.Configuracao", "primeiroHorarioFinal");
            DropColumn("dbo.Configuracao", "primeiroHorarioInicio");
            DropColumn("dbo.Configuracao", "primeiroHorario");
        }
    }
}
