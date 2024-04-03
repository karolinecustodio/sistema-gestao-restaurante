using GestaoRestaurante.Api.Entities;
using GestaoRestaurante.Api.Mappings;
using GestaoRestaurante.Api.Repositories;
using GestaoRestaurante.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GestaoRestaurante.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<CategoriaDto>>> GetByIdCategoria(int id)
        {
            try
            {
                var categoria = await _categoriaRepository.GetByIdCategoria(id);
                if (categoria is null)
                {
                    return NotFound();
                }
                else
                {
                    var categoriaDto = categoria.ConverterCategoriaParaDto();
                    return Ok(categoriaDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao acessar a base de dados");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDto>>> GetAllCategoria()
        {
            try
            {
                var categorias = await _categoriaRepository.GetAllCategoria();
                if (categorias is null)
                {
                    return NotFound();
                }
                else
                {
                    var categoriasDto = categorias.ConverterCategoriasParaDto();
                    return Ok(categoriasDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao acessar a base de dados");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostByCategoria(Categoria categoria)
        {
            var category = await _categoriaRepository.GetByIdCategoria(categoria.Id);
            if (category is null)
            {
                await _categoriaRepository.PostByCategoria(categoria);
                return CreatedAtAction(nameof(GetByIdCategoria), new { id = categoria.Id }, categoria);
            }
            else
            {
                var categoriaDto = categoria.ConverterCategoriaParaDto();
                return Ok(categoriaDto);
            }
        }
    }
}
