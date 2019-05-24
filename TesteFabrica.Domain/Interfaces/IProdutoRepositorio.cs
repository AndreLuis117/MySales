using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteFabrica.Domain.Entities;

namespace TesteFabrica.Domain.Interfaces
{
    public interface IProdutoRepositorio : IBaseRepositorio<Produto>
    {
        IEnumerable<Produto> BuscarPorNome(string nome);
    }
}
