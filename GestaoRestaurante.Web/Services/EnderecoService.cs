using GestaoRestaurante.Models.Dto;
using System.Net.Http.Json;
using System.Net;

namespace GestaoRestaurante.Web.Services
{
    public class EnderecoService : IEnderecoService
    {
        public HttpClient _httpClient;
        public ILogger<EnderecoService> _logger;

        public EnderecoService(HttpClient httpClient, ILogger<EnderecoService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<IEnumerable<EnderecoDto>> GetAllUsuarioEndereco()
        {
            try
            {
                var enderecosDto = await _httpClient.GetFromJsonAsync<IEnumerable<EnderecoDto>>("api/endereco");

                return enderecosDto;
            }
            catch (Exception)
            {
                _logger.LogError("Erro ao acessar produtos: api/usuarioEndereco");
                throw;
            }
        }

        public async Task<EnderecoDto> GetByIdEndereco(int? id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/endereco/{id}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return default(EnderecoDto);
                    }
                    return await response.Content.ReadFromJsonAsync<EnderecoDto>();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                _logger.LogError($"Erro a obter produto pelo id={id}");
                throw;
            }
        }

        public async Task<EnderecoDto> PostEndereco(EnderecoDto enderecoDto)
        {
            try
            {
                var response = await _httpClient
                              .PostAsJsonAsync<EnderecoDto>("api/endereco",
                               enderecoDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return default(EnderecoDto);
                    }
                    return await response.Content.ReadFromJsonAsync<EnderecoDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"{response.StatusCode} Message -{message}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao processar a resposta: {ex.Message}");
            }
        }
    }
}
