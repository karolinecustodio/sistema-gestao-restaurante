using GestaoRestaurante.Api.Entities;
using GestaoRestaurante.Api.Mappings;
using GestaoRestaurante.Api.Repositories;
using GestaoRestaurante.Models.Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace GestaoRestaurante.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController: ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDto>>> GetItens()
        {
            try
            {
                var produtos = await _produtoRepository.GetItens();
                if (produtos is null)
                {
                    return NotFound();
                }
                else
                {
                    var produtosDtos = produtos.ConverterProdutosParaDto();
                    return Ok(produtosDtos);
                }
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao acessar a base de dados");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<ProdutoDto>>> GetByIdProduto(int id)
        {
            try
            {
                var produto = await _produtoRepository.GetByIdProduto(id);
                if (produto is null)
                {
                    return NotFound("Produto não localizado.");
                }
                else
                {
                    var produtoDto = produto.ConverterProdutoParaDto();
                    return Ok(produtoDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao acessar a base de dados");
            }
        }

        [HttpGet]
        [Route("GetItensPorCategoria/{categoriaId}")]
        public async Task<ActionResult<IEnumerable<ProdutoDto>>> GetItensPorCategoria(int categoriaId)
        {
            try
            {
                var produtos = await _produtoRepository.GetItensPorCategoria(categoriaId);
                if (produtos is null)
                {
                    return NotFound();
                }
                else
                {
                    var produtosDtos = produtos.ConverterProdutosParaDto();
                    return Ok(produtosDtos);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao acessar a base de dados");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostByProduto(Produto produto)
        {
            var category = await _produtoRepository.GetByIdProduto(produto.Id);
            if (category is null)
            {
                await _produtoRepository.PostByProduto(produto);
                return CreatedAtAction(nameof(GetByIdProduto), new { id = produto.Id }, produto);
            }
            else
            {
                var categoriaDto = produto.ConverterProdutoParaDto();
                return Ok(categoriaDto);
            }
        }
    }
}