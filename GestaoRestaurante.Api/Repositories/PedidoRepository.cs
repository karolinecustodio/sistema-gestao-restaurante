using GestaoRestaurante.Api.Context;
using GestaoRestaurante.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestaoRestaurante.Api.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _context;

        public PedidoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Pedido> GetByIdPedido(int id)
        {
            var pedido = await _context.Pedido
                .SingleOrDefaultAsync(c => c.Id == id);

            return pedido;
        }

        public async Task<IEnumerable<Pedido>> GetAllPedido()
        {
            var pedidos = await _context.Pedido
            .AsNoTracking()
            .ToListAsync();

            return pedidos;
        }

        public async Task<Pedido> PostByPedido(Pedido pedido)
        {
            _context.Pedido.Add(pedido);
            await _context.SaveChangesAsync();

            return pedido;
        }
    }
}
