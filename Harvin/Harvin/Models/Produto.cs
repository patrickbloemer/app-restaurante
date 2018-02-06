using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Harvin.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string Nome { get; set; }

        [Display(Name = "Valor Unitário")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public double ValorUnitario { get; set; }

        [Display(Name = "Quantidade Mínima em Estoque")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public int QuantidadeMinimaEstoque { get; set; }

        [Display(Name = "Quantidade Máxima em Estoque")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public int QuantidadeMaximaEstoque { get; set; }

        [Display(Name = "Quantidade Atual em Estoque")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public int QuantidadeAtualEstoque { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string Descricao { get; set; }

        [Display(Name = "Estocável")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public bool Estocavel { get; set; }

        public Categoria Categoria { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Link Imagem")]
        public string Imagem { get; set; }

        [Display(Name = "Comentários")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string Comentarios { get; set; }

        [Display(Name = "Inativo")]
        public bool Inativo { get; set; }
    }
}