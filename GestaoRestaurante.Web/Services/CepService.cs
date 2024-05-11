using GestaoRestaurante.Models.Dto;
using System.ComponentModel.Design;
using System.Net;
using System.Net.Http.Json;

namespace GestaoRestaurante.Web.Services
{
    public class CepService : ICepService
    {
        public HttpClient _httpClient;
        public ILogger<CepService> _logger;

        public CepService(HttpClient httpClient, ILogger<CepService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<CepDto> GetCep(string cep)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://brasilapi.com.br/api/cep/v1/{cep}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return null;
                    }
                    return await response.Content.ReadFromJsonAsync<CepDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    _logger.LogError($"Erro ao obter endereço pelo CEP {cep} - {message}");
                    throw new Exception($"Status Code : {response.StatusCode} - {message}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao obter endereço pelo CEP {cep} - {ex.Message}");
                throw;
            }
        }
    }
}
