using Harvin.Models;
using System.Data.Entity.ModelConfiguration;

namespace Harvin.Configurations
{
    public class PromocaoConfiguration : EntityTypeConfiguration<Promocao>
    {
        //CONSTRUTOR DA CONFIG
        public PromocaoConfiguration()
        {
            ToTable("Promocao");
            HasKey(c => c.Id);

            HasRequired(p => p.Funcionario).WithMany().Map(m => m.MapKey("FuncionarioId"));
        }
    }
}