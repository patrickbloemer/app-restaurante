using Harvin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Harvin.DAO
{
    public class ProdutoDAO
    {
        private static Entities entities = Singleton.Instance.Entities;

        // Busca Produto por Nome
        public static Produto BuscaProdutoPorNome(Produto produto)
        {
            return entities.Produtos.FirstOrDefault(x => x.nome.Equals(produto.nome));
        }
    }
}