using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TesteFabrica.Domain.Entities;

namespace TesteFabrica.MVC.ViewModels
{
    public class PedidoViewModel
    {

        [Key]
        public int PedidoId { get; set; }

        [DisplayName("Data do pedido")]
        public DateTime DataPedido { get; set; }

        [DisplayName("Valor total")]
        [ReadOnly(true)]
        public decimal ValorTotal { get; set; }

        public virtual IEnumerable<ItensPedido> ItensPedidos { get; set; }

        public virtual IEnumerable<Pedido> Pedidos { get; set; }
    }
}