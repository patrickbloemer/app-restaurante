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
    public class FuncionariosController : Controller
    {
        private Entities db = new Entities();

        // GET: Funcionarios
        public ActionResult Index()
        {
            var funcionarios = db.Funcionarios.Include(f => f.Cargo);
            return View(funcionarios.ToList());
        }

        // GET: Funcionarios/Todos
        public ActionResult Todos()
        {
            var funcionarios = db.Funcionarios.Include(f => f.Cargo);
            return View(funcionarios.ToList());
        }

        // GET: Funcionarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // GET: Funcionarios/Create
        public ActionResult Create()
        {
            if (CargoDAO.VerificaExistenciaDeCargo())
            {
                return RedirectToAction("Create", "Cargo");
            }
            else
            {
                ViewBag.Id = new SelectList(db.Cargos, "Id", "nome");
                return View();
            }
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Sobrenome,Cpf,Telefone,DataDeNascimento,Cep,Endereco,Complemento,Bairro,Cidade,Imagem,CargoId,Email,Senha,Inativo,Home,Bi,Relatorios,ConsultarFuncionarios,ManipularFuncionarios,ManipularCargos,ConsultarCargos,ConsultarCategorias,ManipularCategorias,ManipularProdutos,ConsultarPedidos,ManipularPedidos,ConsultarReservas,ManipularReservas")] Funcionario funcionario)
            {

            if (FuncionarioDAO.BuscaFuncionarioPorCPF(funcionario) == null && FuncionarioDAO.BuscaFuncionarioPorEmail(funcionario) == null)
            {
                db.Funcionarios.Add(funcionario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                if (FuncionarioDAO.BuscaFuncionarioPorCPF(funcionario) != null)
                {
                    ModelState.AddModelError("", "Já existe um funcionário cadastrado no sistema com esse CPF!");
                }
                if (FuncionarioDAO.BuscaFuncionarioPorEmail(funcionario) != null)
                {
                    ModelState.AddModelError("", "Já existe um funcionário cadastrado no sistema com esse email!");
                }

            }

            ViewBag.Id = new SelectList(db.Cargos, "Id", "nome", funcionario.Cargo.Id);
            return View(funcionario);
        }

        // GET: Funcionarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Cargos, "Id", "nome", funcionario.Cargo.Id);
            return View(funcionario);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Sobrenome,Cpf,Telefone,DataDeNascimento,Cep,Endereco,Complemento,Bairro,Cidade,Imagem,id,Email,Senha,Inativo,Home,Bi,Relatorios,ConsultarFuncionarios,ManipularFuncionarios,ManipularCargos,ConsultarCargos,ConsultarCategorias,ManipularCategorias,ManipularProdutos,ConsultarPedidos,ManipularPedidos,ConsultarReservas,ManipularReservas")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(funcionario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Cargos, "Id", "nome", funcionario.Cargo.Id);
            return View(funcionario);
        }

        // GET: Funcionarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Funcionario funcionario = db.Funcionarios.Find(id);
            if (FuncionarioDAO.VerificaFuncionarios())
            {
                db.Funcionarios.Remove(funcionario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Não é possível excluir funcionário, pois só há este funcionário cadastrado!");
                return View(funcionario);
            }

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }



        // GET: Funcionarios/Login
        public ActionResult Login()
        {
            string mensagem;
            mensagem = ViewBag.Mensagem;
            ViewBag.Mensagem = mensagem;

            List<Funcionario> funs = FuncionarioDAO.RetornaFuncionarios();

            if (funs.Count == 0)
            {
                if (CargoDAO.PrimeiroCargo())
                {
                    if (FuncionarioDAO.primeiroFuncionario())
                    {
                        return View();
                    }
                }

                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "cpf,senha")] Funcionario funcionario)
        {
            Funcionario f = new Funcionario();
            f = FuncionarioLoginDAO.VerificaLogin(funcionario);
            if (f != null)
            {
                //ADICIONA FUNCIONÁRIO A LISTA DE LOGIN ATIVO DAQUELA SESSÃO DO NAVEGADOR
                FuncionarioLoginDAO.AdicionarFuncionario(f);

                //ENCAMINHA PRA INDEX
                return RedirectToAction("Index", "Inicial");
            }
            else
            {
                ViewBag.Mensagem = "Login e/ou Senha inválido (s)";
                return View(funcionario);
            }
        }



        // GET: Logoff
        public ActionResult Logoff()
        {
            FuncionarioLoginDAO.NovaSessao();
            return RedirectToAction("Login");
        }



        //INATIVAR FUNCIONÁRIO
        // GET: Funcionarios/Inativar
        public ActionResult Inativar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // POST: Funcionarios/Inativar
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Inativar([Bind(Include = "id")] Funcionario funcionario)
        {
            Funcionario aux = db.Funcionarios.Find(funcionario.Id);
            aux.Inativo = true;
            db.Entry(aux).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //ATIVAR FUNCIONÁRIO
        // GET: Funcionarios/Ativar
        public ActionResult Ativar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // POST: Funcionarios/Ativar
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ativar([Bind(Include = "id")] Funcionario funcionario)
        {
            Funcionario aux = db.Funcionarios.Find(funcionario.Id);
            aux.Inativo = false;
            db.Entry(aux).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}