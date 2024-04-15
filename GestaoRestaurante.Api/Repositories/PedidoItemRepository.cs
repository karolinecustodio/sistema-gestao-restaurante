using GestaoRestaurante.Api.Context;
using GestaoRestaurante.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestaoRestaurante.Api.Repositories
{
    public class PedidoItemRepository : IPedidoItemRepository
    {
        private readonly AppDbContext _context;

        public PedidoItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PedidoItem> GetPedidoItemById(int id)
        {
            var pedidoItem = await _context.PedidoItem
                .FirstOrDefaultAsync(pI => pI.Id == id);

            return pedidoItem;
        }

        public async Task<PedidoItem> GetPedidoItemByProdutoId(int produtoId)
        {
            var pedidoItem = await _context.PedidoItem
                .Include(pod => pod.Produto)
                .FirstOrDefaultAsync(pod => pod.ProdutoId == produtoId);

            return pedidoItem;
        }

        public async Task<List<PedidoItem>> GetPedidoItemByPedidoId(int pedidoId)
        {
            return await _context.PedidoItem
                .Where(ped => ped.PedidoId == pedidoId)
                .ToListAsync();
        }

        public async Task<List<PedidoItem>> GetAllPedidoItem()
        {
            return await _context.PedidoItem.ToListAsync();
        }

        public async Task<PedidoItem> PostPedidoItem(PedidoItem pedidoItem)
        {
            _context.PedidoItem.Add(pedidoItem);
            await _context.SaveChangesAsync();

            return pedidoItem;
        }

        public async Task<PedidoItem> UpdatePedidoItem(PedidoItem pedidoItem)
        {
            _context.Entry(pedidoItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return pedidoItem;
        }
    }
}
