using Harvin.Models;
using System.Data.Entity.ModelConfiguration;

namespace Harvin.Configurations
{
    public class AdicionalConfiguration : EntityTypeConfiguration<Adicional>
    {
        //CONSTRUTOR DA CONFIG
        public AdicionalConfiguration()
        {
            ToTable("Adicional");
            HasKey(c => c.Id);
        }
    }
}