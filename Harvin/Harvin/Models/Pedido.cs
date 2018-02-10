using System;
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

        public Pedido(DateTime dataCadastro, Funcionario func, bool pend = true, bool pagam = false)
        {
            HorarioPedido = dataCadastro;
            Funcionario = func;
            Pendencia = pend;
            Pagamento = pagam;
        }

        [Key]
        public int Id { get; set; }

        public Funcionario Funcionario { get; set; }

        public Cliente Cliente { get; set; }

        public DateTime HorarioPedido { get; set; }

        public DateTime HorarioFinalizacao { get; set; }

        public bool Pendencia { get; set; }

        public bool Pagamento { get; set; }
    }
}