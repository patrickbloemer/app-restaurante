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
    }
}