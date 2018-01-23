using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Harvin.Models {
    [Table("HistoricoDeAtividades")]
    public class HistoricoDeAtividade {
        [Key]
        public int id { get; set; }
        public Funcionario funcionario { get; set; }
        public DateTime dataHorario { get; set; }
        public string acao { get; set; }
    }
}