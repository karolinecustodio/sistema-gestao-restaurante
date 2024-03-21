using GestaoRestaurante.Models.Dto;

namespace GestaoRestaurante.Web.Services
{
    public interface IUsuarioService
    {
        Task<UsuarioDto> GetByIdUsuario(int id);
        Task<UsuarioDto> AdicionaUsuario(UsuarioDto usuarioDto);
    }
}
