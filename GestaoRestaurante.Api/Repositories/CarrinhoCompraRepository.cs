﻿using GestaoRestaurante.Api.Context;
using GestaoRestaurante.Api.Entities;
using GestaoRestaurante.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace GestaoRestaurante.Api.Repositories
{
    public class CarrinhoCompraRepository : ICarrinhoCompraRepository
    {
        private readonly AppDbContext _context;
        public CarrinhoCompraRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CarrinhoItem> AdicionaItem(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto)
        {
            if (await CarrinhoItemJaExiste(carrinhoItemAdicionaDto.CarrinhoId,
                carrinhoItemAdicionaDto.ProdutoId) == false)
            {
                var item = await (from produto in _context.Produto
                                  where produto.Id == carrinhoItemAdicionaDto.ProdutoId
                                  select new CarrinhoItem
                                  {
                                      CarrinhoId = carrinhoItemAdicionaDto.CarrinhoId,
                                      ProdutoId = produto.Id,
                                      Quantidade = carrinhoItemAdicionaDto.Quantidade
                                  }).SingleOrDefaultAsync();

                if (item is not null)
                {
                    var resultado = await _context.CarrinhoItem.AddAsync(item);
                    await _context.SaveChangesAsync();
                    return resultado.Entity;
                }
            }
            return null;
        }

        public async Task<CarrinhoItem> AtualizaQuantidade(int id,
                   CarrinhoItemAtualizaQuantidadeDto carrinhoItemAtualizaQuantidadeDto)
        {
            var carrinhoItem = await _context.CarrinhoItem.FindAsync(id);

            if (carrinhoItem is not null)
            {
                carrinhoItem.Quantidade = carrinhoItemAtualizaQuantidadeDto.Quantidade;
                await _context.SaveChangesAsync();
                return carrinhoItem;
            }
            return null;
        }

        public async Task<CarrinhoItem> DeletaItem(int id)
        {
            var item = await _context.CarrinhoItem.FindAsync(id);

            if (item is not null)
            {
                _context.CarrinhoItem.Remove(item);
                await _context.SaveChangesAsync();
            }
            return item;
        }

        public async Task<CarrinhoItem> GetItem(int id)
        {
            return await (from carrinho in _context.Carrinho
                          join carrinhoItem in _context.CarrinhoItem
                          on carrinho.Id equals carrinhoItem.CarrinhoId
                          where carrinhoItem.Id == id
                          select new CarrinhoItem
                          {
                              Id = carrinhoItem.Id,
                              ProdutoId = carrinhoItem.ProdutoId,
                              Quantidade = carrinhoItem.Quantidade,
                              CarrinhoId = carrinhoItem.CarrinhoId
                          }).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<CarrinhoItem>> GetItens(int usuarioId)
        {
            return await (from carrinho in _context.Carrinho
                          join carrinhoItem in _context.CarrinhoItem
                          on carrinho.Id equals carrinhoItem.CarrinhoId
                          where carrinho.UsuarioId == usuarioId
                          select new CarrinhoItem
                          {
                              Id = carrinhoItem.Id,
                              ProdutoId = carrinhoItem.ProdutoId,
                              Quantidade = carrinhoItem.Quantidade,
                              CarrinhoId = carrinhoItem.CarrinhoId
                          }).ToListAsync();
        }

        private async Task<bool> CarrinhoItemJaExiste(int carrinhoId, int produtoId)
        {
            return await _context.CarrinhoItem.AnyAsync(c => c.CarrinhoId == carrinhoId &&
                                                              c.ProdutoId == produtoId);
        }
    }
}