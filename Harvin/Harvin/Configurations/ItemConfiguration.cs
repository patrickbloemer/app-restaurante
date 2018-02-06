using Harvin.Models;
using System.Data.Entity.ModelConfiguration;

namespace Harvin.Configurations
{
    public class ItemConfiguration : EntityTypeConfiguration<Item>
    {
        //CONSTRUTOR DA CONFIG
        public ItemConfiguration()
        {
            ToTable("Item");
            HasKey(c => c.Id);

            HasRequired(p => p.Produto).WithMany().Map(m => m.MapKey("ProdutoId"));
            HasRequired(p => p.Pedido).WithMany().Map(m => m.MapKey("PedidoId"));
        }
    }
}