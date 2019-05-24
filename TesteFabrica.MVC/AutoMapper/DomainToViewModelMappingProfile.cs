using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TesteFabrica.Domain.Entities;
using TesteFabrica.MVC.ViewModels;

namespace TesteFabrica.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ProdutoViewModel, Produto>();
            CreateMap<PedidoViewModel, Pedido>();
            CreateMap<ItensPedidoViewModel, ItensPedido>();
        }

        
    }
}