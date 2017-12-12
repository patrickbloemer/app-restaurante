using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Harvin.Models {
    public class Pessoa {
        [Key]
        public int id { get; set; }
        [Display(Name = "Primeiro Nome")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string nome { get; set; }

        [Display(Name = "Sobrenome")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string sobrenome { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string cpf { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Data de Nasciento")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime dataDeNascimento { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "CEP")]
        public string cep { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Endereço")]
        public string endereco { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Complemento")]
        public string complemento { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Bairro")]
        public string bairro { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Cidade")]
        public string cidade { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "E-mail")]
        public string email { get; set; }

        [Display(Name = "Telefone")]
        public string telefone { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string senha { get; set; }
    }
}