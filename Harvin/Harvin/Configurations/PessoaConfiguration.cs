using Harvin.Models;
using System.Data.Entity.ModelConfiguration;

namespace Harvin.Configurations
{
    public class PessoaConfiguration : EntityTypeConfiguration<Pessoa>
    {
        //CONSTRUTOR DA CONFIG
        public PessoaConfiguration()
        {
            ToTable("Pessoa");
            HasKey(c => c.Id);
        }
    }
}