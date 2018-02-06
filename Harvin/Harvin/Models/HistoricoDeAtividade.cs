using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.UI.WebControls;

namespace Harvin.Models
{
    [Table("HistoricoDeAtividades")]
    public class HistoricoDeAtividade
    {
        [Key]
        public int Id { get; set; }

        public Funcionario Funcionario { get; set; }

        public DateTime DataHorario { get; set; }

        public string Acao { get; set; }
    }
}