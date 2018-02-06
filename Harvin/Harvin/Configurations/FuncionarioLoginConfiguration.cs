using Harvin.Models;
using System.Data.Entity.ModelConfiguration;

namespace Harvin.Configurations
{
    public class FuncionarioLoginConfiguration : EntityTypeConfiguration<FuncionarioLogin>
    {
        //CONSTRUTOR DA CONFIG
        public FuncionarioLoginConfiguration()
        {
            ToTable("FuncionarioLogin");
            HasKey(c => c.Id);

            HasRequired(p => p.Funcionario).WithMany().Map(m => m.MapKey("FuncionarioId"));
        }
    }
}