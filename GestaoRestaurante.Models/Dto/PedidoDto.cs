using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoRestaurante.Models.Dto
{
    public class PedidoDto
    {
        public int Id { get; set; }

        public DateTime DataEmissao { get; set; }

        public decimal ValorPedido { get; set; }

        public FormaPagamentoDto FormaPagamento { get; set; }

        public StatusPedidoDto StatusPedido { get; set; }

        public ICollection<PedidoItemDto> PedidoItem { get; set; }
            = new List<PedidoItemDto>();
    }
}
