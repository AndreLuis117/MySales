using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteFabrica.Domain.Entities;
using TesteFabrica.Domain.Interfaces;

namespace TesteFabrica.Infra.Data.Repositories
{
    public class RepositorioPedido : RepositorioBase<Pedido>, IPedidoRepositorio
    {
    }
}
