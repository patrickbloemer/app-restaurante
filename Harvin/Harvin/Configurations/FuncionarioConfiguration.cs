using Harvin.Models;
using System.Data.Entity.ModelConfiguration;

namespace Harvin.Configurations
{
    public class FuncionarioConfiguration : EntityTypeConfiguration<Funcionario>
    {
        //CONSTRUTOR DA CONFIG
        public FuncionarioConfiguration()
        {
            ToTable("Funcionario");
            HasKey(c => c.Id);

            //VINCULA O CARGO A UMA FOREIGN KEY OPCIONAL CHAMADA CARGOID NO FUNCIONÁRIO
            HasOptional(p => p.Cargo).WithMany().Map(m => m.MapKey("CargoId"));
        }
    }
}