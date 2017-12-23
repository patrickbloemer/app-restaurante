using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Harvin.Models {
    [Table("Itens")]
    public class Item {
        [Key]
        public int itemId { get; set; }
        public Produto produto { get; set; }
        public int quantidade { get; set; }
    }
}