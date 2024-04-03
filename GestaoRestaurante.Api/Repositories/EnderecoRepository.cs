using GestaoRestaurante.Api.Context;
using GestaoRestaurante.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestaoRestaurante.Api.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly AppDbContext _context;

        public EnderecoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Endereco> GetByIdEndereco(int id)
        {
            var endereco = await _context.Endereco
                .SingleOrDefaultAsync(c => c.Id == id);

            return endereco;
        }

        public async Task<IEnumerable<Endereco>> GetAllEndereco()
        {
            var enderecos = await _context.Endereco
            .AsNoTracking()
            .ToListAsync();

            return enderecos;
        }

        public async Task<Endereco> PostByEndereco(Endereco endereco)
        {
            _context.Endereco.Add(endereco);
            await _context.SaveChangesAsync();

            return endereco;
        }
    }
}
