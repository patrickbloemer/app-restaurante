using Harvin.Models;
using System.Data.Entity.ModelConfiguration;

namespace Harvin.Configurations
{
    public class DeliveryConfiguration : EntityTypeConfiguration<Delivery>
    {
        //CONSTRUTOR DA CONFIG
        public DeliveryConfiguration()
        {
            ToTable("Delivery");
            HasKey(c => c.Id);

            HasRequired(p => p.FormaPagamento).WithMany().Map(m => m.MapKey("FormaPagamentoId"));
            HasRequired(p => p.Pedido).WithMany().Map(m => m.MapKey("PedidoId"));
            HasRequired(p => p.FuncionarioEntrega).WithMany().Map(m => m.MapKey("FuncionarioEntregaId"));
        }
    }
}