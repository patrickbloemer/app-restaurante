using Harvin.Controllers.Util;
using Harvin.Models;
using System.Collections.Generic;
using System.Linq;

namespace Harvin.DAO
{
    public class PedidosDAO
    {
        static List<Item> ListaItens = new List<Item>();
        static Entities db = new Entities();
        Pedido p = new Pedido();

        //ADICIONA PRODUTO NA LISTA
        public static void AdicionaProduto(Item item)
        {
            ListaItens.Add(item);
        }

        //RETORNAR LISTA
        public static List<Item> RetornaLista()
        {
            return ListaItens;
        }

        public static int GetMesaByNumero(int numeroMesa)
        {
            var retorno = ConnectionFactory.Query<int>(@"
                        SELECT mesaId FROM Mesas WHERE mesaId = @mesaId",
                    new
                    {
                        mesaId = numeroMesa
                    }).FirstOrDefault();

            return retorno;
        }
    }
}