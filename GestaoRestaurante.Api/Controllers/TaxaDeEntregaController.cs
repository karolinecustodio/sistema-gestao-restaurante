using GestaoRestaurante.Api.Entities;
using GestaoRestaurante.Api.Mappings;
using GestaoRestaurante.Api.Repositories;
using GestaoRestaurante.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GestaoRestaurante.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxaDeEntregaController : ControllerBase
    {
        private readonly ITaxaDeEntregaRepository _taxaDeEntregaRepository;

        public TaxaDeEntregaController(ITaxaDeEntregaRepository taxaDeEntregaRepository)
        {
            _taxaDeEntregaRepository = taxaDeEntregaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaxaEntregaDto>>> GetAllTaxaEntrega()
        {
            try
            {
                var taxas = await _taxaDeEntregaRepository.GetAllTaxaEntrega();
                if (taxas is null)
                {
                    return NotFound();
                }
                else
                {
                    var taxaDto = taxas.ConverterTaxaEntregasParaDto();
                    return Ok(taxaDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao acessar a base de dados");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<TaxaEntregaDto>>> GetByIdTaxaEntrega(int id)
        {
            try
            {
                var usuario = await _taxaDeEntregaRepository.GetByIdTaxaEntrega(id);
                if (usuario is null)
                {
                    return Ok();
                }
                else
                {
                    var usuarioDto = usuario.ConverterTaxaEntregaParaDto();
                    return Ok(usuarioDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao acessar a base de dados");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostTaxaEntrega(TaxaEntrega taxaEntrega)
        {
            var taxa = await _taxaDeEntregaRepository.GetByIdTaxaEntrega(taxaEntrega.Id);
            if (taxa is null)
            {
                await _taxaDeEntregaRepository.PostTaxaEntrega(taxaEntrega);
                return CreatedAtAction(nameof(GetByIdTaxaEntrega), new { id = taxaEntrega.Id }, taxaEntrega);
            }
            else
            {
                var usuarioDto = taxaEntrega.ConverterTaxaEntregaParaDto();
                return Ok(usuarioDto);
            }
        }

        [HttpPut("altera-taxaEntrega/{nomeBairro}")]
        public async Task<IActionResult> UpdateTaxaEntrega(string nomeBairro)
        {
            try
            {
                var usuarioAtualizado = await _taxaDeEntregaRepository.UpdateTaxaEntrega(nomeBairro);

                if (usuarioAtualizado)
                {
                    return Ok("Taxa de Entrega atualizada com sucesso.");
                }
                else
                {
                    return NotFound("Taxa de Entrega não encontrado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar a senha do usuário: {ex.Message}");
            }
        }
    }
}
