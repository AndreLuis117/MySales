using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity.ModelConfiguration;
using TesteFabrica.Domain.Entities;

namespace TesteFabrica.Infra.Data.EntityConfig
{
    class PedidoConfiguration : EntityTypeConfiguration<Pedido>
    {
        public PedidoConfiguration()
        {
            HasKey(p => p.PedidoId);

            
        }
    }
}
