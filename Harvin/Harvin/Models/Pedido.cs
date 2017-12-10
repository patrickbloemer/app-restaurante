using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Harvin.Models {
    [Table("Pedidos")]
    public class Pedido {
        [Key]
        public int pedidoId { get; set; }
        public List<Item> itens { get; set; }
        public DateTime horarioPedido { get; set; }
        public DateTime horarioEntrega { get; set; }
        public Funcionario funcionario { get; set; }
        public bool pendencia { get; set; }
        public bool pagamento { get; set; }
    }
}