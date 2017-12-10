using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Harvin.Models {
    [Table("Mesas")]
    public class Mesa {
        [Key]
        public int mesaId { get; set; }
        public List<Pedido> pedidos { get; set; }
        public Cliente cliente { get; set; }
    }
}