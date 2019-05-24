using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteFabrica.Domain.Entities;

namespace TesteFabrica.Application.Interface
{
    public interface IProdutoAppService: IAppServiceBase<Produto>
    {
        IEnumerable<Produto> BuscarPorNome(string nome);
    }
}
