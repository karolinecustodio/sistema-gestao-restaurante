﻿using GestaoRestaurante.Api.Context;
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

        public async Task<Pedido> Update(Pedido pedido)
        {
            _context.Entry(pedido).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return pedido;
        }

        public async Task<IEnumerable<Pedido>> GetPedidosPorIntervaloDeData(DateTime dataInicial, DateTime dataFinal)
        {
            var pedidos = await _context.Pedido
                .Where(pedido => pedido.DataEmissao.Date >= dataInicial.Date && pedido.DataEmissao.Date <= dataFinal.Date)
                .ToListAsync();

            return pedidos;
        }

        public async Task<IEnumerable<Pedido>> GetPedidosPorIntervaloDeDataEId(int id, DateTime dataInicial, DateTime dataFinal)
        {
            var pedidos = await _context.Pedido
                .Where(pedido => pedido.DataEmissao.Date >= dataInicial.Date 
                        && pedido.DataEmissao.Date <= dataFinal.Date
                        && pedido.UsuarioId == id)
                .ToListAsync();

            return pedidos;
        }
    }
}
