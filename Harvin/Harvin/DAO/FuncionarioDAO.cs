using Harvin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Harvin.DAO
{
    public class FuncionarioDAO
    {

        private static Entities entities = Singleton.Instance.Entities;

        // Retorna Lista de Funcionários
        public static List<Funcionario> RetornaFuncionarios()
        {
            return entities.Funcionarios.ToList();
        }

        // Busca Funcionário Por CPF
        public static Funcionario BuscaFuncionarioPorCPF(Funcionario funcionario)
        {
            return entities.Funcionarios.FirstOrDefault(x => x.Cpf.Equals(funcionario.Cpf));
        }

        // Busca Funcionário Por Email
        public static Funcionario BuscaFuncionarioPorEmail(Funcionario funcionario)
        {
            return entities.Funcionarios.FirstOrDefault(x => x.Email.Equals(funcionario.Email));
        }

        // Verifica se Existe Mais de um Funcionário
        public static bool VerificaFuncionarios()
        {
            List<Funcionario> listAux = new List<Funcionario>();
            listAux = RetornaFuncionarios();
            if (listAux.Count == 1)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public static Funcionario GetFuncionarioIdBySession()
        {
            var currentSession = HttpContext.Current.Session["Sessao"].ToString();

            var retorno = entities.FuncionarioLogin.Where(f => f.Sessao == currentSession).Select(s => s.Funcionario).FirstOrDefault();

            return retorno;
        }

        // Primeiro Funcionário
        public static bool primeiroFuncionario()
        {
            try
            {
                Funcionario fun = new Funcionario();

                fun.Id = 1;
                fun.Cargo = CargoDAO.BuscaCargoPorId(1);
                fun.Nome = "Administrador";
                fun.Sobrenome = "Administrador";
                fun.Cpf = "Administrador";
                fun.Telefone = "Administrador";
                fun.DataDeNascimento = DateTime.Now.Date;
                fun.Cep = "Administrador";
                fun.Endereco = "Administrador";
                fun.Complemento = "Administrador";
                fun.Bairro = "Administrador";
                fun.Cidade = "Administrador";
                fun.Imagem = "Administrador";
                fun.Email = "Administrador";
                fun.Senha = "Administrador";
                fun.Inativo = false;
                fun.Home = true;
                fun.Bi = true;
                fun.Relatorios = true;
                fun.ConsultarFuncionarios = true;
                fun.ManipularFuncionarios = true;
                fun.ManipularCargos = true;
                fun.ConsultarCargos = true;
                fun.ConsultarCategorias = true;
                fun.ManipularCategorias = true;
                fun.ManipularProdutos = true;
                fun.ConsultarPedidos = true;
                fun.ManipularPedidos = true;
                fun.ConsultarReservas = true;
                fun.ManipularReservas = true;


                entities.Funcionarios.Add(fun);
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}