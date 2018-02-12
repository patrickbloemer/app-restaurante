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
            return entities.Clientes.FirstOrDefault(x => x.Cpf.Equals(cliente.Cpf));
        }
        // Busca Cliente por Email 
        public static Cliente BuscaClientePorEmail(Cliente cliente)
        {
            return entities.Clientes.FirstOrDefault(x => x.Email.Equals(cliente.Email));
        }

        // Busca Cliente por Id
        public static Cliente BuscarClientePorId(int? id)
        {
            return entities.Clientes.Find(id);
        }
    }
}