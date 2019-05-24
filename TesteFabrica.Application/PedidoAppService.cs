using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteFabrica.Application.Interface;
using TesteFabrica.Domain.Entities;
using TesteFabrica.Domain.Interfaces.Services;
using TesteFabrica.Domain.Services;

namespace TesteFabrica.Application
{
    public class PedidoAppService : AppServiceBase<Pedido>, IPedidoAppService
    {
        private readonly IPedidoService pedService;

        public PedidoAppService(IPedidoService ped_service) : base(ped_service)
        {
            pedService = ped_service;
        }

        public decimal CalcularTotal(List<ItensPedido> Itens)
        {
            decimal total = 0;

            for (int i = 0; i < Itens.Count; i++)
            {
                total = total + Itens[i].SubTotal;
            }

            return total;
        }

        public void DeleteItemById(int id)
        {
            for (int i = 0; i < ItensPedidoService.Carrinho.Count; i++)
            {
                if (ItensPedidoService.Carrinho[i].ProdutoId == id)
                {
                    ItensPedidoService.Carrinho.RemoveAt(i);
                    break;
                }
                
            }
            
        }


    }
}
