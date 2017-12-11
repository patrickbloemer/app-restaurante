using Harvin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Harvin.DAO {
    public class FuncionarioDAO {

        private static Entities entities = Singleton.Instance.Entities;

        // Busca Funcionário Por CPF
        public static Funcionario BuscaFuncionarioPorCPF(Funcionario funcionario)
        {
            return entities.Funcionarios.FirstOrDefault(x => x.cpf.Equals(funcionario.cpf));
        }

        // Busca Funcionário Por Email
        public static Funcionario BuscaFuncionarioPorEmail(Funcionario funcionario)
        {
            return entities.Funcionarios.FirstOrDefault(x => x.email.Equals(funcionario.email));
        }
    }
}