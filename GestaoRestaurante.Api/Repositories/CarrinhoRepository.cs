using GestaoRestaurante.Api.Context;
using GestaoRestaurante.Api.Entities;
using GestaoRestaurante.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace GestaoRestaurante.Api.Repositories
{
    public class CarrinhoRepository : ICarrinhoRepository
    {
        private readonly AppDbContext _context;
        public CarrinhoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Carrinho> GetByIdCarrinho(int id)
        {
            var carrinho = await _context.Carrinho
                .SingleOrDefaultAsync(c => c.Id == id);

            return carrinho;
        }
        public async Task<List<Carrinho>> GetCarrinhoByUsuarioId(int usuarioId)
        {
            return await _context.Carrinho
                .Where(ue => ue.UsuarioId == usuarioId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Carrinho>> GetAllCarrinhos()
        {
            var carrinhos = await _context.Carrinho
            .AsNoTracking()
            .ToListAsync();

            return carrinhos;
        }

        public async Task<Carrinho> PostByCarrinho(Carrinho carrinho)
        {
            _context.Carrinho.Add(carrinho);
            await _context.SaveChangesAsync();

            return carrinho;
        }

        public async Task<Carrinho> DeleteCarrinho(int id)
        {
            var carrinho = await _context.Carrinho.FindAsync(id);

            if (carrinho is not null)
            {
                _context.Carrinho.Remove(carrinho);
                await _context.SaveChangesAsync();
            }
            return carrinho;
        }
    }
}
