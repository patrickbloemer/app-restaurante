using Harvin.Models;
using System.Data.Entity.ModelConfiguration;

namespace Harvin.Configurations
{
    public class ReservaConfiguration : EntityTypeConfiguration<Reserva>
    {
        //CONSTRUTOR DA CONFIG
        public ReservaConfiguration()
        {
            ToTable("Reserva");
            HasKey(c => c.Id);

            HasRequired(p => p.Cliente).WithMany().Map(m => m.MapKey("ClienteId"));
        }
    }
}