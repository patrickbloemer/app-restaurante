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
            var produtos = db.Produtos.Include(p => p.Categoria);
            return View(produtos.ToList());
        }

        // GET: Produtos-Lista
        public ActionResult Todos()
        {
            var produtos = db.Produtos.Include(p => p.Categoria);
            return View(produtos.ToList());
        }

        // GET: Produtos-Lista
        public ActionResult Lista()
        {
            var produtos = db.Produtos.Include(p => p.Categoria);
            return View(produtos.ToList());
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Categorias, "Id", "nome");
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nome,valorUnitario,quantidadeMinimaEstoque,quantidadeMaximaEstoque,quantidadeAtualEstoque,descricao,estocavel,categoriaId,comentario, imagem")] Produto produto)
        {
                produto.Categoria = CategoriaDAO.BuscarCategoriaPorId(produto.Categoria.Id);
                if (ProdutoDAO.CadastrarProduto(produto))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    if (ProdutoDAO.VerificacaoDeQtdeAtualEQtdeMax(produto))
                    {
                        ModelState.AddModelError("", "Quantidade atual não pode ser maior que a quantidade máxima!");
                    }

                    if (ProdutoDAO.BuscaProdutoPorNome(produto) != null)
                    {
                        ModelState.AddModelError("", "Não podem existir dois produtos com o mesmo nome!");
                    }
                }

            

            ViewBag.Id = new SelectList(db.Categorias, "Id", "nome", produto.Categoria.Id);
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
            ViewBag.Id = new SelectList(db.Categorias, "Id", "nome", produto.Categoria.Id);
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nome,valorUnitario,quantidadeMinimaEstoque,quantidadeMaximaEstoque,quantidadeAtualEstoque,descricao,estocavel,categoriaId,comentario, imagem")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                Produto aux = ProdutoDAO.BuscaProdutoPorId(produto.Id);
                string nomeProdutoCadastrado = aux.Nome;
                aux.Nome = produto.Nome;
                aux.ValorUnitario = produto.ValorUnitario;
                aux.QuantidadeMinimaEstoque = produto.QuantidadeMinimaEstoque;
                aux.QuantidadeMaximaEstoque = produto.QuantidadeMaximaEstoque;
                aux.QuantidadeAtualEstoque = produto.QuantidadeAtualEstoque;
                aux.Descricao = produto.Descricao;
                aux.Estocavel = produto.Estocavel;
                aux.Categoria.Id = produto.Categoria.Id;
                aux.Imagem = produto.Imagem;

                if (ProdutoDAO.AlterandoProduto(aux, nomeProdutoCadastrado))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    if (ProdutoDAO.VerificacaoDeQtdeAtualEQtdeMax(produto))
                    {
                        ModelState.AddModelError("", "Quantidade atual não pode ser maior que a quantidade máxima!");
                    }

                    if (ProdutoDAO.BuscaProdutoPorNome(produto) != null)
                    {
                        ModelState.AddModelError("", "Não podem existir dois produtos com o mesmo nome!");
                    }
                }


            }
            ViewBag.Id = new SelectList(db.Categorias, "Id", "nome", produto.Categoria.Id);
            return View(produto);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //INATIVAR PRODUTO
        // GET: Produtos/Inativar
        public ActionResult Inativar(int? id)
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
            ViewBag.Id = new SelectList(db.Categorias, "Id", "nome", produto.Categoria.Id);
            return View(produto);
        }

        // POST: Produtos/Inativar
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Inativar([Bind(Include = "id, comentario")] Produto produto)
        {
            Produto aux = ProdutoDAO.BuscaProdutoPorId(produto.Id);
            aux.Inativo = true;
            db.Entry(aux).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Lista");
        }

        //ATIVAR PRODUTO
        // GET: Produtos/Inativar
        public ActionResult Ativar(int? id)
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
            ViewBag.Id = new SelectList(db.Categorias, "Id", "nome", produto.Categoria.Id);
            return View(produto);
        }

        // POST: Produtos/Ativar
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ativar([Bind(Include = "id, comentario")] Produto produto)
        {
            Produto aux = ProdutoDAO.BuscaProdutoPorId(produto.Id);
            aux.Inativo = false;
            db.Entry(aux).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Todos");
        }
    }
}