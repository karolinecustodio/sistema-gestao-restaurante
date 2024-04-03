using GestaoRestaurante.Api.Entities;

namespace GestaoRestaurante.Api.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetByIdUsuario(int id);
        Task<Usuario> PostByUsuario(Usuario usuario);
        Task<Usuario> GetByEmailAndSenhaUsuario(string email, string senha);
        Task<Usuario> GetByEmailUsuario(string email);
        Task<bool> UpdateSenha(string email, string novaSenha);
    }
}
