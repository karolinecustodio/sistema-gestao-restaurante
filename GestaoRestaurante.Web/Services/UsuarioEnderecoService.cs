using GestaoRestaurante.Models.Dto;
using System.Net.Http.Json;
using System.Net;
using System.Net.Http;

namespace GestaoRestaurante.Web.Services
{
    public class UsuarioEnderecoService : IUsuarioEnderecoService
    {
        public HttpClient _httpClient;
        public ILogger<UsuarioEnderecoService> _logger;

        public UsuarioEnderecoService(HttpClient httpClient, ILogger<UsuarioEnderecoService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<IEnumerable<UsuarioEnderecoDto>> GetAllUsuarioEndereco()
        {
            try
            {
                var produtosDto = await _httpClient.GetFromJsonAsync<IEnumerable<UsuarioEnderecoDto>>("api/usuarioEndereco");

                return produtosDto;
            }
            catch (Exception)
            {
                _logger.LogError("Erro ao acessar produtos: api/usuarioEndereco");
                throw;
            }
        }

        public async Task<UsuarioEnderecoDto> GetUsuarioEnderecoByUsuarioId(int? usuarioId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/usuarioEndereco/{usuarioId}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return default(UsuarioEnderecoDto);
                    }
                    return await response.Content.ReadFromJsonAsync<UsuarioEnderecoDto>();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                _logger.LogError($"Erro a obter usuarioEndereco pelo id={usuarioId}");
                throw;
            }
        }

        public async Task<UsuarioEnderecoDto> PostUsuarioEndereco(UsuarioEnderecoDto usuarioEnderecoDto)
        {
            try
            {
                var response = await _httpClient
                              .PostAsJsonAsync<UsuarioEnderecoDto>("api/usuarioEndereco",
                               usuarioEnderecoDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return default(UsuarioEnderecoDto);
                    }
                    return await response.Content.ReadFromJsonAsync<UsuarioEnderecoDto>();
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
