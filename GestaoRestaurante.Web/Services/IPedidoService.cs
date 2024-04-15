﻿using GestaoRestaurante.Models.Dto;

namespace GestaoRestaurante.Web.Services
{
    public interface IPedidoService
    {
        Task<IEnumerable<PedidoDto>> GetAllPedidos();
        Task<PedidoDto> GetByIdPedido(int? id);
        Task<PedidoDto> PostPedido(PedidoDto pedidoDto);
    }
}