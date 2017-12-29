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
    public class ProdutosController : Controller
    {
        private Entities db = new Entities();

        // GET: Produtos-Categorias
        public ActionResult Index()
        {
            var produtos = db.Produtos.Include(p => p.categoria);
            return View(produtos.ToList());
        }

        // GET: Produtos-Lista
        public ActionResult Todos() {
            var produtos = db.Produtos.Include(p => p.categoria);
            return View(produtos.ToList());
        }

        // GET: Produtos-Lista
        public ActionResult Lista() {
            var produtos = db.Produtos.Include(p => p.categoria);
            return View(produtos.ToList());
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            ViewBag.categoriaId = new SelectList(db.Categorias, "CategoriaId", "nome");
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nome,valorUnitario,quantidadeMinimaEstoque,quantidadeMaximaEstoque,quantidadeAtualEstoque,descricao,estocavel,categoriaId,comentarios, imagem")] Produto produto)
        {
            //if (ModelState.IsValid)
           // {
                if (ProdutoDAO.BuscaProdutoPorNome(produto) == null)
                {
                    if (ProdutoDAO.VerificacaoDeQtdeAtualEQtdeMax(produto))
                    {
                        ModelState.AddModelError("", "Quantidade Atual não pode ser maior que a Quantidade Máxima!");
                        ViewBag.categoriaId = new SelectList(db.Categorias, "CategoriaId", "nome", produto.categoriaId);
                        return View(produto);
                    }
                    else
                    {
                        produto.categoria = CategoriaDAO.BuscarCategoriaPorId(produto.categoriaId);
                        db.Produtos.Add(produto);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Já existe um produto cadastrado com esse nome!");
                }

            //}

            ViewBag.categoriaId = new SelectList(db.Categorias, "CategoriaId", "nome", produto.categoriaId);
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoriaId = new SelectList(db.Categorias, "CategoriaId", "nome", produto.categoriaId);
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nome,valorUnitario,quantidadeMinimaEstoque,quantidadeMaximaEstoque,quantidadeAtualEstoque,descricao,estocavel,categoriaId,comentarios, imagem")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                Produto aux = new Produto();
                aux = ProdutoDAO.BuscaProdutoPorId(produto.id);
                if (ProdutoDAO.BuscaProdutoPorNome(produto) == null || produto.nome == aux.nome)
                {
                    if (ProdutoDAO.VerificacaoDeQtdeAtualEQtdeMax(produto))
                    {
                        ModelState.AddModelError("", "Quantidade Atual não pode ser maior que a Quantidade Máxima!");
                        ViewBag.categoriaId = new SelectList(db.Categorias, "CategoriaId", "nome", produto.categoriaId);
                        return View(produto);
                    }
                    else
                    {
                        db.Entry(produto).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Não podem existir dois produtos com o mesmo nome!");
                }


            }
            ViewBag.categoriaId = new SelectList(db.Categorias, "CategoriaId", "nome", produto.categoriaId);
            return View(produto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }



        //INATIVAR PRODUTO
        // GET: Produtos/Inativar
        public ActionResult Inativar(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null) {
                return HttpNotFound();
            }
            ViewBag.categoriaId = new SelectList(db.Categorias, "CategoriaId", "nome", produto.categoriaId);
            return View(produto);
        }

        // POST: Produtos/Inativar
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Inativar([Bind(Include = "id, comentarios")] Produto produto) {
            Produto aux = new Produto();
            aux = ProdutoDAO.BuscaProdutoPorId(produto.id);
            aux.inativo = true;
            db.Entry(aux).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");            
        }
    }
}
