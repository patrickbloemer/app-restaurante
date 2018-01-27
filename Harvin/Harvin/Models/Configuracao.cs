using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Harvin.Models
{
    [Table("Configuracao")]
    public class Configuracao
    {
        [Key]
        public int ConfiguracaoId { get; set; }

        [Display(Name = "Sistema Ativado")]
        public bool sistemaAtivado { get; set; }

        [Display(Name = "Valor do Buffet")]
        public double valorBuffet { get; set; }

        // Primeiro Horário
        [Display(Name = "Primeiro Horário")]
        public bool primeiroHorario { get; set; }
        [Display(Name = "Início do Primeiro Horário")]
        public DateTime primeiroHorarioInicio { get; set; }
        [Display(Name = "Final do Primeiro Horário")]
        public DateTime primeiroHorarioFinal { get; set; }

        // Segundo Horário
        [Display(Name = "Segundo Horário")]
        public bool segundoHorario { get; set; }
        [Display(Name = "Início do Segundo Horário")]
        public DateTime segundoHorarioInicio { get; set; }
        [Display(Name = "Final do Segundo Horário")]
        public DateTime segundoHorarioFinal { get; set; }
    }
}