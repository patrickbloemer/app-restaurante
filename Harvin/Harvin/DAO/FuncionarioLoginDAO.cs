using Harvin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Harvin.DAO {
    public class FuncionarioLoginDAO {
        private static Entities entities = new Entities();

        //Adicionar Funcionario Logado
        public static bool AdicionarFuncionario(Funcionario funcionario) {
            try {
                FuncionarioLogin login = new FuncionarioLogin();
                login.Funcionario = funcionario;
                login.DataHorarioLogin = DateTime.Now;
                login.Sessao = RetornarIdSessao();
                entities.FuncionarioLogin.Add(login);
                entities.SaveChanges();
                return true;
            }
            catch (Exception e) {
                return false;
            }
        }

        //Retorna Funcionario Logado
        public static FuncionarioLogin RetornarFuncionarioLogado() {
            try {
                string sessao = RetornarIdSessao();
                return entities.FuncionarioLogin.FirstOrDefault(x => x.Sessao == sessao);
            }
            catch (Exception e) {
                return null;
            }
        }

        //RETORNA OU GERA ID PRA SESSão
        public static string RetornarIdSessao() {
            if (HttpContext.Current.Session["Sessao"] == null) {
                //ESTE GUID GERA UMA SERIE ALFANUMERICA UNICA PARA CADA CARRINHO
                Guid guid = Guid.NewGuid();
                HttpContext.Current.Session["Sessao"] = guid.ToString();
            }
            return HttpContext.Current.Session["Sessao"].ToString();
        }

        //Verifica Login
        public static Funcionario VerificaLogin(Funcionario funcionario) {
            try {
                return entities.Funcionarios.FirstOrDefault(x => x.Cpf.Equals(funcionario.Cpf) && x.Senha.Equals(funcionario.Senha));
            }
            catch (Exception e) {
                return null;
            }
        }

        //NOVO GUID PARA SESSÃO
        public static void NovaSessao() {
            Guid guid = Guid.NewGuid();
            HttpContext.Current.Session["Sessao"] = guid.ToString();
        }

    }
}