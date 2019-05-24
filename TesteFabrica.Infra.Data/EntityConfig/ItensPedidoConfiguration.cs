using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteFabrica.Domain.Entities;

namespace TesteFabrica.Infra.Data.EntityConfig
{
    class ItensPedidoConfiguration : EntityTypeConfiguration<ItensPedido>
    {
        public ItensPedidoConfiguration()
        {
            HasKey(p => new { p.PedidoId, p.ProdutoId });

            HasRequired(p => p.Produto).WithMany().HasForeignKey(p => p.ProdutoId);

            HasRequired(p => p.Pedido).WithMany().HasForeignKey(p => p.PedidoId);
        }
    }
}
