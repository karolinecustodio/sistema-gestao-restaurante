using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoRestaurante.Api.Entities
{
    public class CarrinhoItem
    {
        public int Id { get; set; }

        public int CarrinhoId { get; set; }
        public Carrinho? Carrinho { get; set; }

        public int ProdutoId { get; set; }
        public Produto? Produto { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorProd {  get; set; }

        public int Quantidade { get; set; }


    }
}