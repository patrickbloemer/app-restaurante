namespace Harvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class harvinbanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cargo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 150, unicode: false),
                        Inativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 150, unicode: false),
                        Imagem = c.String(nullable: false, maxLength: 150, unicode: false),
                        Inativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClienteLogin",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataHorarioLogin = c.DateTime(nullable: false),
                        Sessao = c.String(maxLength: 150, unicode: false),
                        Cliente_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.Cliente_Id)
                .Index(t => t.Cliente_Id);
            
            CreateTable(
                "dbo.Pessoa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                        Sobrenome = c.String(nullable: false, maxLength: 150, unicode: false),
                        Cpf = c.String(nullable: false, maxLength: 150, unicode: false),
                        Telefone = c.String(maxLength: 150, unicode: false),
                        DataDeNascimento = c.DateTime(nullable: false),
                        Cep = c.String(nullable: false, maxLength: 150, unicode: false),
                        Endereco = c.String(nullable: false, maxLength: 150, unicode: false),
                        Complemento = c.String(nullable: false, maxLength: 150, unicode: false),
                        Bairro = c.String(nullable: false, maxLength: 150, unicode: false),
                        Cidade = c.String(nullable: false, maxLength: 150, unicode: false),
                        Imagem = c.String(nullable: false, maxLength: 150, unicode: false),
                        ImagemByte = c.Binary(),
                        Email = c.String(nullable: false, maxLength: 150, unicode: false),
                        Senha = c.String(nullable: false, maxLength: 150, unicode: false),
                        Inativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Configuracao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AutorizarPedidos = c.Boolean(nullable: false),
                        AutorizarReservas = c.Boolean(nullable: false),
                        PrimeiroHorario = c.Boolean(nullable: false),
                        PrimeiroHorarioInicio = c.DateTime(nullable: false),
                        PrimeiroHorarioFinal = c.DateTime(nullable: false),
                        SegundoHorario = c.DateTime(nullable: false),
                        SegundoHorarioInicio = c.DateTime(nullable: false),
                        SegundoHorarioFinal = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Delivery",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Troco = c.Boolean(nullable: false),
                        TrocoValor = c.Double(nullable: false),
                        FormaPagamentoId = c.Int(nullable: false),
                        FuncionarioEntregaId = c.Int(nullable: false),
                        PedidoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FormaPagamento", t => t.FormaPagamentoId, cascadeDelete: true)
                .ForeignKey("dbo.Funcionario", t => t.FuncionarioEntregaId)
                .ForeignKey("dbo.Pedido", t => t.PedidoId, cascadeDelete: true)
                .Index(t => t.FormaPagamentoId)
                .Index(t => t.FuncionarioEntregaId)
                .Index(t => t.PedidoId);
            
            CreateTable(
                "dbo.FormaPagamento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 150, unicode: false),
                        Inativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HorarioPedido = c.DateTime(nullable: false),
                        HorarioFinalizacao = c.DateTime(nullable: false),
                        Pendencia = c.Boolean(nullable: false),
                        Pagamento = c.Boolean(nullable: false),
                        ClienteId = c.Int(),
                        FuncionarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .ForeignKey("dbo.Funcionario", t => t.FuncionarioId)
                .Index(t => t.ClienteId)
                .Index(t => t.FuncionarioId);
            
            CreateTable(
                "dbo.FuncionarioLogin",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataHorarioLogin = c.DateTime(nullable: false),
                        Sessao = c.String(maxLength: 150, unicode: false),
                        FuncionarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Funcionario", t => t.FuncionarioId)
                .Index(t => t.FuncionarioId);
            
            CreateTable(
                "dbo.HistoricoDeAtividade",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataHorario = c.DateTime(nullable: false),
                        Acao = c.String(maxLength: 150, unicode: false),
                        FuncionarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Funcionario", t => t.FuncionarioId)
                .Index(t => t.FuncionarioId);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantidade = c.Int(nullable: false),
                        PedidoId = c.Int(nullable: false),
                        ProdutoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pedido", t => t.PedidoId, cascadeDelete: true)
                .ForeignKey("dbo.Produto", t => t.ProdutoId, cascadeDelete: true)
                .Index(t => t.PedidoId)
                .Index(t => t.ProdutoId);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 150, unicode: false),
                        ValorUnitario = c.Double(nullable: false),
                        QuantidadeMinimaEstoque = c.Int(nullable: false),
                        QuantidadeMaximaEstoque = c.Int(nullable: false),
                        QuantidadeAtualEstoque = c.Int(nullable: false),
                        Descricao = c.String(maxLength: 150, unicode: false),
                        Estocavel = c.Boolean(nullable: false),
                        Pizza = c.Boolean(nullable: false),
                        Imagem = c.String(maxLength: 150, unicode: false),
                        Comentario = c.String(maxLength: 150, unicode: false),
                        Inativo = c.Boolean(nullable: false),
                        CategoriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categoria", t => t.CategoriaId, cascadeDelete: true)
                .Index(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Mesa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumeroMesa = c.Int(nullable: false),
                        PedidoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pedido", t => t.PedidoId, cascadeDelete: true)
                .Index(t => t.PedidoId);
            
            CreateTable(
                "dbo.Reserva",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataCadastro = c.DateTime(nullable: false),
                        HorarioEntrega = c.DateTime(nullable: false),
                        QuantidadeClientes = c.Int(nullable: false),
                        Preparada = c.Boolean(nullable: false),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Newsletter = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pessoa", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Funcionario",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        CargoId = c.Int(),
                        Home = c.Boolean(nullable: false),
                        Bi = c.Boolean(nullable: false),
                        Relatorios = c.Boolean(nullable: false),
                        ConsultarFuncionarios = c.Boolean(nullable: false),
                        ManipularFuncionarios = c.Boolean(nullable: false),
                        ManipularCargos = c.Boolean(nullable: false),
                        ConsultarCargos = c.Boolean(nullable: false),
                        ConsultarCategorias = c.Boolean(nullable: false),
                        ManipularCategorias = c.Boolean(nullable: false),
                        ManipularProdutos = c.Boolean(nullable: false),
                        ConsultarPedidos = c.Boolean(nullable: false),
                        ManipularPedidos = c.Boolean(nullable: false),
                        ConsultarReservas = c.Boolean(nullable: false),
                        ManipularReservas = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pessoa", t => t.Id)
                .ForeignKey("dbo.Cargo", t => t.CargoId)
                .Index(t => t.Id)
                .Index(t => t.CargoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Funcionario", "CargoId", "dbo.Cargo");
            DropForeignKey("dbo.Funcionario", "Id", "dbo.Pessoa");
            DropForeignKey("dbo.Cliente", "Id", "dbo.Pessoa");
            DropForeignKey("dbo.Reserva", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Mesa", "PedidoId", "dbo.Pedido");
            DropForeignKey("dbo.Item", "ProdutoId", "dbo.Produto");
            DropForeignKey("dbo.Produto", "CategoriaId", "dbo.Categoria");
            DropForeignKey("dbo.Item", "PedidoId", "dbo.Pedido");
            DropForeignKey("dbo.HistoricoDeAtividade", "FuncionarioId", "dbo.Funcionario");
            DropForeignKey("dbo.FuncionarioLogin", "FuncionarioId", "dbo.Funcionario");
            DropForeignKey("dbo.Delivery", "PedidoId", "dbo.Pedido");
            DropForeignKey("dbo.Pedido", "FuncionarioId", "dbo.Funcionario");
            DropForeignKey("dbo.Pedido", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Delivery", "FuncionarioEntregaId", "dbo.Funcionario");
            DropForeignKey("dbo.Delivery", "FormaPagamentoId", "dbo.FormaPagamento");
            DropForeignKey("dbo.ClienteLogin", "Cliente_Id", "dbo.Cliente");
            DropIndex("dbo.Funcionario", new[] { "CargoId" });
            DropIndex("dbo.Funcionario", new[] { "Id" });
            DropIndex("dbo.Cliente", new[] { "Id" });
            DropIndex("dbo.Reserva", new[] { "ClienteId" });
            DropIndex("dbo.Mesa", new[] { "PedidoId" });
            DropIndex("dbo.Produto", new[] { "CategoriaId" });
            DropIndex("dbo.Item", new[] { "ProdutoId" });
            DropIndex("dbo.Item", new[] { "PedidoId" });
            DropIndex("dbo.HistoricoDeAtividade", new[] { "FuncionarioId" });
            DropIndex("dbo.FuncionarioLogin", new[] { "FuncionarioId" });
            DropIndex("dbo.Pedido", new[] { "FuncionarioId" });
            DropIndex("dbo.Pedido", new[] { "ClienteId" });
            DropIndex("dbo.Delivery", new[] { "PedidoId" });
            DropIndex("dbo.Delivery", new[] { "FuncionarioEntregaId" });
            DropIndex("dbo.Delivery", new[] { "FormaPagamentoId" });
            DropIndex("dbo.ClienteLogin", new[] { "Cliente_Id" });
            DropTable("dbo.Funcionario");
            DropTable("dbo.Cliente");
            DropTable("dbo.Reserva");
            DropTable("dbo.Mesa");
            DropTable("dbo.Produto");
            DropTable("dbo.Item");
            DropTable("dbo.HistoricoDeAtividade");
            DropTable("dbo.FuncionarioLogin");
            DropTable("dbo.Pedido");
            DropTable("dbo.FormaPagamento");
            DropTable("dbo.Delivery");
            DropTable("dbo.Configuracao");
            DropTable("dbo.Pessoa");
            DropTable("dbo.ClienteLogin");
            DropTable("dbo.Categoria");
            DropTable("dbo.Cargo");
        }
    }
}
