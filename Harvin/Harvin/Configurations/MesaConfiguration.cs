using Harvin.Models;
using System.Data.Entity.ModelConfiguration;

namespace Harvin.Configurations
{
    public class MesaConfiguration : EntityTypeConfiguration<Mesa>
    {
        //CONSTRUTOR DA CONFIG
        public MesaConfiguration()
        {
            ToTable("Mesa");
            HasKey(c => c.Id);

            HasRequired(p => p.Pedido).WithMany().Map(m => m.MapKey("PedidoId"));
        }
    }
}