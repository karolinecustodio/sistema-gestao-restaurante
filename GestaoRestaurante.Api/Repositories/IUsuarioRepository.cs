using GestaoRestaurante.Api.Entities;

namespace GestaoRestaurante.Api.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetByIdUsuario(int id);
        Task<Usuario> PostByUsuario(Usuario usuario);
    }
}
