using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TesteFabrica.Domain.Entities;

namespace TesteFabrica.MVC.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo nome")]
        [MaxLength(150,ErrorMessage ="Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage ="Minímo {0} caracteres")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo descrição")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minímo {0} caracteres")]
        [DisplayName("Descrição")]
        public String Descricao { get; set; }

        [Required(ErrorMessage = "Preencha o campo preço")]
        [DataType(DataType.Currency)]
        [Range(typeof(decimal),"0", "999999999")]
        [DisplayName("Preço")]
        public decimal Preco { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        public virtual IEnumerable<ProdutoViewModel> Produtos { get; set; }


        [DisplayName("Status")]
        public bool IsActive { get; set; }

        
        
    }
        
}
