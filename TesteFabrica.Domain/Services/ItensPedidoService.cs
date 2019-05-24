using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteFabrica.Domain.Entities;
using TesteFabrica.Domain.Interfaces;
using TesteFabrica.Domain.Interfaces.Services;

namespace TesteFabrica.Domain.Services
{
    public class ItensPedidoService : ServiceBase<ItensPedido>, IItensPedidoService
    {
        private readonly IItensPedidoRepositorio ped_repo;
        private readonly IProdutoRepositorio prod_repo;

        public static List<ItensPedido> Carrinho = new List<ItensPedido>();

        public ItensPedidoService(IItensPedidoRepositorio repo, IProdutoRepositorio repo2 ) : base(repo)
        {
            ped_repo = repo;
            prod_repo = repo2;
        }

        public static void AddCarrinho(ItensPedido Item)
        {
            bool validator = false;

            for (int i = 0; i < Carrinho.Count; i++)
            {
                if (Carrinho[i].ProdutoId == Item.ProdutoId)
                {
                    Carrinho[i].Qtde = Carrinho[i].Qtde + Item.Qtde;
                    Carrinho[i].SubTotal = Carrinho[i].SubTotal + Item.SubTotal;
                    validator = true;
                    break;
                }
            }

            if (validator == false)
            {
                Carrinho.Add(Item);
            }
            
        }

    }
}
