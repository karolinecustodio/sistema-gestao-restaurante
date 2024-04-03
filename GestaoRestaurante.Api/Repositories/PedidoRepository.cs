using GestaoRestaurante.Api.Entities;

namespace GestaoRestaurante.Api.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        public Task<Pedido> GetByIdPedido(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Pedido> PostByPedido(Pedido Pedido)
        {
            throw new NotImplementedException();
        }
    }
}
