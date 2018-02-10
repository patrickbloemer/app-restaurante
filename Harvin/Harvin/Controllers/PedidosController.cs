using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Harvin.Models;
using Harvin.DAO;
using Harvin.Controllers.Util;
using System;
using Dapper;

namespace Harvin.Controllers
{
    public class PedidosController : Controller
    {
        private Entities db = new Entities();

        // GET: Pedidos
        public ActionResult Index()
        {
            return View(db.Pedidos.ToList());
        }

        // GET: Pedidos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidos.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // GET: Pedidos/Create
        public ActionResult Create()
        {
            return View(db.Produtos.ToList());
        }

        [HttpPost]
        public JsonResult Create(List<Item> itens, int numeroMesa)
        {
            try
            {
                var mesa = 0;
                var funcionario = FuncionarioDAO.GetFuncionarioIdBySession();

                //INSERT NOVA MESA SE JÁ NÃO EXISTIR UMA MESA COM O MESMO ID
                mesa = PedidosDAO.GetMesaByNumero(numeroMesa);

                if (mesa == 0)
                {
                    mesa = ConnectionFactory.Query<int>(@"
                        INSERT INTO MESAS (numeroMesa) OUTPUT INSERTED.[mesaId] VALUES (@mesa)",
                         new
                         {
                             mesa = numeroMesa
                         }).FirstOrDefault();
                }

                var pedido = new Pedido(DateTime.Now, funcionario);

                //INSERT PEDIDO
                pedido.Id = ConnectionFactory.Query<int>(@"
                    INSERT INTO PEDIDOS 
                    (horarioPedido, pendencia, pagamento, funcionario_id, mesaId)
                    OUTPUT INSERTED.[pedidoId] 
                    VALUES (@horario, @pendencia, @pagamento, @funcionario_id, @mesaId)",
                new
                {
                    horario = pedido.HorarioPedido,
                    pendencia = pedido.Pendencia,
                    pagamento = pedido.Pagamento,
                    funcionario_id = pedido.Funcionario.Id,
                }).FirstOrDefault();

                //INSERT ITEM PARA CADA ITEM NO ARRAY COM O PEDIDO ID RECÉM INSERTADO
                foreach (var item in itens)
                {
                    item.Pedido = new Pedido();
                    item.Pedido = pedido;

                    ConnectionFactory.Execute(@"
                        INSERT INTO ITENS VALUES (@quantidade, @produto_id, @Pedido_pedidoId)",
                    new
                    {
                        quantidade = item.Quantidade,
                        produto_id = item.Produto.Id,
                        Pedido_pedidoId = item.Pedido.Id
                    });

                }

                return new ApiRetorno(true).ToJson();
            }
            catch (Exception ex)
            {
                return new ApiRetorno(false).ToJson();
            }
        }

        // GET: Pedidos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidos.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: Pedidos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pedidoId,horarioPedido,horarioEntrega,pendencia,pagamento")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pedido);
        }

        // GET: Pedidos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidos.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pedido pedido = db.Pedidos.Find(id);
            db.Pedidos.Remove(pedido);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        //DESTINADO AO CLIENTE
        //COM PAYPAL
        // GET: Pedidos/FAZER PEDIDO
        public ActionResult Fazerpedido()
        {
            return View(db.Produtos.ToList());
        }

        // POST: Pedidos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Fazerpedido([Bind(Include = "id")] Produto produto, int quantidade)
        {
            Item item = new Item();
            item.Produto = db.Produtos.Find(produto.Id);
            item.Quantidade = quantidade;
            db.Itens.Add(item);
            db.SaveChanges();
            PedidosDAO.AdicionaProduto(item);
            return RedirectToAction("Fazerpedido");
        }
    }
}
