using GestaoRestaurante.Models.Dto;

namespace GestaoRestaurante.Web.Services
{
    public interface IEnderecoService
    {
        Task<IEnumerable<EnderecoDto>> GetAllUsuarioEndereco();
        Task<EnderecoDto> GetByIdEndereco(int? id);
        Task<EnderecoDto> PostEndereco(EnderecoDto enderecoDto);
    }
}
