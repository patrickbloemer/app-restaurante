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
            if (context.Cargos.Count() == 0 && context.Funcionarios.Count() == 0) {
                GetCargos().ForEach(c => context.Cargos.Add(c));
                GetFuncionarios().ForEach(p => context.Funcionarios.Add(p));
            }
        }




        private static List<Cargo> GetCargos() {
            var cargo = new List<Cargo> {
                new Cargo
                {
                    cargoId = 1,
                    nome = "Administrador",
                    descricao = "Administrador do Sistema",
                    inativo = false
                }
            };
            return cargo;
        }

        private static List<Funcionario> GetFuncionarios() {
            var funcionario = new List<Funcionario> {
                new Funcionario
                {
                    id = 1,
                    cargoId = 1,
                    nome = "Administrador",
                    sobrenome = "Administrador",
                    cpf = "Administrador",
                    telefone = "Administrador",
                    dataDeNascimento = DateTime.Now,
                    cep = "Administrador",
                    endereco = "Administrador",
                    complemento = "Administrador",
                    bairro = "Administrador",
                    cidade = "Administrador",
                    imagem = "Administrador",
                    email = "Administrador",
                    senha = "Administrador",
                    inativo = false

                }
            };
            return funcionario;
        }



    }
}
