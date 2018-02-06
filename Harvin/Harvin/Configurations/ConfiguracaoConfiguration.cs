using Harvin.Models;
using System.Data.Entity.ModelConfiguration;

namespace Harvin.Configurations
{
    public class ConfiguracaoConfiguration : EntityTypeConfiguration<Configuracao>
    {
        //CONSTRUTOR DA CONFIG
        public ConfiguracaoConfiguration()
        {
            ToTable("Configuracao");
            HasKey(c => c.Id);
        }
    }
}