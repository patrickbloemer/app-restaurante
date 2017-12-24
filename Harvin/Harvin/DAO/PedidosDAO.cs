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
        public static void AdicionaProduto(Produto produto, int quantidade) {
            Item item = new Item();
            item.produto = produto;
            item.quantidade = quantidade;
            db.Itens.Add(item);
            db.SaveChanges();
            ListaItens.Add(item);
        }

        //RETORNAR LISTA
        public static List<Item> RetornaLista() {
            return ListaItens;
        }

        //FINALIZAR PEDIDO
        public static bool FinalizarPedido() {
            Pedido pedido = new Pedido();
            //ADICIONA ITENS DA LISTA NOS ITENS DO PEDIDO
            foreach (var Itens in ListaItens) {
                pedido.itens.Add(Itens);
            }

            pedido.horarioPedido = DateTime.Now;
            pedido.horarioEntrega = DateTime.Now;
            pedido.pagamento = false;
            pedido.pendencia = false;

            try {
                db.Pedidos.Add(pedido);
                db.SaveChanges();
                return true;
            }
            catch (Exception e) {
                return false;
            }
        }
    }
}