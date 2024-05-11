using GestaoRestaurante.Models.Dto;

namespace GestaoRestaurante.Web.Services
{
    public interface ICepService
    {
        Task<CepDto> GetCep(string cep);
    }
}
