using GestaoRestaurante.Models.Dto;

namespace GestaoRestaurante.Web.Services
{
    public interface IGerenciaProdutosLocalStorageService
    {
        Task<IEnumerable<ProdutoDto>> GetCollection();
        Task RemoveCollection();
    }
}
