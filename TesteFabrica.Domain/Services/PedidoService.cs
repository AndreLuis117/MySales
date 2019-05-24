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

    
    public class PedidoService : ServiceBase<Pedido>, IPedidoService
    {
        private readonly IPedidoRepositorio ped_repo;

        public PedidoService(IPedidoRepositorio repo) : base(repo)
        {
            ped_repo = repo;
        }
        
    }
    
}
