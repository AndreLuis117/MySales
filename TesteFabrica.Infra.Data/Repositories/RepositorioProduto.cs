using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteFabrica.Domain.Entities;
using TesteFabrica.Domain.Interfaces;

namespace TesteFabrica.Infra.Data.Repositories
{
    public class RepositorioProduto : RepositorioBase<Produto>, IProdutoRepositorio
    {
        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return Db.Produtos.Where(p => p.Nome == nome);
        }
    }
}
