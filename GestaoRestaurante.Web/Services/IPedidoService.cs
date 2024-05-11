using GestaoRestaurante.Models.Dto;

namespace GestaoRestaurante.Web.Services
{
    public interface IPedidoService
    {
        Task<IEnumerable<PedidoDto>> GetAllPedidos();
        Task<PedidoDto> GetByIdPedido(int? id);
        Task<PedidoDto> PostPedido(PedidoDto pedidoDto);
        Task<IEnumerable<PedidoDto>> GetPedidosPorIntervaloDeData(DateTime dataInicial, DateTime dataFinal);
        Task<IEnumerable<PedidoDto>> GetPedidosPorIntervaloDeDataEId(int id, DateTime dataInicial, DateTime dataFinal);
    }
}
