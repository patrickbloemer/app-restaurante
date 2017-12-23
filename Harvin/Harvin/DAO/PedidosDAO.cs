using Harvin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Harvin.DAO {
    public class PedidosDAO {
        static List<Item> ListaItens = new List<Item>();

        //ADICIONA PRODUTO NA LISTA
        public static void AdicionaProduto(Produto produto, int quantidade) {
            Item item= new Item();
            item.produto = produto;
            item.quantidade = quantidade;
            ListaItens.Add(item);
        }

        //RETORNAR LISTA
        public static List<Item> RetornaLista() {
            return ListaItens;
        }
    }
}