using GestaoRestaurante.Models.Dto;

namespace GestaoRestaurante.Web.Services
{
    public interface IPedidoItemService
    {
        Task<IEnumerable<PedidoItemDto>> GetAllPedidoItem();
        Task<PedidoItemDto> GetPedidoItemByUsuarioId(int? usuarioId);
        Task<PedidoItemDto> PostPedidoItem(PedidoItemDto pedidoItemDto);
        Task<IEnumerable<PedidoItemDto>> GetItensPorPedidoId(int pedidoId);
    }
}
