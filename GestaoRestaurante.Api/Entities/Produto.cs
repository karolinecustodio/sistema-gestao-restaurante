using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoRestaurante.Api.Entities
{
    public class Produto
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Nome { get; set; }

        [MaxLength(200)]
        public string Descricao { get; set; }

        [MaxLength(100)]
        public string ImagemUrl { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorProd { get; set; }

        public int Quantidade { get; set; }

        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

        public ICollection<CarrinhoItem> Itens { get; set; }
            = new List<CarrinhoItem>();

        public ICollection<PedidoItem> PedidoItens { get; set; }
            = new List<PedidoItem>();
    }
}