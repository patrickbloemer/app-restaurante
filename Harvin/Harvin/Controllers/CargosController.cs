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
    public class CargosController : Controller
    {
        private Entities db = new Entities();

        // GET: Cargos
        public ActionResult Index() {
            return View(db.Cargos.ToList());
        }

        // GET: Cargos
        public ActionResult Todos() {
            return View(db.Cargos.ToList());
        }

        // GET: Cargos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo cargo = db.Cargos.Find(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View(cargo);
        }

        // GET: Cargos/Create
        public ActionResult Create()
        {
            if (CargoDAO.VerificaExistenciaDeCargos())
            {
                ViewBag.SemCargo = "É necessário ter ao menos um cargo cadastrado antes de cadastrar um funcionário!";
                return View();
            }
            else
            {
                return View();
            }
        }

        // POST: Cargos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cargoId,nome,descricao")] Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                if (CargoDAO.BurcarCargoPorNome(cargo) == null)
                {
                    db.Cargos.Add(cargo);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                } else
                {
                    ModelState.AddModelError("", "Já existe um cargo cadastrado com esse nome!");
                }
                
            }

            return View(cargo);
        }

        // GET: Cargos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo cargo = db.Cargos.Find(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View(cargo);
        }

        // POST: Cargos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cargoId,nome,descricao")] Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                Cargo aux = new Cargo();
                aux = CargoDAO.BuscaCargoPorId(cargo.cargoId);
                if(CargoDAO.BurcarCargoPorNome(cargo) == null || aux.nome == cargo.nome)
                {
                    db.Entry(cargo).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                } else
                {
                    ModelState.AddModelError("", "Não podem existir dois cargos com o mesmo nome!");
                }
               
            }
            return View(cargo);
        }

        // GET: Cargos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo cargo = db.Cargos.Find(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View(cargo);
        }

        // POST: Cargos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cargo cargo = db.Cargos.Find(id);
            db.Cargos.Remove(cargo);
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


        //INATIVAR CARGO
        // GET: Produtos/Inativar
        public ActionResult Inativar(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo cargo = db.Cargos.Find(id);
            if (cargo == null) {
                return HttpNotFound();
            }
            return View(cargo);
        }

        // POST: Produtos/Inativar
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Inativar([Bind(Include = "cargoId")] Cargo cargo) {

            Cargo aux = CargoDAO.BuscaCargoPorId(cargo.cargoId);

            if (CargoDAO.VerificaSeExisteFuncionariosEmCargo(aux))
            {
                ModelState.AddModelError("", "Não é possível inativar este cargo, pois existem funcionários cadastrados.");
            }
            else
            {
                aux.inativo = true;
                db.Entry(aux).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aux);
        }

        //INATIVAR CARGO
        // GET: Produtos/Inativar
        public ActionResult Ativar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Cargo cargo = db.Cargos.Find(id);

            if (cargo == null)
            {
                return HttpNotFound();
            }

            return View(cargo);
        }

        // POST: Produtos/Inativar
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ativar([Bind(Include = "cargoId")] Cargo cargo)
        {
            Cargo aux = CargoDAO.BuscaCargoPorId(cargo.cargoId);
            aux.inativo = false;
            db.Entry(aux).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Todos");
        }
    }
}
