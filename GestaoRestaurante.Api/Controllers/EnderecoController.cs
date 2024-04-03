using GestaoRestaurante.Api.Entities;
using GestaoRestaurante.Api.Mappings;
using GestaoRestaurante.Api.Repositories;
using GestaoRestaurante.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GestaoRestaurante.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoController(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<EnderecoDto>>> GetByIdEndereco(int id)
        {
            try
            {
                var endereco = await _enderecoRepository.GetByIdEndereco(id);
                if (endereco is null)
                {
                    return NotFound();
                }
                else
                {
                    var enderecoDto = endereco.ConverterEnderecoParaDto();
                    return Ok(enderecoDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao acessar a base de dados");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnderecoDto>>> GetAllEndereco()
        {
            try
            {
                var enderecos = await _enderecoRepository.GetAllEndereco();
                if (enderecos is null)
                {
                    return NotFound();
                }
                else
                {
                    var enderecoDto = enderecos.ConverterEnderecosParaDto();
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
        public async Task<IActionResult> PostByEndereco(Endereco endereco)
        {
            var user = await _enderecoRepository.GetByIdEndereco(endereco.Id);
            if (user is null)
            {
                await _enderecoRepository.PostByEndereco(endereco);
                return CreatedAtAction(nameof(GetByIdEndereco), new { id = endereco.Id }, endereco);
            }
            else
            {
                var enderecoDto = endereco.ConverterEnderecoParaDto();
                return Ok(enderecoDto);
            }
        }
    }
}
