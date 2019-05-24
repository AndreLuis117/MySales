using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteFabrica.Domain.Entities;
using TesteFabrica.Domain.Interfaces;
using TesteFabrica.Domain.Interfaces.Services;

namespace TesteFabrica.Domain.Services
{
    public class ProdutoService : ServiceBase<Produto>, IProdutoService
    {
        private readonly IProdutoRepositorio prod_repo;

        public ProdutoService(IProdutoRepositorio repo) : base(repo)
        {
            prod_repo = repo;
        }

        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return prod_repo.BuscarPorNome(nome);
        }

    }
}
