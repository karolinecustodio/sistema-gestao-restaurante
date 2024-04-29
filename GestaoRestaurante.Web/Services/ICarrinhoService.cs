using GestaoRestaurante.Models.Dto;
using System.Threading.Tasks;

namespace GestaoRestaurante.Web.Services
{
    public interface ICarrinhoService
    {
        Task<IEnumerable<CarrinhoDto>> GetAllCarrinho();
        Task<CarrinhoDto> GetByIdCarrinho(int? carrinhoId);
        Task<CarrinhoDto> GetCarrinhoByUsuarioId(int? usuarioId);
        Task<CarrinhoDto> PostCarrinho(CarrinhoDto carrinhoDto);
        Task DeleteCarrinho(int carrinhoId);
    }
}
