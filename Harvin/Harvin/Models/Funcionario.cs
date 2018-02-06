using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Harvin.Models
{
    [Table("Funcionario")]
    public class Funcionario : Pessoa
    {
        public Cargo Cargo { get; set; }

        [Display(Name = "Home")]
        public bool Home { get; set; }

        [Display(Name = "Verificar Consumo")]
        public bool VerificarConsumo { get; set; }

        [Display(Name = "Realizar Pedido")]
        public bool RealizarPedido { get; set; }

        [Display(Name = "Pedidos Pendentes")]
        public bool PedidosPendentes { get; set; }

        [Display(Name = "Clientes")]
        public bool Clientes { get; set; }

        [Display(Name = "Reservar Mesa")]
        public bool ReservarMesa { get; set; }

        [Display(Name = "Configurações")]
        public bool Configuracoes { get; set; }

        [Display(Name = "Relatórios")]
        public bool Relatorios { get; set; }
    }
}