using GestaoRestaurante.Models.Dto;

namespace GestaoRestaurante.Web.Services
{
    public interface IGerenciaCarrinhoItensLocalStorageService
    {
        Task<List<CarrinhoItemDto>> GetCollection(UsuarioLogado usuarioLogado);
        Task SaveCollection(List<CarrinhoItemDto> carrinhoItensDto);
        Task RemoveCollection();
    }
}
