using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteFabrica.Application;
using TesteFabrica.Application.Interface;
using TesteFabrica.Domain.Entities;
using TesteFabrica.Domain.Services;
using TesteFabrica.MVC.ViewModels;

namespace TesteFabrica.MVC.Controllers
{
    public class ItensPedidoController : Controller
    {

        private readonly IItensPedidoAppService IpedApp;
        private readonly IProdutoAppService prodApp;

        public ItensPedidoController(IItensPedidoAppService iped_app, IProdutoAppService iprod_app)
        {
            IpedApp = iped_app;
            prodApp = iprod_app;
        }


        // GET: ItensPedido
        public ActionResult Index()
        {
            ViewBag.ListaProdutos = new SelectList(prodApp.GetAll(), "ProdutoId", "Nome");

            return View();
        }

        [HttpPost]
        public ActionResult Index(string produtoId)
        {
            
            ViewBag.ListaProdutos = new SelectList(prodApp.GetAll(), "ProdutoId", "Nome", produtoId);

            return View();
        }

        // GET: ItensPedido/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ItensPedido/Create
        public ActionResult Create()
        {
            ViewBag.ProdutoId = new SelectList(prodApp.GetAll(), "ProdutoId", "Nome");

            return View();
        }

        // POST: ItensPedido/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItensPedidoViewModel Iped, string produtoId)
        {
            ViewBag.ListaProdutos = new SelectList(prodApp.GetAll(), "ProdutoId", "Nome", produtoId);

            if (ModelState.IsValid)
            {
                Iped.ProdutoId = Convert.ToInt32(produtoId);
                ItensPedido ItenspedidoDomain = Mapper.Map<ItensPedidoViewModel, ItensPedido>(Iped);
                ItenspedidoDomain.SubTotal = IpedApp.CalcularSubTotal(ItenspedidoDomain);
                ItenspedidoDomain.Produto = prodApp.GetById(Convert.ToInt32(produtoId));
                ItensPedidoService.AddCarrinho(ItenspedidoDomain);
                return RedirectToAction("Create", "Pedido"); 
            }

            return View(Iped);
        }

        // GET: ItensPedido/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ItensPedido/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ItensPedido/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ItensPedido/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        
    }
}
