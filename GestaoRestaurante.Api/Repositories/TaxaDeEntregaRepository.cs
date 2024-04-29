using GestaoRestaurante.Api.Context;
using GestaoRestaurante.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestaoRestaurante.Api.Repositories
{
    public class TaxaDeEntregaRepository : ITaxaDeEntregaRepository
    {
        private readonly AppDbContext _context;

        public TaxaDeEntregaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaxaEntrega>> GetAllTaxaEntrega()
        {
            var taxa = await _context.TaxaEntrega
            .AsNoTracking()
            .ToListAsync();

            return taxa;
        }

        public async Task<TaxaEntrega> GetTaxaEntregaByNomeBairro(string bairro)
        {
            var taxa = await _context.TaxaEntrega
                .SingleOrDefaultAsync(c => c.NomeBairro == bairro);

            return taxa;
        }

        public async Task<TaxaEntrega> GetByIdTaxaEntrega(int id)
        {
            var taxa = await _context.TaxaEntrega
                .SingleOrDefaultAsync(c => c.Id == id);

            return taxa;
        }

        public async Task<TaxaEntrega> PostTaxaEntrega(TaxaEntrega taxaEntrega)
        {
            _context.TaxaEntrega.Add(taxaEntrega);
            await _context.SaveChangesAsync();
            return taxaEntrega;
        }

        public async Task<bool> UpdateTaxaEntrega(string nomeBairro)
        {
            try
            {
                var taxa = await _context.TaxaEntrega.FirstOrDefaultAsync(u => u.NomeBairro == nomeBairro);

                if (taxa != null)
                {
                    taxa.NomeBairro = nomeBairro;
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar a taxa de entrega: {ex.Message}");
                return false;
            }
        }

    }
}
