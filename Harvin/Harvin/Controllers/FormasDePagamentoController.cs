using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Harvin.Models;

namespace Harvin.Controllers
{
    public class FormasDePagamentoController : Controller
    {
        private Entities db = new Entities();

        // GET: FormasDePagamento
        public ActionResult Index() {
            return View(db.FormaPagamentos.ToList());
        }

        // GET: FormasDePagamento
        public ActionResult Todos() {
            return View(db.FormaPagamentos.ToList());
        }

        // GET: FormasDePagamento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormaPagamento formaPagamento = db.FormaPagamentos.Find(id);
            if (formaPagamento == null)
            {
                return HttpNotFound();
            }
            return View(formaPagamento);
        }

        // GET: FormasDePagamento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FormasDePagamento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "formaPagamentoId,nome,descricao")] FormaPagamento formaPagamento)
        {
            if (ModelState.IsValid)
            {
                db.FormaPagamentos.Add(formaPagamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(formaPagamento);
        }

        // GET: FormasDePagamento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormaPagamento formaPagamento = db.FormaPagamentos.Find(id);
            if (formaPagamento == null)
            {
                return HttpNotFound();
            }
            return View(formaPagamento);
        }

        // POST: FormasDePagamento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "formaPagamentoId,nome,descricao")] FormaPagamento formaPagamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formaPagamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(formaPagamento);
        }

        // GET: FormasDePagamento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormaPagamento formaPagamento = db.FormaPagamentos.Find(id);
            if (formaPagamento == null)
            {
                return HttpNotFound();
            }
            return View(formaPagamento);
        }

        // POST: FormasDePagamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FormaPagamento formaPagamento = db.FormaPagamentos.Find(id);
            db.FormaPagamentos.Remove(formaPagamento);
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



        //INATIVAR FORMAS DE PAGAMETO
        // GET: Produtos/Inativar
        public ActionResult Inativar(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormaPagamento forma = db.FormaPagamentos.Find(id);
            if (forma == null) {
                return HttpNotFound();
            }
            return View(forma);
        }

        // POST: FORMASDEPAGAMENTO/Inativar
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Inativar([Bind(Include = "id")] FormaPagamento forma) {
            FormaPagamento aux = new FormaPagamento();
            aux = db.FormaPagamentos.Find(forma.Id);
            aux.Inativo = true;
            db.Entry(aux).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
