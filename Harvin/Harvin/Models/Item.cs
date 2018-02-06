using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Harvin.Models
{
    [Table("Item")]
    public class Item
    {
        [Key]
        public int Id { get; set; }

        public Produto Produto { get; set; }

        public int Quantidade { get; set; }

        public Pedido Pedido { get; set; }
    }
}