using GestaoRestaurante.Models.Dto;

namespace GestaoRestaurante.Web.Services
{
    public interface IGerenciaCarrinhoItensLocalStorageService
    {
        Task<List<CarrinhoItemDto>> GetCollection();
        Task SaveCollection(List<CarrinhoItemDto> carrinhoItensDto);
        Task RemoveCollection();
    }
}
