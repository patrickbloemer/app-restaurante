using Harvin.Models;
using System.Data.Entity.ModelConfiguration;

namespace Harvin.Configurations
{
    public class CargoConfiguration : EntityTypeConfiguration<Cargo>
    {
        //CONSTRUTOR DA CONFIG
        public CargoConfiguration()
        {
            ToTable("Cargo");
            HasKey(c => c.Id);
        }
    }
}