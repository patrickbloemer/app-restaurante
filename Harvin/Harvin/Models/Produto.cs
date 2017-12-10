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
        public string nome { get; set; }
        public double valorUnitario { get; set; }
        public int quantidadeMinimaEstoque { get; set; }
        public int quantidadeMaximaEstoque { get; set; }
        public int quantidadeAtualEstoque { get; set; }
        public string descricao { get; set; }
        public bool estocavel { get; set; }
        public Categoria categoria { get; set; }
        public int categoriaId { get; set; }
        public string comentarios { get; set; }
    }
}