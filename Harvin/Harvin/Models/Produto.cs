using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Harvin.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public double ValorUnitario { get; set; }

        public int QuantidadeMinimaEstoque { get; set; }

        public int QuantidadeMaximaEstoque { get; set; }

        public int QuantidadeAtualEstoque { get; set; }

        public string Descricao { get; set; }

        public bool Estocavel { get; set; }

        public bool Pizza { get; set; }

        public Categoria Categoria { get; set; }

        public string Imagem { get; set; }

        public string Comentario { get; set; }

        public bool Inativo { get; set; }
    }
}