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
    public class ClientesController : Controller
    {
        private Entities db = new Entities();

        // GET: Clientes
        public ActionResult Index()
        {
            return View(db.Clientes.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nome,sobrenome,cpf,dataDeNascimento,email,telefone,senha,cep,endereco,complemento,bairro,cidade, imagem")] Cliente cliente)
        {
            if(ClienteDAO.BuscaClientePorCPF(cliente) == null && ClienteDAO.BuscaClientePorEmail(cliente) == null)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            } else
            {
                if (ClienteDAO.BuscaClientePorCPF(cliente) != null)
                {
                    ModelState.AddModelError("", "Já existe um cliente cadastrado no sistema com esse CPF!");
                }
                if (ClienteDAO.BuscaClientePorEmail(cliente) != null)
                {
                    ModelState.AddModelError("", "Já existe um cliente cadastrado no sistema com esse Email!");
                }
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nome,sobrenome,cpf,dataDeNascimento,email,telefone,senha,cep,endereco,complemento,bairro,cidade, imagem")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
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


        // GET: Clientes/Login
        public ActionResult Login() {
            //ClinicaLoginDAO.NovoGuidPraSessao();
            return View();
        }

        // POST: Clientes/Login
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "cpf,senha")] Cliente cliente) {
            Cliente c = new Cliente();
            c = ClienteLoginDAO.VerificaLogin(cliente);
            if (c != null) {
                ClienteLoginDAO.AdicionarCliente(c);
                return RedirectToAction("Index");
            } else {
                ViewBag.Mensagem = "Login e/ou Senha inválido (s)";
                return View(cliente);
            }
        }
    }
}
