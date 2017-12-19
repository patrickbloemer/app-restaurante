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

        // Busca Produto por Id
        public static Produto BuscaProdutoPorId(int id)
        {
            return entities.Produtos.Find(id);
        }
        // Verifica se Quantidade Atual Não é maior que Quantidade Máxima
        public static bool VerificacaoDeQtdeAtualEQtdeMax(Produto produto)
        {
            try
            {
                if(produto.quantidadeAtualEstoque > produto.quantidadeMaximaEstoque)
                {
                    return true;
                } else {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        //CALCULA SITUAÇÃO DO ESTOQUE
        public static float VerificaSituacaoEstoque(Produto produto) {
            try {
                float porcentagem;

                porcentagem = (produto.quantidadeAtualEstoque * 100) / produto.quantidadeMaximaEstoque;

                return porcentagem;
            }
            catch (Exception e) {
                return 0;
            }
        }
    }
}