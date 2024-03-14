using GestaoRestaurante.Api.Entities;
using GestaoRestaurante.Models.Dto;

namespace GestaoRestaurante.Api.Repositories
{
    public interface ICarrinhoCompraRepository
    {
        Task<CarrinhoItem> AdicionaItem(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto);

        Task<CarrinhoItem> AtualizaQuantidade(int id, CarrinhoItemAtualizaQuantidadeDto
            carrinhoItemAtualizaQuantidadeDto);

        Task<CarrinhoItem> DeletaItem(int id);

        Task<CarrinhoItem> GetItem(int id);

        Task<IEnumerable<CarrinhoItem>> GetItens(int usuarioId);
    }
}
