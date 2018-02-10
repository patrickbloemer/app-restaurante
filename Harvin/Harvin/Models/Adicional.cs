using System.ComponentModel.DataAnnotations;

namespace Harvin.Models
{
    public class Adicional
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public double Valor { get; set; }
    }
}