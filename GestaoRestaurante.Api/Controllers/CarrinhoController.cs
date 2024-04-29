using GestaoRestaurante.Api.Entities;
using GestaoRestaurante.Api.Mappings;
using GestaoRestaurante.Api.Repositories;
using GestaoRestaurante.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GestaoRestaurante.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrinhoController : ControllerBase
    {
        private readonly ICarrinhoRepository _carrinhoRepo;
        private ILogger<CarrinhoCompraController> logger;

        public CarrinhoController(ICarrinhoRepository
            carrinhoRepo,
            ILogger<CarrinhoCompraController> logger)
        {
            _carrinhoRepo = carrinhoRepo;
            this.logger = logger;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<CarrinhoDto>>> GetByIdCarrinho(int id)
        {
            try
            {
                var carrinho = await _carrinhoRepo.GetByIdCarrinho(id);
                if (carrinho is null)
                {
                    return NotFound();
                }
                else
                {
                    var carrinhoDto = carrinho.ConverterCarrinhoParaDto();
                    return Ok(carrinhoDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao acessar a base de dados");
            }
        }

        [HttpGet("{usuarioId}")]
        public async Task<ActionResult<List<CarrinhoDto>>> GetCarrinhoByUsuarioId(int usuarioId)
        {
            try
            {
                var carrinhos = await _carrinhoRepo.GetCarrinhoByUsuarioId(usuarioId);
                if (carrinhos == null || !carrinhos.Any())
                {
                    return NotFound();
                }

                var carrinhosDto = carrinhos.Select(c => c.ConverterCarrinhoParaDto()).ToList();

                return Ok(carrinhosDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao acessar a base de dados");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarrinhoDto>>> GetAllCarrinho()
        {
            try
            {
                var carrinhos = await _carrinhoRepo.GetAllCarrinhos();
                if (carrinhos is null)
                {
                    return NotFound();
                }
                else
                {
                    var carrinhoDto = carrinhos.ConverterCarrinhosParaDto();
                    return Ok(carrinhoDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao acessar a base de dados");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostCarrinho(Carrinho carrinho)
        {
            var user = await _carrinhoRepo.GetByIdCarrinho(carrinho.Id);
            if (user is null)
            {
                await _carrinhoRepo.PostByCarrinho(carrinho);
                return CreatedAtAction(nameof(GetByIdCarrinho), new { id = carrinho.Id }, carrinho);
            }
            else
            {
                var carrinhoDto = carrinho.ConverterCarrinhoParaDto();
                return Ok(carrinhoDto);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CarrinhoDto>> DeleteCarrinho(int id)
        {
            try
            {
                var carrinho = await _carrinhoRepo.DeleteCarrinho(id);

                if (carrinho == null)
                {
                    return NotFound();
                }

                var carrinhoDto = carrinho.ConverterCarrinhoParaDto();
                return Ok(carrinhoDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
