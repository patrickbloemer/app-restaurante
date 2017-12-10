using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Harvin.Models {
    [Table("ClienteLogins")]
    public class ClienteLogin {
        [Key]
        public int clienteLoginId { get; set; }
        public Cliente cliente { get; set; }
        public DateTime dataHorarioLogin { get; set; }
        public string sessao { get; set; }
    }
}