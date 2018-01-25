namespace Harvin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class criarbanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cargos",
                c => new
                    {
                        cargoId = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false),
                        descricao = c.String(nullable: false),
                        inativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.cargoId);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false),
                        descricao = c.String(nullable: false),
                        imagem = c.String(nullable: false),
                        inativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
            CreateTable(
                "dbo.ClienteLogins",
                c => new
                    {
                        clienteLoginId = c.Int(nullable: false, identity: true),
                        dataHorarioLogin = c.DateTime(nullable: false),
                        sessao = c.String(),
                        cliente_id = c.Int(),
                    })
                .PrimaryKey(t => t.clienteLoginId)
                .ForeignKey("dbo.Clientes", t => t.cliente_id)
                .Index(t => t.cliente_id);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false),
                        sobrenome = c.String(nullable: false),
                        cpf = c.String(nullable: false),
                        telefone = c.String(),
                        dataDeNascimento = c.DateTime(nullable: false),
                        cep = c.String(nullable: false),
                        endereco = c.String(nullable: false),
                        complemento = c.String(nullable: false),
                        bairro = c.String(nullable: false),
                        cidade = c.String(nullable: false),
                        imagem = c.String(nullable: false),
                        email = c.String(nullable: false),
                        senha = c.String(nullable: false),
                        inativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Deliveries",
                c => new
                    {
                        pedidoId = c.Int(nullable: false, identity: true),
                        Pagamento = c.Boolean(nullable: false),
                        cliente_id = c.Int(),
                        formaPagamento_formaPagamentoId = c.Int(),
                        funcionarioEntrega_id = c.Int(),
                        pedido_pedidoId = c.Int(),
                    })
                .PrimaryKey(t => t.pedidoId)
                .ForeignKey("dbo.Clientes", t => t.cliente_id)
                .ForeignKey("dbo.FormasPagamentos", t => t.formaPagamento_formaPagamentoId)
                .ForeignKey("dbo.Funcionarios", t => t.funcionarioEntrega_id)
                .ForeignKey("dbo.Pedidos", t => t.pedido_pedidoId)
                .Index(t => t.cliente_id)
                .Index(t => t.formaPagamento_formaPagamentoId)
                .Index(t => t.funcionarioEntrega_id)
                .Index(t => t.pedido_pedidoId);
            
            CreateTable(
                "dbo.FormasPagamentos",
                c => new
                    {
                        formaPagamentoId = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false),
                        descricao = c.String(nullable: false),
                        inativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.formaPagamentoId);
            
            CreateTable(
                "dbo.Funcionarios",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        cargoId = c.Int(nullable: false),
                        home = c.Boolean(nullable: false),
                        verificarConsumo = c.Boolean(nullable: false),
                        realizarPedido = c.Boolean(nullable: false),
                        pedidosPendentes = c.Boolean(nullable: false),
                        clientes = c.Boolean(nullable: false),
                        reservarMesa = c.Boolean(nullable: false),
                        configuracoes = c.Boolean(nullable: false),
                        relatorios = c.Boolean(nullable: false),
                        nome = c.String(nullable: false),
                        sobrenome = c.String(nullable: false),
                        cpf = c.String(nullable: false),
                        telefone = c.String(),
                        dataDeNascimento = c.DateTime(nullable: false),
                        cep = c.String(nullable: false),
                        endereco = c.String(nullable: false),
                        complemento = c.String(nullable: false),
                        bairro = c.String(nullable: false),
                        cidade = c.String(nullable: false),
                        imagem = c.String(nullable: false),
                        email = c.String(nullable: false),
                        senha = c.String(nullable: false),
                        inativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Cargos", t => t.cargoId, cascadeDelete: true)
                .Index(t => t.cargoId);
            
            CreateTable(
                "dbo.Pedidos",
                c => new
                    {
                        pedidoId = c.Int(nullable: false, identity: true),
                        horarioPedido = c.DateTime(nullable: false),
                        horarioEntrega = c.DateTime(nullable: false),
                        pendencia = c.Boolean(nullable: false),
                        pagamento = c.Boolean(nullable: false),
                        funcionario_id = c.Int(),
                        Mesa_mesaId = c.Int(),
                    })
                .PrimaryKey(t => t.pedidoId)
                .ForeignKey("dbo.Funcionarios", t => t.funcionario_id)
                .ForeignKey("dbo.Mesas", t => t.Mesa_mesaId)
                .Index(t => t.funcionario_id)
                .Index(t => t.Mesa_mesaId);
            
            CreateTable(
                "dbo.Itens",
                c => new
                    {
                        itemId = c.Int(nullable: false, identity: true),
                        quantidade = c.Int(nullable: false),
                        produto_id = c.Int(),
                        Pedido_pedidoId = c.Int(),
                    })
                .PrimaryKey(t => t.itemId)
                .ForeignKey("dbo.Produtos", t => t.produto_id)
                .ForeignKey("dbo.Pedidos", t => t.Pedido_pedidoId)
                .Index(t => t.produto_id)
                .Index(t => t.Pedido_pedidoId);
            
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false),
                        valorUnitario = c.Double(nullable: false),
                        quantidadeMinimaEstoque = c.Int(nullable: false),
                        quantidadeMaximaEstoque = c.Int(nullable: false),
                        quantidadeAtualEstoque = c.Int(nullable: false),
                        descricao = c.String(nullable: false),
                        estocavel = c.Boolean(nullable: false),
                        categoriaId = c.Int(nullable: false),
                        imagem = c.String(nullable: false),
                        comentarios = c.String(nullable: false),
                        inativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categorias", t => t.categoriaId, cascadeDelete: true)
                .Index(t => t.categoriaId);
            
            CreateTable(
                "dbo.FuncionarioLogins",
                c => new
                    {
                        funcionarioLoginId = c.Int(nullable: false, identity: true),
                        dataHorarioLogin = c.DateTime(nullable: false),
                        sessao = c.String(),
                        funcionario_id = c.Int(),
                    })
                .PrimaryKey(t => t.funcionarioLoginId)
                .ForeignKey("dbo.Funcionarios", t => t.funcionario_id)
                .Index(t => t.funcionario_id);
            
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
            
            CreateTable(
                "dbo.Mesas",
                c => new
                    {
                        mesaId = c.Int(nullable: false, identity: true),
                        cliente_id = c.Int(),
                    })
                .PrimaryKey(t => t.mesaId)
                .ForeignKey("dbo.Clientes", t => t.cliente_id)
                .Index(t => t.cliente_id);
            
            CreateTable(
                "dbo.Reservas",
                c => new
                    {
                        reservaId = c.Int(nullable: false, identity: true),
                        data = c.DateTime(nullable: false),
                        horario = c.DateTime(nullable: false),
                        quantidadeClientes = c.Int(nullable: false),
                        cliente_id = c.Int(),
                    })
                .PrimaryKey(t => t.reservaId)
                .ForeignKey("dbo.Clientes", t => t.cliente_id)
                .Index(t => t.cliente_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservas", "cliente_id", "dbo.Clientes");
            DropForeignKey("dbo.Pedidos", "Mesa_mesaId", "dbo.Mesas");
            DropForeignKey("dbo.Mesas", "cliente_id", "dbo.Clientes");
            DropForeignKey("dbo.HistoricoDeAtividades", "funcionario_id", "dbo.Funcionarios");
            DropForeignKey("dbo.FuncionarioLogins", "funcionario_id", "dbo.Funcionarios");
            DropForeignKey("dbo.Deliveries", "pedido_pedidoId", "dbo.Pedidos");
            DropForeignKey("dbo.Itens", "Pedido_pedidoId", "dbo.Pedidos");
            DropForeignKey("dbo.Itens", "produto_id", "dbo.Produtos");
            DropForeignKey("dbo.Produtos", "categoriaId", "dbo.Categorias");
            DropForeignKey("dbo.Pedidos", "funcionario_id", "dbo.Funcionarios");
            DropForeignKey("dbo.Deliveries", "funcionarioEntrega_id", "dbo.Funcionarios");
            DropForeignKey("dbo.Funcionarios", "cargoId", "dbo.Cargos");
            DropForeignKey("dbo.Deliveries", "formaPagamento_formaPagamentoId", "dbo.FormasPagamentos");
            DropForeignKey("dbo.Deliveries", "cliente_id", "dbo.Clientes");
            DropForeignKey("dbo.ClienteLogins", "cliente_id", "dbo.Clientes");
            DropIndex("dbo.Reservas", new[] { "cliente_id" });
            DropIndex("dbo.Mesas", new[] { "cliente_id" });
            DropIndex("dbo.HistoricoDeAtividades", new[] { "funcionario_id" });
            DropIndex("dbo.FuncionarioLogins", new[] { "funcionario_id" });
            DropIndex("dbo.Produtos", new[] { "categoriaId" });
            DropIndex("dbo.Itens", new[] { "Pedido_pedidoId" });
            DropIndex("dbo.Itens", new[] { "produto_id" });
            DropIndex("dbo.Pedidos", new[] { "Mesa_mesaId" });
            DropIndex("dbo.Pedidos", new[] { "funcionario_id" });
            DropIndex("dbo.Funcionarios", new[] { "cargoId" });
            DropIndex("dbo.Deliveries", new[] { "pedido_pedidoId" });
            DropIndex("dbo.Deliveries", new[] { "funcionarioEntrega_id" });
            DropIndex("dbo.Deliveries", new[] { "formaPagamento_formaPagamentoId" });
            DropIndex("dbo.Deliveries", new[] { "cliente_id" });
            DropIndex("dbo.ClienteLogins", new[] { "cliente_id" });
            DropTable("dbo.Reservas");
            DropTable("dbo.Mesas");
            DropTable("dbo.HistoricoDeAtividades");
            DropTable("dbo.FuncionarioLogins");
            DropTable("dbo.Produtos");
            DropTable("dbo.Itens");
            DropTable("dbo.Pedidos");
            DropTable("dbo.Funcionarios");
            DropTable("dbo.FormasPagamentos");
            DropTable("dbo.Deliveries");
            DropTable("dbo.Clientes");
            DropTable("dbo.ClienteLogins");
            DropTable("dbo.Categorias");
            DropTable("dbo.Cargos");
        }
    }
}
