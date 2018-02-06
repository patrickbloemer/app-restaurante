using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Harvin.Models
{
    [Table("Configuracao")]
    public class Configuracao
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Sistema Ativado")]
        public bool SistemaAtivado { get; set; }

        [Display(Name = "Valor do Buffet")]
        public double ValorBuffet { get; set; }

        // Primeiro Horário
        [Display(Name = "Primeiro Horário")]
        public bool PrimeiroHorario { get; set; }

        [Display(Name = "Início do Primeiro Horário")]
        public DateTime PrimeiroHorarioInicio { get; set; }

        [Display(Name = "Final do Primeiro Horário")]
        public DateTime PrimeiroHorarioFinal { get; set; }

        // Segundo Horário
        [Display(Name = "Segundo Horário")]
        public bool SegundoHorario { get; set; }

        [Display(Name = "Início do Segundo Horário")]
        public DateTime SegundoHorarioInicio { get; set; }

        [Display(Name = "Final do Segundo Horário")]
        public DateTime SegundoHorarioFinal { get; set; }
    }
}