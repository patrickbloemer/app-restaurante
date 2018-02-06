using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Harvin.Models
{
    [Table("Reserva")]
    public class Reserva
    {
        [Key]
        public int Id { get; set; }

        public Cliente Cliente { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Data da Reserva")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Horário da Reserva")]
        public DateTime Horario { get; set; }

        [Display(Name = "Quantidade de Clientes")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int QuantidadeClientes { get; set; }
    }
}