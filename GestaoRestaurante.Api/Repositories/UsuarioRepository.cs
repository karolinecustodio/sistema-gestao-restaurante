using GestaoRestaurante.Api.Context;
using GestaoRestaurante.Api.Entities;
using GestaoRestaurante.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoRestaurante.Api.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> GetByIdUsuario(int id)
        {
            var usuario = await _context.Usuario
                .SingleOrDefaultAsync(c => c.Id == id);

            return usuario;
        }

        public async Task<Usuario> PostByUsuario(Usuario usuario)
        {
            if (await UsuarioJaExiste(usuario.Email) == false)
            {
                usuario.TipoUsuario = TipoUsuario.Cliente;
                _context.Usuario.Add(usuario);
                await _context.SaveChangesAsync();
                return usuario;
            }
            return null;
        }

        private async Task<bool> UsuarioJaExiste(string email)
        {
            return await _context.Usuario.AnyAsync(c => c.Email == email);
        }
    }
}
