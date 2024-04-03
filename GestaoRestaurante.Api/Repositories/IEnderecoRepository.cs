using GestaoRestaurante.Api.Entities;

namespace GestaoRestaurante.Api.Repositories
{
    public interface IEnderecoRepository
    {
        Task<Endereco> GetByIdEndereco(int id);
        Task<IEnumerable<Endereco>> GetAllEndereco();
        Task<Endereco> PostByEndereco(Endereco endereco);
    }
}
