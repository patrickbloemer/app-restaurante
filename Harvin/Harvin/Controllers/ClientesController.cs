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

        // GET: Clientes/Todos
        public ActionResult Todos()
        {
            return View(db.Clientes.ToList());
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
        public ActionResult Create([Bind(Include = "id,nome,sobrenome,cpf,dataDeNascimento,email,telefone,senha,cep,endereco,complemento,bairro,cidade,imagem")] Cliente cliente)
        {
            if (ClienteDAO.BuscaClientePorCPF(cliente) == null && ClienteDAO.BuscaClientePorEmail(cliente) == null)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
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

        // GET: Clientes/CriarConta
        public ActionResult CriarConta()
        {
            return View();
        }

        // POST: Clientes/CriarConta 
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CriarConta([Bind(Include = "id,nome,sobrenome,cpf,dataDeNascimento,email,telefone,senha,cep,endereco,complemento,bairro,cidade,imagem")] Cliente cliente)
        {
            if (ClienteDAO.BuscaClientePorCPF(cliente) == null && ClienteDAO.BuscaClientePorEmail(cliente) == null)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Login", "Clientes");
            }
            else
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

        // GET: Clientes/Editar/5 ( Cliente Edita suas Informações )
        public ActionResult Editar(int? id)
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

        // POST: Clientes/Editar/5 ( Cliente Edita suas Informações )
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "id,nome,sobrenome,cpf,dataDeNascimento,email,telefone,senha,cep,endereco,complemento,bairro,cidade,imagem")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Logoff");
            }
            return View(cliente);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}


        // GET: Clientes/Login
        public ActionResult Login()
        {
            //ClinicaLoginDAO.NovoGuidPraSessao();
            return View();
        }

        // POST: Clientes/Login
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "cpf,senha")] Cliente cliente)
        {
            Cliente c = new Cliente();
            c = ClienteLoginDAO.VerificaLogin(cliente);
            if (c != null)
            {
                // ADICIONA CLIENTE À LISTA DE LOGIN ATIVO DAQUELA SESSÃO DO NAVEGADOR
                ClienteLoginDAO.AdicionarCliente(c);
                // ENCAMINHA PARA INDEX DO CLIENTE
                return RedirectToAction("Home", "Inicial");
            }
            else
            {
                ViewBag.Mensagem = "Login e/ou Senha inválido (s)";
                return View(cliente);
            }
        }

        // GET: Clinetes/Logoff
        public ActionResult Logoff()
        {
            ClienteLoginDAO.NovaSessao();
            return RedirectToAction("Login");
        }
        // GET: Clientes/Inativar
        public ActionResult Inativar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = ClienteDAO.BuscarClientePorId(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Inativar
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Inativar([Bind(Include = "id")] Cliente cliente)
        {

            Cliente aux = ClienteDAO.BuscarClientePorId(cliente.Id);

            aux.Inativo = true;
            db.Entry(aux).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        // GET: Clientes/Ativar
        public ActionResult Ativar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = ClienteDAO.BuscarClientePorId(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Ativar
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ativar([Bind(Include = "id")] Cliente cliente)
        {
            Cliente aux = ClienteDAO.BuscarClientePorId(cliente.Id);
            aux.Inativo = false;
            db.Entry(aux).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Todos");
        }
    }
}
