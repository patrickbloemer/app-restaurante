using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Harvin.Models
{
    [Table("FuncionarioLogin")]
    public class FuncionarioLogin
    {
        [Key]
        public int Id { get; set; }

        public Funcionario Funcionario { get; set; }

        [Display(Name = "Horário Login")]
        public DateTime DataHorarioLogin { get; set; }

        public string Sessao { get; set; }
    }
}