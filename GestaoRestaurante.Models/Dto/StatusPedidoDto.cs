using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoRestaurante.Models.Dto
{
    public enum StatusPedidoDto
    {
        Novo,
        EmPreparo,
        AguardandoRetirada,
        Entregue,
        Cancelado,
        ACaminho
    }
}
