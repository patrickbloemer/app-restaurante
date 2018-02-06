using Harvin.Models;
using System.Data.Entity.ModelConfiguration;

namespace Harvin.Configurations
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        //CONSTRUTOR DA CONFIG
        public ClienteConfiguration()
        {
            ToTable("Cliente");
            HasKey(c => c.Id);
        }
    }
}