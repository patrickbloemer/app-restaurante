using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Harvin.Models
{
    [Table("Pedido")]
    public class Pedido
    {
        public Pedido()
        {
        }

        public Pedido(DateTime dataCadastro, Funcionario func, int mesa, bool pend = true, bool pagam = false)
        {
            HorarioPedido = dataCadastro;
            Funcionario = func;
            Pendencia = pend;
            Pagamento = pagam;
            Mesa.Id = mesa;
        }

        [Key]
        public int Id { get; set; }

        public Mesa Mesa { get; set; }

        public Funcionario Funcionario { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Horário do Pedido")]
        public DateTime HorarioPedido { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Horário da entrega")]
        public DateTime HorarioEntrega { get; set; }

        [Display(Name = "Pendência")]
        public bool Pendencia { get; set; }

        [Display(Name = "Pagamento")]
        public bool Pagamento { get; set; }

        //public virtual List<Item> Itens { get; set; }
    }
}