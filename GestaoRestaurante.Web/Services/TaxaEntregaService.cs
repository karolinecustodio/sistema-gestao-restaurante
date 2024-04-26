using GestaoRestaurante.Models.Dto;
using System.Net.Mail;
using System.Net;
using System.Net.Http.Json;
using System.Net.Http;
using Microsoft.Extensions.Logging;

namespace GestaoRestaurante.Web.Services
{
    public class TaxaEntregaService : ITaxaEntregaService
    {
        public HttpClient _httpClient;
        public ILogger<TaxaEntregaService> _logger;

        public TaxaEntregaService(HttpClient httpClient, ILogger<TaxaEntregaService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<IEnumerable<TaxaEntregaDto>> GetAllTaxaDeEntrega()
        {
            try
            {
                var pedidosDto = await _httpClient.GetFromJsonAsync<IEnumerable<TaxaEntregaDto>>("api/TaxaDeEntrega");

                return pedidosDto;
            }
            catch (Exception)
            {
                _logger.LogError("Erro ao acessar produtos: api/TaxaDeEntrega");
                throw;
            }
        }

        public async Task<TaxaEntregaDto> GetByIdTaxaEntrega(int taxaEntregaId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/TaxaDeEntrega/{taxaEntregaId}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<TaxaEntregaDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http Status Code: {response.StatusCode} Mensagem: {message}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TaxaEntregaDto> PostTaxaEntrega(TaxaEntregaDto taxaEntregaDto)
        {
            try
            {
                var response = await _httpClient
                              .PostAsJsonAsync<TaxaEntregaDto>("api/TaxaDeEntrega",
                               taxaEntregaDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return default(TaxaEntregaDto);
                    }
                    return await response.Content.ReadFromJsonAsync<TaxaEntregaDto>();
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

        public async Task AtualizaTaxaEntrega(string nomeBairro)
        {
            try
            {
                var rota = $"altera-taxaEntrega/{nomeBairro}";
                var response = await _httpClient.PutAsync($"api/TaxaDeEntrega/{rota}", null);

                if (!response.IsSuccessStatusCode)
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Falha ao atualizar a taxa de entrega: {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar a taxa de entrega: {ex.Message}");
            }
        }
    }
}
