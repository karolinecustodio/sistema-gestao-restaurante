using GestaoRestaurante.Api.Entities;

namespace GestaoRestaurante.Api.Repositories
{
    public interface IPedidoItemRepository
    {
        Task<PedidoItem> GetPedidoItemById(int id);
        Task<PedidoItem> GetPedidoItemByProdutoId(int id);
        Task<List<PedidoItem>> GetPedidoItemByPedidoId(int enderecoId);
        Task<List<PedidoItem>> GetAllPedidoItem();
        Task<PedidoItem> PostPedidoItem(PedidoItem pedidoItem);
        Task<PedidoItem> UpdatePedidoItem(PedidoItem pedidoItem);
    }
}
