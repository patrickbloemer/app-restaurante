using Harvin.Models;
using System.Data.Entity.ModelConfiguration;

namespace Harvin.Configurations
{
    public class CategoriaConfiguration : EntityTypeConfiguration<Categoria>
    {
        //CONSTRUTOR DA CONFIG
        public CategoriaConfiguration()
        {
            ToTable("Categoria");
            HasKey(c => c.Id);
        }
    }
}