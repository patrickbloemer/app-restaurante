using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Harvin.Models {
    [Table("FormasPagamentos")]
    public class FormaPagamento {
        [Key]
        public int formaPagamentoId { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
    }
}