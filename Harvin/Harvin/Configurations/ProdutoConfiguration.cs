using Harvin.Models;
using System.Data.Entity.ModelConfiguration;

namespace Harvin.Configurations
{
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        //CONSTRUTOR DA CONFIG
        public ProdutoConfiguration()
        {
            ToTable("Produto");
            HasKey(c => c.Id);

            HasRequired(p => p.Categoria).WithMany().Map(m => m.MapKey("CategoriaId"));
        }
    }
}