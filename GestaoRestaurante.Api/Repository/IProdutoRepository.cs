using GestaoRestaurante.Api.Entities;

namespace GestaoRestaurante.Api.Repository
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> GetItens();
        Task<Produto> GetItem(int id);
        Task<IEnumerable<Produto>> GetItensPorCategoria(int id);
    }
}