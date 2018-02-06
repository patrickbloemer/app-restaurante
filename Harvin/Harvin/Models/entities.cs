using Harvin.Configurations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Harvin.Models
{
    public class Entities : DbContext
    {
        #region [ Entities ]
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ClienteLogin> ClienteLogin { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<FormaPagamento> FormaPagamentos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<FuncionarioLogin> FuncionarioLogin { get; set; }
        public DbSet<Item> Itens { get; set; }
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<HistoricoDeAtividade> HistoricoDeAtividades { get; set; }
        public DbSet<Configuracao> Configuracoes { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //ADICIONA AS CONFIGURAÇÕES NAS SUAS RESPECTIVAS MODELS
            #region [ Configs ]
            modelBuilder.Configurations.Add(new CargoConfiguration());
            modelBuilder.Configurations.Add(new CategoriaConfiguration());
            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new ConfiguracaoConfiguration());
            modelBuilder.Configurations.Add(new DeliveryConfiguration());
            modelBuilder.Configurations.Add(new FormaPagamentoConfiguration());
            modelBuilder.Configurations.Add(new FuncionarioConfiguration());
            modelBuilder.Configurations.Add(new FuncionarioLoginConfiguration());
            modelBuilder.Configurations.Add(new HistoricoDeAtividadeConfiguration());
            modelBuilder.Configurations.Add(new ItemConfiguration());
            modelBuilder.Configurations.Add(new MesaConfiguration());
            modelBuilder.Configurations.Add(new PedidoConfiguration());
            modelBuilder.Configurations.Add(new PessoaConfiguration());
            modelBuilder.Configurations.Add(new ProdutoConfiguration());
            modelBuilder.Configurations.Add(new ReservaConfiguration());
            #endregion

            //CONFIGURAÇÕES PADRÃO CASO NÃO DE OVERRIDE DELAS NAS CONFIGURAÇÕES DE CADA MODEL
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Properties<string>().Configure(config => config.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(config => config.HasMaxLength(150));
            modelBuilder.Properties<decimal>().Configure(config => config.HasPrecision(10, 2));
        }

    }

}