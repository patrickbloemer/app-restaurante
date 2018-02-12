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
    public class CargoController : Controller
    {
        private Entities db = new Entities();

        // GET: Cargo
        public ActionResult Index() {
            return View(CargoDAO.RetornaCargo());
        }

        // GET: Cargo
        public ActionResult Todos() {
            return View(CargoDAO.RetornaCargo());
        }

        // GET: Cargo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo cargo = CargoDAO.BuscaCargoPorId(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View(cargo);
        }

        // GET: Cargo/Create
        public ActionResult Create()
        {
            if (CargoDAO.VerificaExistenciaDeCargo())
            {
                ViewBag.SemCargo = "É necessário ter ao menos um cargo cadastrado antes de cadastrar um funcionário!";
                return View();
            }
            else
            {
                return View();
            }
        }

        // POST: Cargo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nome,descricao")] Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                if (CargoDAO.CadastrarCargo(cargo))
                {
                    
                    return RedirectToAction("Index");
                } else
                {
                    ModelState.AddModelError("", "Já existe um cargo cadastrado com esse nome!");
                }
                
            }

            return View(cargo);
        }

        // GET: Cargo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo cargo = CargoDAO.BuscaCargoPorId(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View(cargo);
        }

        // POST: Cargo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nome,descricao")] Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                Cargo aux = new Cargo();
                aux = CargoDAO.BuscaCargoPorId(cargo.Id);
                if(CargoDAO.BurcarCargoPorNome(cargo) == null || aux.Nome == cargo.Nome)
                {
                    db.Entry(cargo).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                } else
                {
                    ModelState.AddModelError("", "Não podem existir dois Cargo com o mesmo nome!");
                }
               
            }
            return View(cargo);
        }

        // GET: Cargo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo cargo = CargoDAO.BuscaCargoPorId(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View(cargo);
        }

        // POST: Cargo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cargo cargo = CargoDAO.BuscaCargoPorId(id);
            db.Cargos.Remove(cargo);
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


        //INATIVAR CARGO
        // GET: Cargo/Inativar
        public ActionResult Inativar(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo cargo = CargoDAO.BuscaCargoPorId(id);
            if (cargo == null) {
                return HttpNotFound();
            }
            return View(cargo);
        }

        // POST: Cargo/Inativar
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Inativar([Bind(Include = "Id")] Cargo cargo) {

            Cargo aux = CargoDAO.BuscaCargoPorId(cargo.Id);

            var funcionarios = db.Funcionarios.Include(f => f.Cargo);

            if (CargoDAO.VerificaSeExisteFuncionariosEmCargo(aux, funcionarios))
            {
                ModelState.AddModelError("", "Não é possível inativar este cargo, pois existem funcionários cadastrados.");
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

        //INATIVAR CARGO
        // GET: Cargo/Ativar
        public ActionResult Ativar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Cargo cargo = CargoDAO.BuscaCargoPorId(id);

            if (cargo == null)
            {
                return HttpNotFound();
            }

            return View(cargo);
        }

        // POST: Cargo/Ativar
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ativar([Bind(Include = "Id")] Cargo cargo)
        {
            Cargo aux = CargoDAO.BuscaCargoPorId(cargo.Id);
            aux.Inativo = false;
            db.Entry(aux).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Todos");
        }
    }
}
