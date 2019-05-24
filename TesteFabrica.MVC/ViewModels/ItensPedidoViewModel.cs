using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TesteFabrica.Domain.Entities;

namespace TesteFabrica.MVC.ViewModels
{
    public class ItensPedidoViewModel
    {

        [Key]
        public int PedidoId { get; set; }

        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo quantidade")]
        [DisplayName("Quantidade")]
        public int Qtde { get; set; }

        [ScaffoldColumn(false)]
        public decimal SubTotal { get; set; }

        public Produto Produto { get; set; }

        public Pedido Pedido { get; set; }

        public virtual IEnumerable<ItensPedido> ItensPedidos { get; set; }
    }
}