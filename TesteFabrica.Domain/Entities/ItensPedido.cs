using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteFabrica.Domain.Entities
{
    public class ItensPedido
    {
        public int PedidoId { get; set; }

        public int ProdutoId { get; set; }

        public int Qtde { get; set; }

        public decimal SubTotal { get; set; }

        public Produto Produto { get; set; }

        public Pedido Pedido { get; set; }

        public virtual IEnumerable<ItensPedido> ItensPedidos { get; set; }
    }
}
