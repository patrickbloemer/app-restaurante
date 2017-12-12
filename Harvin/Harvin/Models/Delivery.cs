using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Harvin.Models {
    [Table("Deliveries")]
    public class Delivery {
        [Key]
        public int pedidoId { get; set; }
        public Pedido pedido { get; set; }
        public Cliente cliente { get; set; }
        public Funcionario funcionarioEntrega { get; set; }
        public FormaPagamento formaPagamento { get; set; }

        [Display(Name = "Pagamento")]
        public bool Pagamento { get; set; }
    }
}