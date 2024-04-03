using GestaoRestaurante.Api.Entities;
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
                    var categoriaDto = pedido.ConverterPedidoParaDto();
                    return Ok(categoriaDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao acessar a base de dados");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostByCategoria(Produto produto)
        {
            var prod = await _pedidoRepository.GetByIdPedido(produto.Id);
            if (prod is null)
            {
                await _pedidoRepository.PostByPedido(prod);
                return CreatedAtAction(nameof(GetByIdPedido), new { id = produto.Id }, produto);
            }
            else
            {
                var produtoDto = prod.ConverterPedidoParaDto();
                return Ok(produtoDto);
            }
        }
    }
}
