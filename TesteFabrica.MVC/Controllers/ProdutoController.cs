using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteFabrica.Application.Interface;
using TesteFabrica.Domain.Entities;
using TesteFabrica.MVC.ViewModels;
namespace TesteFabrica.MVC.Controllers
{
    

    public class ProdutoController : Controller
    {

        private readonly IProdutoAppService prodApp;

        public ProdutoController(IProdutoAppService prod_app)
        {
            prodApp = prod_app;
        }

        // GET: Produto
        public ActionResult Index()
        {
            var _produtoViewModel = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(prodApp.GetAll());


            return View(_produtoViewModel);
        }

        // GET: Produto/Details/5
        public ActionResult Details(int id)
        {
            var produto = prodApp.GetById(id);
            var clienteViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);

            return View(clienteViewModel);
        }


       
        // GET: Produto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                var produtoDomain = Mapper.Map<ProdutoViewModel, Produto>(produto);
                prodApp.Add(produtoDomain);
                

                return RedirectToAction("Index");
            }
            return View(produto);
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int id)
        {
            var produto = prodApp.GetById(id);
            
            var clienteViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);

            return View(clienteViewModel);
        }

        // POST: Produto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                var produtoDomain = Mapper.Map<ProdutoViewModel, Produto>(produto);
                prodApp.Update(produtoDomain);

                return RedirectToAction("Index");
            }
            return View(produto);
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int id)
        {
            var produto = prodApp.GetById(id);
            var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);

            return View(produtoViewModel);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var produto = prodApp.GetById(id);
            var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);

            try
            {
                prodApp.Remove(produto);
            }
            catch (Exception)
            {

                ViewBag.Erro = "Você não pode excluir este produto pois o mesmo já se encontra associado a um pedido!";
                return View(produtoViewModel);
            }
            

            return RedirectToAction("Index");
        }
    }
}
