using Harvin.Models;
using System.Data.Entity.ModelConfiguration;

namespace Harvin.Configurations
{
    public class ClienteLoginConfiguration : EntityTypeConfiguration<ClienteLogin>
    {
        //CONSTRUTOR DA CONFIG
        public ClienteLoginConfiguration()
        {
            ToTable("ClienteLogin");
            HasKey(c => c.Id);

            HasRequired(p => p.Cliente).WithMany().Map(m => m.MapKey("ClienteId"));
        }
    }
}