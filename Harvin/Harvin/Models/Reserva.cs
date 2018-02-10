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

        public DateTime DataCadastro { get; set; }

        public DateTime HorarioEntrega { get; set; }

        public int QuantidadeClientes { get; set; }

        public bool Preparada { get; set; }
    }
}