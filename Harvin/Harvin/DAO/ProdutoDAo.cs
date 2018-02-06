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

        // Retorna Lista de Produtos
        public static List<Produto> RetornaProdutos()
        {
            return entities.Produtos.ToList();
        }

        // Busca Produto por Nome
        public static Produto BuscaProdutoPorNome(Produto produto)
        {
            return entities.Produtos.FirstOrDefault(x => x.Nome.Equals(produto.Nome));
        }

        // Busca Produto por Id
        public static Produto BuscaProdutoPorId(int id)
        {
            return entities.Produtos.Find(id);
        }

        // Cadastrando Produto
        public static bool CadastrarProduto(Produto produto)
        {
            try
            {
                if (BuscaProdutoPorNome(produto) == null && !VerificacaoDeQtdeAtualEQtdeMax(produto))
                {
                    entities.Produtos.Add(produto);
                    entities.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        // Alterando atributos de Produto
        public static bool AlterandoProduto(Produto produto, string nome)
        {
            try
            {
                if ((BuscaProdutoPorNome(produto) == null || produto.Nome == nome) && !VerificacaoDeQtdeAtualEQtdeMax(produto))
                {
                    entities.Entry(produto).State = System.Data.Entity.EntityState.Modified;
                    entities.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
            }
        }

        // Verifica se Quantidade Atual Não é maior que Quantidade Máxima
        public static bool VerificacaoDeQtdeAtualEQtdeMax(Produto produto)
        {
            try
            {
                if (produto.QuantidadeAtualEstoque > produto.QuantidadeMaximaEstoque)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        //CALCULA SITUAÇÃO DO ESTOQUE
        public static float VerificaSituacaoEstoque(Produto produto)
        {
            try
            {
                float porcentagem;

                porcentagem = (produto.QuantidadeAtualEstoque * 100) / produto.QuantidadeMaximaEstoque;

                return porcentagem;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}