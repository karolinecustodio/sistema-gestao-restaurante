using GestaoRestaurante.Api.Context;
using GestaoRestaurante.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestaoRestaurante.Api.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Produto> GetByIdProduto(int id)
        {
            var produto = await _context.Produto
                .Include(c => c.Categoria)
                .SingleOrDefaultAsync(c => c.Id == id);

            return produto;
        }

        public async Task<IEnumerable<Produto>> GetItens()
        {
            var produto = await _context.Produto
                .Include(p => p.Categoria)
                .ToListAsync();

            return produto;
        }

        public async Task<IEnumerable<Produto>> GetItensPorCategoria(int id)
        {
            var produto = await _context.Produto
                .Include(p => p.Categoria)
                .Where(p => p.CategoriaId == id)
                .ToListAsync();

            return produto;
        }

        public async Task<Produto> PostByProduto(Produto produto)
        {
            _context.Produto.Add(produto);
            await _context.SaveChangesAsync();

            return produto;
        }
    }
}
