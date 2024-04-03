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

        public async Task<Usuario> GetByEmailAndSenhaUsuario(string email, string senha)
        {
            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(c => c.Email == email && c.Senha == senha );

            return usuario;
        }

        public async Task<Usuario> GetByEmailUsuario(string email)
        {
            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(c => c.Email == email);

            return usuario;
        }

        public async Task<Usuario> PostByUsuario(Usuario usuario)
        {
            if (await UsuarioExiste(usuario.Email) == false)
            {
                usuario.TipoUsuario = TipoUsuario.Cliente;
                _context.Usuario.Add(usuario);
                await _context.SaveChangesAsync();
                return usuario;
            }
            return null;
        }

        public async Task<bool> UpdateSenha(string email, string novaSenha)
        {
            try
            {
                var usuario = await _context.Usuario.FirstOrDefaultAsync(u => u.Email == email);

                if (usuario != null)
                {
                    usuario.Senha = novaSenha;
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar a senha: {ex.Message}");
                return false;
            }
        }

            private async Task<bool> UsuarioExiste(string email)
        {
            return await _context.Usuario.AnyAsync(c => c.Email == email);
        }
    }
}
