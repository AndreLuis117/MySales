using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteFabrica.Domain.Entities
{
    public class Produto
    {
        public int ProdutoId { get; set; }

        public String Nome { get; set; }

        public String Descricao { get; set; }

        public decimal Preco { get; set; }

        public DateTime DataCadastro{ get; set; }

        public bool IsActive { get; set; }

        public virtual IEnumerable<Produto> Produtos { get; set; }


    }
}
