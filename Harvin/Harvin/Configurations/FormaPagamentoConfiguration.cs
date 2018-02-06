using Harvin.Models;
using System.Data.Entity.ModelConfiguration;

namespace Harvin.Configurations
{
    public class FormaPagamentoConfiguration : EntityTypeConfiguration<FormaPagamento>
    {
        //CONSTRUTOR DA CONFIG
        public FormaPagamentoConfiguration()
        {
            ToTable("FormaPagamento");
            HasKey(c => c.Id);
        }
    }
}