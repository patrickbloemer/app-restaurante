using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Harvin.Models
{
    [Table("Deliveriy")]
    public class Delivery {

        [Key]
        public int Id { get; set; }

        public Pedido Pedido { get; set; }

        public Funcionario FuncionarioEntrega { get; set; }

        public FormaPagamento FormaPagamento { get; set; }

        public bool Troco { get; set; }

        public double TrocoValor { get; set; }
    }
}