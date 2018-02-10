using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Harvin.Models
{
    [Table("Mesa")]
    public class Mesa
    {
        [Key]
        public int Id { get; set; }

        public int NumeroMesa { get; set; }

        public Pedido Pedido { get; set; }
    }
}