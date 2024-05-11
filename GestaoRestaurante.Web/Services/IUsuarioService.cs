using GestaoRestaurante.Models.Dto;

namespace GestaoRestaurante.Web.Services
{
    public interface IUsuarioService
    {
        Task<UsuarioDto> GetByIdUsuario(int id);
        Task<UsuarioDto> AdicionaUsuario(UsuarioDto usuarioDto);
        Task<UsuarioDto> GetByEmailSenhaUsuario(string email, string senha);
        Task<UsuarioDto> GetByEmailUsuario(string email);
        Task AtualizarSenha(string email, string novaSenha);
    }
}
