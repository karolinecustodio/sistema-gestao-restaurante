using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoRestaurante.Api.Entities
{
    public class Pedido
    {
        public int Id { get; set; }

        public DateTime DataEmissao { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorPedido { get; set; }

        public FormaPagamento FormaPagamento { get; set; }

        public StatusPedido StatusPedido { get; set; }

        public ICollection<PedidoItem> PedidoItens { get; set; }
           = new List<PedidoItem>();
    }
}
