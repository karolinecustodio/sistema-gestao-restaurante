using GestaoRestaurante.Api.Entities;

namespace GestaoRestaurante.Api.Repositories
{
    public interface IPedidoRepository
    {
        Task<Pedido> GetByIdPedido(int id);
        Task<Pedido> PostByPedido(Pedido Pedido);
    }
}
