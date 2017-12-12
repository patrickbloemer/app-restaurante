using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Harvin.Models {
    [Table("Categorias")]
    public class Categoria {
        [Key]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Nome")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Descrição")]
        public string descricao { get; set; }
    }
}