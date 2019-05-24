using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteFabrica.Domain.Entities
{
    public class Pedido
    {
        public int PedidoId { get; set; }

        public DateTime DataPedido { get; set; }

        public decimal ValorTotal { get; set; }

        public virtual IEnumerable<ItensPedido> ItensPedidos { get; set; }

        public virtual IEnumerable<Pedido> Pedidos { get; set; }

    }
}
