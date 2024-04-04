using GestaoRestaurante.Api.Entities;

namespace GestaoRestaurante.Api.Repositories
{
    public interface IUsuarioEnderecoRepository
    {
        Task<UsuarioEndereco> GetByIdUsuarioEndereco(int id);
        Task<List<UsuarioEndereco>> GetAllUsuarioEnderecos();
        Task<List<UsuarioEndereco>> GetUsuarioEnderecosByUsuarioId(int usuarioId);
        Task<List<UsuarioEndereco>> GetUsuarioEnderecosByEnderecoId(int enderecoId);
        Task<UsuarioEndereco> PostByUsuarioEnderecos(UsuarioEndereco usuarioEndereco);
    }
}