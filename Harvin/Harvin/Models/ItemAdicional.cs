using System.ComponentModel.DataAnnotations;

namespace Harvin.Models
{
    public class ItemAdicional
    {
        [Key]
        public int Id { get; set; }

        public Item Item { get; set; }

        public Adicional Adicional { get; set; }

        public string Comentario { get; set; }
    }
}