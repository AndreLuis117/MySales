using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteFabrica.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace TesteFabrica.Infra.Data.EntityConfig
{
    class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            HasKey(p => p.ProdutoId);

            Property(p => p.Nome).IsRequired().HasMaxLength(150);

            Property(p => p.Descricao).IsRequired().HasMaxLength(300);

            Property(p => p.Preco).IsRequired();

            Property(p => p.DataCadastro).IsRequired();


        }
    }
}
