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
            var usuario = await _context.Usuarios
                .SingleOrDefaultAsync(c => c.Id == id);

            return usuario;
        }

        public async Task<Usuario> PostByUsuario(Usuario usuario)
        {
            if (await UsuarioJaExiste(usuario.Id) == false)
            {
                var retornaUsuario = await (from usuarios in _context.Usuarios
                                  where usuario.Id == usuario.Id
                                  select new Usuario
                                  {
                                      Id = usuario.Id,
                                      NomeUsuario = usuario.NomeUsuario
                                  }).SingleOrDefaultAsync();

                if (retornaUsuario is not null)
                {
                    var resultado = await _context.Usuarios.AddAsync(retornaUsuario);
                    await _context.SaveChangesAsync();
                    return resultado.Entity;
                }
            }
            return null;
        }

        private async Task<bool> UsuarioJaExiste(int usuarioId)
        {
            return await _context.Usuarios.AnyAsync(c => c.Id == usuarioId);
        }
    }
}
