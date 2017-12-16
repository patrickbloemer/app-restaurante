using Harvin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Harvin.DAO {
    public class ClienteLoginDAO {
        private static Entities entities = new Entities();

        //Adicionar Cliente Logado
        public static bool AdicionarCliente(Cliente cliente) {
            try {
                ClienteLogin login = new ClienteLogin();
                login.cliente = cliente;
                login.dataHorarioLogin = DateTime.Now;
                login.sessao = RetornarIdSessao();
                entities.ClienteLogin.Add(login);
                entities.SaveChanges();
                return true;
            }
            catch (Exception e) {
                return false;
            }
        }

        //Retorna Cliente Logado
        public static ClienteLogin RetornarClienteLogado() {
            try {
                string sessao = RetornarIdSessao();
                return entities.ClienteLogin.FirstOrDefault(x => x.sessao == sessao);
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
        public static Cliente VerificaLogin(Cliente cliente) {
            try {
                return entities.Clientes.FirstOrDefault(x => x.cpf.Equals(cliente.cpf) && x.senha.Equals(cliente.senha));
            }
            catch (Exception e) {
                return null;
            }
        }
    }
}