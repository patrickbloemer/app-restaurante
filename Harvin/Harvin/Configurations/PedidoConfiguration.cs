using Harvin.Models;
using System.Data.Entity.ModelConfiguration;

namespace Harvin.Configurations
{
    public class PedidoConfiguration : EntityTypeConfiguration<Pedido>
    {
        //CONSTRUTOR DA CONFIG
        public PedidoConfiguration()
        {
            ToTable("Pedido");
            HasKey(c => c.Id);

            Property(p => p.HorarioEntrega).IsOptional();
            HasOptional(p => p.Mesa).WithMany().Map(m => m.MapKey("ClienteId"));
            HasOptional(p => p.Funcionario).WithMany().Map(m => m.MapKey("FuncionarioId"));
        }
    }
}