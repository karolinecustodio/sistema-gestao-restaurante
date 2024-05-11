﻿using GestaoRestaurante.Models.Dto;

namespace GestaoRestaurante.Web.Services
{
    public interface ICarrinhoCompraService
    {
        Task<List<CarrinhoItemDto>> GetItens(int usuarioId);
        Task<CarrinhoItemDto> AdicionaItem(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto);
        Task<CarrinhoItemDto> DeletaItem(int id);
        Task<CarrinhoItemDto> DeletaItens(int carrinhoId);
        Task<CarrinhoItemDto> AtualizaQuantidade(CarrinhoItemAtualizaQuantidadeDto carrinhoItemAtualizaQuantidadeDto);

        event Action<int> OnCarrinhoCompraChanged;
        void RaiseEventOnCarrinhoCompraChanged(int totalQuantidade);
    }
}
