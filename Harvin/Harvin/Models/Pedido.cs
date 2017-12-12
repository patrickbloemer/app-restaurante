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

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Horário do Pedido")]
        public DateTime horarioPedido { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Horário da Entrega")]
        public DateTime horarioEntrega { get; set; }

        public Funcionario funcionario { get; set; }
        
        [Display(Name = "Pendência")]
        public bool pendencia { get; set; }

        [Display(Name = "Pagamento")]
        public bool pagamento { get; set; }
    }
}