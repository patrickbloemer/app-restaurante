using System;
using System.ComponentModel.DataAnnotations;

namespace Harvin.Models
{
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Primeiro Nome")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string Nome { get; set; }

        [Display(Name = "Sobrenome")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string Sobrenome { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string Cpf { get; set; }

        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Data de Nasciento")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DataDeNascimento { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "CEP")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Complemento")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Link Imagem")]
        public string Imagem { get; set; }

        public byte[] ImagemByte { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [Display(Name = "Inativo")]
        public bool Inativo { get; set; }

    }
}