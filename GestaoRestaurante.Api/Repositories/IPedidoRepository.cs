using GestaoRestaurante.Api.Entities;

namespace GestaoRestaurante.Api.Repositories
{
    public interface IPedidoRepository
    {
        Task<Pedido> GetByIdPedido(int id);
        Task<IEnumerable<Pedido>> GetAllPedido();
        Task<Pedido> PostByPedido(Pedido Pedido);
        Task<IEnumerable<Pedido>> GetPedidosPorIntervaloDeData(DateTime dataInicial, DateTime dataFinal);
        Task<IEnumerable<Pedido>> GetPedidosPorIntervaloDeDataEId(int id, DateTime dataInicial, DateTime dataFinal);

        Task<Pedido> Update(Pedido pedido);
    }
}
