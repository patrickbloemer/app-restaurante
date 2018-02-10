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

        public bool AutorizarPedidos { get; set; }

        public bool AutorizarReservas { get; set; }

        public bool PrimeiroHorario { get; set; }

        public DateTime PrimeiroHorarioInicio { get; set; }

        public DateTime PrimeiroHorarioFinal { get; set; }

        public DateTime SegundoHorario { get; set; }

        public DateTime SegundoHorarioInicio { get; set; }

        public DateTime SegundoHorarioFinal { get; set; }
    }
}