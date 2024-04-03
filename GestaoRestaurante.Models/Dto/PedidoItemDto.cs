using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoRestaurante.Models.Dto
{
    public class PedidoItemDto
    {
        public int Id { get; set; }

        public int ProdutoId { get; set; }
        public ProdutoDto? Produto { get; set; }

        public int PedidoId { get; set; }
        public PedidoDto? Pedido { get; set; }

        public decimal ValorProd { get; set; }

        public int Quantidade { get; set; }
    }
}
