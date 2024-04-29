using GestaoRestaurante.Api.Entities;
using GestaoRestaurante.Models.Dto;

namespace GestaoRestaurante.Api.Repositories
{
    public interface ICarrinhoRepository
    {
        Task<Carrinho> GetByIdCarrinho(int id);
        Task<List<Carrinho>> GetCarrinhoByUsuarioId(int usuarioId);
        Task<IEnumerable<Carrinho>> GetAllCarrinhos();
        Task<Carrinho> PostByCarrinho(Carrinho carrinho);

        Task<Carrinho> DeleteCarrinho(int id);
    }
}
