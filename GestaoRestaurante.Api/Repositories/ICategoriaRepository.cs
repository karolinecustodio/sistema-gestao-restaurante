using GestaoRestaurante.Api.Entities;

namespace GestaoRestaurante.Api.Repositories
{
    public interface ICategoriaRepository
    {
        Task<Categoria> GetByIdCategoria(int id);
        Task<IEnumerable<Categoria>> GetAllCategoria();
        Task<Categoria> PostByCategoria(Categoria categoria);
    }
}
