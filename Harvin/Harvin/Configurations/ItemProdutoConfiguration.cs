using Harvin.Models;
using System.Data.Entity.ModelConfiguration;

namespace Harvin.Configurations
{
    public class ItemAdicionalConfiguration : EntityTypeConfiguration<ItemAdicional>
    {
        //CONSTRUTOR DA CONFIG
        public ItemAdicionalConfiguration()
        {
            ToTable("ItemAdicional");
            HasKey(c => c.Id);

            HasRequired(p => p.Adicional).WithMany().Map(m => m.MapKey("AdicionalId"));
            HasRequired(p => p.Item).WithMany().Map(m => m.MapKey("ItemId"));
        }
    }
}