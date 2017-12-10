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
        public string nome { get; set; }

        [Display(Name = "Sobrenome")]
        public string sobrenome { get; set; }

        [Display(Name = "CPF")]
        public string cpf { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Data de Nasciento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime dataDeNascimento { get; set; }


        [Display(Name = "CEP")]
        public string cep { get; set; }

        [Display(Name = "Endereço")]
        public string endereco { get; set; }

        [Display(Name = "Complemento")]
        public string complemento { get; set; }

        [Display(Name = "Bairro")]
        public string bairro { get; set; }

        [Display(Name = "Cidade")]
        public string cidade { get; set; }

        [Display(Name = "E-mail")]
        public string email { get; set; }

        [Display(Name = "Telefone")]
        public string telefone { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string senha { get; set; }
    }
}