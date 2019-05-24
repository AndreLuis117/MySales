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
    public class ProdutoAppService : AppServiceBase<Produto>, IProdutoAppService
    {
        private readonly IProdutoService produtoService;

        public ProdutoAppService(IProdutoService prod_service) : base(prod_service)
        {
            produtoService = prod_service;
        }

        public IEnumerable<Produto> BuscarPorNome(String nome)
        {
            return produtoService.BuscarPorNome(nome);
        }
    }
}
