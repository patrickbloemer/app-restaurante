using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Harvin.Models {
    [Table("FuncionarioLogins")]
    public class FuncionarioLogin {
        [Key]
        public int funcionarioLoginId { get; set; }
        public Funcionario funcionario { get; set; }
        public DateTime dataHorarioLogin { get; set; }
        public string sessao { get; set; }
    }
}