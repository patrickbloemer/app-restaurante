using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Harvin.Models
{

    [Table("Cargo")]
    public class Cargo {

        public Cargo()
        {

        }

        public Cargo(int id)
        {
            Id = id;
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Inativo")]
        public bool Inativo { get; set; }
    }
}