using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteFabrica.Application.Interface;
using TesteFabrica.Domain.Entities;
using TesteFabrica.Domain.Interfaces.Services;

namespace TesteFabrica.Application
{
    public class ItensPedidoAppService : AppServiceBase<ItensPedido>, IItensPedidoAppService
    {
        private readonly IItensPedidoService pedService;
        private readonly IProdutoService prodService;

        public ItensPedidoAppService(IItensPedidoService Iped_service, IProdutoService Iprod_service) : base(Iped_service)
        {
            pedService = Iped_service;
            prodService = Iprod_service;
        }

        public decimal CalcularSubTotal(ItensPedido Item)
        {
            decimal SubTotal;

            SubTotal = Item.Qtde * prodService.GetById(Item.ProdutoId).Preco;

            return SubTotal;
        }

    }
}
