using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Harvin.Models
{
    [Table("Itens")]
    public class Item
    {
        [Key]
        public int itemId { get; set; }
        public Produto produto { get; set; }
        public int quantidade { get; set; }
        public Pedido pedido { get; set; }
    }
}