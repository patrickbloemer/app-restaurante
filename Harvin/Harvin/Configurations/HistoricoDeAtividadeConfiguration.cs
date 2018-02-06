using Harvin.Models;
using System.Data.Entity.ModelConfiguration;

namespace Harvin.Configurations
{
    public class HistoricoDeAtividadeConfiguration : EntityTypeConfiguration<HistoricoDeAtividade>
    {
        //CONSTRUTOR DA CONFIG
        public HistoricoDeAtividadeConfiguration()
        {
            ToTable("HistoricoDeAtividade");
            HasKey(c => c.Id);

            HasRequired(p => p.Funcionario).WithMany().Map(m => m.MapKey("FuncionarioId"));
        }
    }
}