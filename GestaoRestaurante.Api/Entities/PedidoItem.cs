using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoRestaurante.Api.Entities
{
    public class PedidoItem
    {
        public int Id { get; set; }

        public int ProdutoId { get; set; }
        public Produto? Produto { get; set; }

        public int PedidoId { get; set; }
        public Pedido? Pedido { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorProd { get; set; }

        public int Quantidade {  get; set; }  
    }
}
