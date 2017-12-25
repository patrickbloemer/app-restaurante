using Harvin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Harvin.DAO {
    public class PedidosDAO {
        static List<Item> ListaItens = new List<Item>();
        static Entities db = new Entities();
        Pedido p = new Pedido();

        //ADICIONA PRODUTO NA LISTA
        public static void AdicionaProduto(Item item) {
            ListaItens.Add(item);
        }

        //RETORNAR LISTA
        public static List<Item> RetornaLista() {
            return ListaItens;
        }
    }
}