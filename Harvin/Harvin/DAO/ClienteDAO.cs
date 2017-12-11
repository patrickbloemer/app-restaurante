using Harvin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Harvin.DAO
{
    public class ClienteDAO
    {
        private static Entities entities = Singleton.Instance.Entities;
        
        // Busca Cliente por CPF
        public static Cliente BuscaClientePorCPF(Cliente cliente)
        {
            return entities.Clientes.FirstOrDefault(x => x.cpf.Equals(cliente.cpf));
        }
        // Busca Cliente por Email 
        public static Cliente BuscaClientePorEmail(Cliente cliente)
        {
            return entities.Clientes.FirstOrDefault(x => x.email.Equals(cliente.email));
        }
    }
}