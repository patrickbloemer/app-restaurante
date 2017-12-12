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

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Data da Reserva")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime data { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Horário da Reserva")]
        public DateTime horario { get; set; }

        [Display(Name = "Quantidade de Clientes")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int quantidadeClientes { get; set; }
    }
}