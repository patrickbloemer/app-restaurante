using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Harvin.Models {
    [Table("Reservas")]
    public class Reserva {
        [Key]
        public int reservaId { get; set; }
        public Cliente cliente { get; set; }
        public DateTime data { get; set; }
        public DateTime horario { get; set; }

        [Display(Name = "Quantidade de Clientes")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int quantidadeClientes { get; set; }
    }
}