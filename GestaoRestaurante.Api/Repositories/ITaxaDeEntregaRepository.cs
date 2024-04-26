using GestaoRestaurante.Api.Entities;
using GestaoRestaurante.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GestaoRestaurante.Api.Repositories
{
    public interface ITaxaDeEntregaRepository
    {
        Task<IEnumerable<TaxaEntrega>> GetAllTaxaEntrega();
        Task<TaxaEntrega> GetByIdTaxaEntrega(int id);
        Task<TaxaEntrega> PostTaxaEntrega(TaxaEntrega taxaEntrega);
        Task<bool> UpdateTaxaEntrega(string nomeBairro);
    }
}
