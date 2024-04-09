using GestaoRestaurante.Models.Dto;

namespace GestaoRestaurante.Web.Services
{
    public interface IUsuarioEnderecoService
    {
        Task<IEnumerable<UsuarioEnderecoDto>> GetAllUsuarioEndereco();
        Task<UsuarioEnderecoDto> GetUsuarioEnderecoByUsuarioId(int? usuarioId);
        Task<UsuarioEnderecoDto> PostUsuarioEndereco(UsuarioEnderecoDto usuarioEnderecoDto);
    }
}
