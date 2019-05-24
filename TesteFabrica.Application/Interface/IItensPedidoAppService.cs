using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteFabrica.Domain.Entities;

namespace TesteFabrica.Application.Interface
{
    public interface IItensPedidoAppService : IAppServiceBase<ItensPedido>
    {
        decimal CalcularSubTotal(ItensPedido Item);

    }
}
