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
    public class PedidoController : Controller
    {
        private readonly IPedidoAppService pedApp;
        private IItensPedidoAppService ipedApp;

        public PedidoController(IPedidoAppService ped_app, IItensPedidoAppService iped_App)
        {
            pedApp = ped_app;
            ipedApp = iped_App;
        }


        // GET: Pedido
        public ActionResult Index()
        {
            var _pedidoViewModel = Mapper.Map<IEnumerable<Pedido>, IEnumerable<PedidoViewModel>>(pedApp.GetAll());
            ItensPedidoService.Carrinho.Clear();

            return View(_pedidoViewModel);
        }

        // GET: Pedido/Details/5
        public ActionResult Details(int id)
        {
            var pedido = pedApp.GetById(id);
            var pedidoViewModel = Mapper.Map<Pedido, PedidoViewModel>(pedido);

            return View(pedidoViewModel);
           
        }

        // GET: Pedido/Create
        public ActionResult Create()
        {
            PedidoViewModel pedido = new PedidoViewModel();
            pedido.ValorTotal = pedApp.CalcularTotal(ItensPedidoService.Carrinho);
            pedido.ItensPedidos = ItensPedidoService.Carrinho;
            
            return View(pedido);
        }

        // POST: Pedido/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PedidoViewModel pedido)
        {
            if (ModelState.IsValid)
            {
                ItensPedido itensPed = new ItensPedido();
                var pedidoDomain = Mapper.Map<PedidoViewModel, Pedido>(pedido);
                
                pedidoDomain.ValorTotal = pedApp.CalcularTotal(ItensPedidoService.Carrinho);
                pedApp.Add(pedidoDomain);

                for (int i = 0; i < ItensPedidoService.Carrinho.Count; i++)
                {
                    itensPed = ItensPedidoService.Carrinho[i];
                    itensPed.PedidoId = pedidoDomain.PedidoId;
                    ipedApp.Add(itensPed);
                }

                return RedirectToAction("Index");
            }
            return View(pedido);
        }

        // GET: Pedido/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pedido/Edit/5
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

        // GET: Pedido/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pedido/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }

        //Ação Incluir Item no pedido
        public ActionResult IncluirItem()
        {
            return RedirectToAction("ItensPedido/Create");
        }

        //Ação de cancelar o pedido que está em andamento
        public  ActionResult CancelarPed()
        {
            ItensPedidoService.Carrinho.Clear();

            return RedirectToAction("Index");
        }

        
        //Ação de remover um Item do "Carrinho" de compras durante o pedido
        public ActionResult RemoverItem(int id)
        {
            pedApp.DeleteItemById(id);

            return RedirectToAction("Create");
        }
    }
}
