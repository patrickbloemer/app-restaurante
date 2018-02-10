using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Harvin.Models
{
    [Table("Funcionario")]
    public class Funcionario : Pessoa
    {
        public Cargo Cargo { get; set; }

        [Display(Name = "Home")]
        public bool Home { get; set; }

        public bool Bi { get; set; }

        public bool Relatorios { get; set; }

        public bool ConsultarFuncionarios { get; set; }

        public bool ManipularFuncionarios { get; set; }

        public bool ManipularCargos { get; set; }

        public bool ConsultarCargos { get; set; }

        public bool ConsultarCategorias { get; set; }

        public bool ManipularCategorias { get; set; }

        public bool ManipularProdutos { get; set; }

        public bool ConsultarPedidos { get; set; }

        public bool ManipularPedidos { get; set; }

        public bool ConsultarReservas { get; set; }

        public bool ManipularReservas { get; set; }
    }
}