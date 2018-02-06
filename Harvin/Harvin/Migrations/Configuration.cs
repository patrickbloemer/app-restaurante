namespace Harvin.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Harvin.Models.Entities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Harvin.Models.Entities context)
        {
            if (context.Cargos.Count() == 0 && context.Funcionarios.Count() == 0)
            {
                GetCargo().ForEach(c => context.Cargos.Add(c));
                GetFuncionarios().ForEach(p => context.Funcionarios.Add(p));
            }
        }

        private static List<Cargo> GetCargo()
        {
            var cargo = new List<Cargo> {
                new Cargo
                {
                    Id = 1,
                    Nome = "Administrador",
                    Descricao = "Administrador do Sistema",
                    Inativo = false
                }
            };
            return cargo;
        }

        private static List<Funcionario> GetFuncionarios()
        {
            var funcionario = new List<Funcionario> {
                new Funcionario
                {
                    Id = 1,
                    Cargo = new Cargo(1),
                    Nome = "Administrador",
                    Sobrenome = "Administrador",
                    Cpf = "Administrador",
                    Telefone = "Administrador",
                    DataDeNascimento = DateTime.Now.Date,
                    Cep = "Administrador",
                    Endereco = "Administrador",
                    Complemento = "Administrador",
                    Bairro = "Administrador",
                    Cidade = "Administrador",
                    Imagem = "Administrador",
                    Email = "Administrador",
                    Senha = "Administrador",
                    Inativo = false
                }
            };
            return funcionario;
        }

    }
}
