using GestaoRestaurante.Api.Context;
using GestaoRestaurante.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestaoRestaurante.Api.Repositories
{
    public class UsuarioEnderecoRepository : IUsuarioEnderecoRepository
    {
        private readonly AppDbContext _context;

        public UsuarioEnderecoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UsuarioEndereco> GetByIdUsuarioEndereco(int id)
        {
            var usuarioEndereco = await _context.UsuarioEndereco
                .Include(u => u.Usuario)
                .Include(e => e.Endereco)
                .FirstOrDefaultAsync(ue => ue.Id == id);

            return usuarioEndereco;
        }

        public async Task<List<UsuarioEndereco>> GetAllUsuarioEnderecos()
        {
            return await _context.UsuarioEndereco.ToListAsync();
        }

        public async Task<List<UsuarioEndereco>> GetUsuarioEnderecosByUsuarioId(int usuarioId)
        {
            return await _context.UsuarioEndereco
                .Where(ue => ue.UsuarioId == usuarioId)
                .ToListAsync();
        }

        public async Task<List<UsuarioEndereco>> GetUsuarioEnderecosByEnderecoId(int enderecoId)
        {
            return await _context.UsuarioEndereco
                .Where(ue => ue.EnderecoId == enderecoId)
                .ToListAsync();
        }

        public async Task<UsuarioEndereco> PostByUsuarioEnderecos(UsuarioEndereco usuarioEndereco)
        {
            _context.UsuarioEndereco.Add(usuarioEndereco);
            await _context.SaveChangesAsync();

            return usuarioEndereco;
        }
    }
}
