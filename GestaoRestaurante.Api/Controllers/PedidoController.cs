﻿using GestaoRestaurante.Api.Entities;
using GestaoRestaurante.Api.Mappings;
using GestaoRestaurante.Api.Repositories;
using GestaoRestaurante.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GestaoRestaurante.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {

        private readonly IPedidoRepository _pedidoRepository;

        public PedidoController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<PedidoDto>>> GetByIdPedido(int id)
        {
            try
            {
                var pedido = await _pedidoRepository.GetByIdPedido(id);
                if (pedido is null)
                {
                    return NotFound();
                }
                else
                {
                    var pedidoDto = pedido.ConverterPedidoParaDto();
                    return Ok(pedidoDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao acessar a base de dados");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoDto>>> GetAllPedido()
        {
            try
            {
                var pedidos = await _pedidoRepository.GetAllPedido();
                if (pedidos is null)
                {
                    return NotFound();
                }
                else
                {
                    var enderecoDto = pedidos.ConverterPedidosParaDto();
                    return Ok(enderecoDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao acessar a base de dados");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostByPedido(Pedido pedido)
        {
            var existingPedido = await _pedidoRepository.GetByIdPedido(pedido.Id);

            if (existingPedido == null)
            {
                await _pedidoRepository.PostByPedido(pedido);
                return CreatedAtAction(nameof(GetByIdPedido), new { id = pedido.Id }, pedido);
            }
            else
            {
                existingPedido.DataEmissao = pedido.DataEmissao;
                existingPedido.ValorPedido = pedido.ValorPedido;
                existingPedido.EnderecoId = pedido.EnderecoId;
                existingPedido.UsuarioId = pedido.UsuarioId;
                existingPedido.TaxaId = pedido.TaxaId;
                existingPedido.FormaPagamento = pedido.FormaPagamento;
                existingPedido.StatusPedido = pedido.StatusPedido;

                await _pedidoRepository.Update(existingPedido);

                var pedidoDto = existingPedido.ConverterPedidoParaDto();
                return Ok(pedidoDto);
            }
        }

        [HttpGet("porIntervaloDeData/{dataInicial}/{dataFinal}")]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidosPorIntervaloDeData( DateTime dataInicial, DateTime dataFinal)
        {
            try
            {
                var pedidos = await _pedidoRepository.GetPedidosPorIntervaloDeData(dataInicial, dataFinal);
                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao obter pedidos: {ex.Message}");
            }
        }

        [HttpGet("porIntervaloDeDataEId/{dataInicial}/{dataFinal}/{id}")]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidosPorIntervaloDeDataEId(int id, DateTime dataInicial, DateTime dataFinal)
        {
            try
            {
                var pedidos = await _pedidoRepository.GetPedidosPorIntervaloDeDataEId(id, dataInicial, dataFinal);
                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao obter pedidos: {ex.Message}");
            }
        }
    }
}
