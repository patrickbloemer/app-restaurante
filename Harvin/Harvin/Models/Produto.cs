using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Harvin.Models {
    [Table("Produtos")]
    public class Produto {
        [Key]
        public int id { get; set; }
        
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string nome { get; set; }

        [Display(Name = "Valor Unitário")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public double valorUnitario { get; set; }

        [Display(Name = "Quantidade Mínima em Estoque")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public int quantidadeMinimaEstoque { get; set; }

        [Display(Name = "Quantidade Máxima em Estoque")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public int quantidadeMaximaEstoque { get; set; }

        [Display(Name = "Quantidade Atual em Estoque")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public int quantidadeAtualEstoque { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string descricao { get; set; }

        [Display(Name = "Estocável")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public bool estocavel { get; set; }

        public Categoria categoria { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public int categoriaId { get; set; }

        [Display(Name = "Comentários")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string comentarios { get; set; }
    }
}