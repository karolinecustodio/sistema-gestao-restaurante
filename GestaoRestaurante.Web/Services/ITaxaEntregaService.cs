using GestaoRestaurante.Models.Dto;

namespace GestaoRestaurante.Web.Services
{
    public interface ITaxaEntregaService
    {
        Task<IEnumerable<TaxaEntregaDto>> GetAllTaxaDeEntrega();
        Task<TaxaEntregaDto> GetByIdTaxaEntrega(int id);
        Task<TaxaEntregaDto> PostTaxaEntrega(TaxaEntregaDto taxaEntregaDto);
        Task AtualizaTaxaEntrega(string nomeBairro);
    }
}
