using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Harvin.Models {
    [Table("Funcionarios")]
    public class Funcionario : Pessoa {
        public Cargo cargo { get; set; }
        //ADICIONADO
        [Display(Name = "Cargo")]
        public int cargoId { get; set; }
        [Display(Name = "Home")]
        public bool home { get; set; }
        [Display(Name = "Verificar Consumo")]
        public bool verificarConsumo { get; set; }
        [Display(Name = "Realizar Pedido")]
        public bool realizarPedido { get; set; }
        [Display(Name = "Pedidos Pendentes")]
        public bool pedidosPendentes { get; set; }
        [Display(Name = "Clientes")]
        public bool clientes { get; set; }
        [Display(Name = "Reservar Mesa")]
        public bool reservarMesa { get; set; }
        [Display(Name = "Configurações")]
        public bool configuracoes { get; set; }
        [Display(Name = "Relatórios")]
        public bool relatorios { get; set; }
    }
}