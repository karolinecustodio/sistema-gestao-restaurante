using GestaoRestaurante.Api.Entities;
using GestaoRestaurante.Api.Repositories;
using GestaoRestaurante.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using GestaoRestaurante.Api.Mappings;

namespace GestaoRestaurante.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoItemController : ControllerBase
    {
        private readonly IPedidoItemRepository _repository;

        public PedidoItemController(IPedidoItemRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoItemDto>>> GetAllPedidoItem()
        {
            var pedidoItens = await _repository.GetAllPedidoItem();
            return Ok(pedidoItens);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoItemDto>> GetPedidoItemById(int id)
        {
            try
            {
                var pedidoItem = await _repository.GetPedidoItemById(id);
                if (pedidoItem is null)
                {
                    return NotFound();
                }
                else
                {
                    var pedidoItemDto = pedidoItem.ConverterPedidoItemParaDto();
                    return Ok(pedidoItemDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao acessar a base de dados");
            }

        }

        [HttpGet("{produtoId}")]
        public async Task<ActionResult<PedidoItemDto>> GetPedidoItemByProdutoId(int produtoId)
        {
            try
            {
                var pedidoItem = await _repository.GetPedidoItemByProdutoId(produtoId);
                if (pedidoItem is null)
                {
                    return NotFound();
                }
                else
                {
                    var pedidoItemDto = pedidoItem.ConverterPedidoItemParaDto();
                    return Ok(pedidoItemDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao acessar a base de dados");
            }

        }

        [HttpGet("{pedidoId}")]
        public async Task<ActionResult<PedidoItemDto>> GetPedidoItemByPedidoId(int pedidoId)
        {
            try
            {
                var pedidoItem = await _repository.GetPedidoItemByPedidoId(pedidoId);
                if (pedidoItem is null)
                {
                    return NotFound();
                }
                else
                {
                    var pedidoItemDto = pedidoItem.ConverterPedidoItemParaDto();
                    return Ok(pedidoItemDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao acessar a base de dados");
            }

        }

        [HttpPost]
        public async Task<ActionResult<PedidoItemDto>> PostPedidoItem(PedidoItem pedidoItem)
        {
            try
            {
                var existingPedidoItem = await _repository.GetPedidoItemById(pedidoItem.Id);
                if (existingPedidoItem != null)
                {
                    existingPedidoItem.PedidoId = existingPedidoItem.Id;

                    await _repository.UpdatePedidoItem(existingPedidoItem);

                    var options = new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.Preserve
                    };

                    return Ok(JsonSerializer.Serialize(existingPedidoItem, options));
                }
                else
                {
                    var createdPedidoItem = await _repository.PostPedidoItem(pedidoItem);
                    return CreatedAtAction(nameof(GetPedidoItemById), new { id = createdPedidoItem.Id }, createdPedidoItem);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
