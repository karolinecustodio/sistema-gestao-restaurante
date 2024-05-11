using GestaoRestaurante.Models.Dto;
using GestaoRestaurante.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestaoRestaurante.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CepController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly ICepService _cepService;

        public CepController(HttpClient httpClient, ICepService cepService)
        {
            _httpClient = httpClient;
            _cepService = cepService;
        }

        [HttpGet("{cep}")]
        public async Task<ActionResult<CepDto>> GetCep(string cep)
        {
            try
            {
                var endereco = await _cepService.GetCep(cep);
                if (endereco == null)
                {
                    return NotFound();
                }
                return Ok(endereco);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter endereço pelo CEP {cep}: {ex.Message}");
            }
        }
    } 
}