using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Harvin.Models
{
    [Table("ClienteLogin")]
    public class ClienteLogin {

        [Key]
        public int Id { get; set; }

        public Cliente Cliente { get; set; }

        [Display(Name = "Horário de Login")]
        public DateTime DataHorarioLogin { get; set; }

        public string Sessao { get; set; }
    }
}