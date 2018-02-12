using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Harvin.Models;
using Harvin.DAO;

namespace Harvin.Controllers
{
    public class CategoriasController : Controller
    {
        private Entities db = new Entities();

        // GET: Categorias
        public ActionResult Index() {
            return View(db.Categorias.ToList());
        }

        // GET: Categorias
        public ActionResult Todos() {
            return View(db.Categorias.ToList());
        }

        // GET: Categorias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = db.Categorias.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // GET: Categorias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nome,descricao, imagem")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                if(CategoriaDAO.BuscarCategoriaPorNome(categoria) == null)
                {
                    db.Categorias.Add(categoria);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                } else
                {
                    ModelState.AddModelError("", "Já existe uma categoria cadastrada com esse nome!");
                }
            }

            return View(categoria);
        }

        // GET: Categorias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = db.Categorias.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nome,descricao,imagem")] Categoria categoria)
        {
                Categoria aux = new Categoria();
                aux = CategoriaDAO.BuscarCategoriaPorId(categoria.Id);
                if(CategoriaDAO.BuscarCategoriaPorNome(categoria) == null || aux.Nome == categoria.Nome)
                {
                    db.Entry(categoria).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                } else
                {
                    ModelState.AddModelError("", "Não podem existir duas Categorias com o mesmo nome!");
                }
                
            
            return View(categoria);
        }

        // GET: Categorias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = db.Categorias.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Categoria categoria = db.Categorias.Find(id);
            db.Categorias.Remove(categoria);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}


        //INATIVAR CATEGORIA
        // GET: Produtos/Inativar
        public ActionResult Inativar(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = db.Categorias.Find(id);
            if (categoria == null) {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: CATEGORIA/Inativar
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Inativar([Bind(Include = "Id")] Categoria categoria) {

            Categoria aux = CategoriaDAO.BuscarCategoriaPorId(categoria.Id);

            if (CategoriaDAO.VerificaSeExisteProdutosEmCategoria(aux))
            {
                ModelState.AddModelError("", "Não é possível inativar esta categoria, pois possui produtos cadastrados.");
            }
            else
            {
                aux.Inativo = true;
                db.Entry(aux).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aux);
        }

        // INATIVAR CATEGORIA
        // GET: Categorias/Ativar
        public ActionResult Ativar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Categoria categoria = db.Categorias.Find(id);

            if (categoria == null)
            {
                return HttpNotFound();
            }

            return View(categoria);
        }

        // POST: Categoria/Ativar
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ativar([Bind(Include = "Id")] Categoria categoria)
        {
            Categoria aux = CategoriaDAO.BuscarCategoriaPorId(categoria.Id);
            aux.Inativo = false;
            db.Entry(aux).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Todos");
        }

    }
}
