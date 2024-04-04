using GestaoRestaurante.Api.Entities;

namespace GestaoRestaurante.Api.Repositories
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> GetItens();
        Task<Produto> GetByIdProduto(int id);
        Task<IEnumerable<Produto>> GetItensPorCategoria(int id);
        Task<Produto> PostByProduto(Produto categoria);
    }
}