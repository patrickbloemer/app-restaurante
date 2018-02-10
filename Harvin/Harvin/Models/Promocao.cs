using System.ComponentModel.DataAnnotations;

namespace Harvin.Models
{
    public class Promocao
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Imagem { get; set; }

        public Funcionario Funcionario { get; set; }
    }
}