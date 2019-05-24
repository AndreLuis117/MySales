using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TesteFabrica.Domain.Entities;
using TesteFabrica.MVC.ViewModels;

namespace TesteFabrica.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {


        public ViewModelToDomainMappingProfile()
        {
            CreateMap<Produto, ProdutoViewModel>();
            CreateMap<Pedido, PedidoViewModel>();
            CreateMap<ItensPedido, ItensPedidoViewModel>();
        }
    }
}