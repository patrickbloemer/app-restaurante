using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Harvin.Models
{
    [Table("Pedidos")]
    public class Pedido
    {

        public Pedido()
        {

        }

        public Pedido(DateTime dataCadastro, Funcionario func, int mesa, bool pend = true, bool pagam = false)
        {
            horarioPedido = dataCadastro;
            funcionario = func;
            pendencia = pend;
            pagamento = pagam;
            mesaId = mesa;
        }

        [Key]
        public int pedidoId { get; set; }

        public int mesaId { get; set; }

        public List<Item> itens { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Horário do Pedido")]
        public DateTime horarioPedido { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Horário da entrega")]
        public DateTime horarioEntrega { get; set; }

        public Funcionario funcionario { get; set; }

        [Display(Name = "Pendência")]
        public bool pendencia { get; set; }

        [Display(Name = "Pagamento")]
        public bool pagamento { get; set; }
    }
}