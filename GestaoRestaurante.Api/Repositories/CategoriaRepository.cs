using GestaoRestaurante.Api.Context;
using GestaoRestaurante.Api.Entities;
using GestaoRestaurante.Web.Pages;
using Microsoft.EntityFrameworkCore;

namespace GestaoRestaurante.Api.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;

        }
        public async Task<IEnumerable<Categoria>> GetAllCategoria()
        {
            var categorias = await _context.Categoria
            .AsNoTracking()
            .ToListAsync();

            return categorias;
        }

        public async Task<Categoria> GetByIdCategoria(int id)
        {
            var categoria = await _context.Categoria
                .SingleOrDefaultAsync(c => c.Id == id);

            return categoria;
        }

        public async Task<Categoria> PostByCategoria(Categoria categoria)
        {
            _context.Categoria.Add(categoria);
            await _context.SaveChangesAsync();

            return categoria;
        }
    }
}
