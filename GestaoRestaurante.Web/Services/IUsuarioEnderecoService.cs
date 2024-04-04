using GestaoRestaurante.Models.Dto;

namespace GestaoRestaurante.Web.Services
{
    public interface IUsuarioEnderecoService
    {
        Task<IEnumerable<UsuarioEnderecoDto>> GetAllUsuarioEndereco();
        Task<UsuarioEnderecoDto> GetByIdUsuarioEndereco(int? id);
        Task<UsuarioEnderecoDto> PostUsuarioEndereco(UsuarioEnderecoDto usuarioEnderecoDto);
    }
}
