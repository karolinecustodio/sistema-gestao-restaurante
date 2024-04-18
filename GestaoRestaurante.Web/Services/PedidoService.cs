using GestaoRestaurante.Models.Dto;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;

namespace GestaoRestaurante.Web.Services
{
    public class PedidoService : IPedidoService
    {
        public HttpClient _httpClient;
        public ILogger<PedidoService> _logger;

        public PedidoService(HttpClient httpClient, ILogger<PedidoService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<IEnumerable<PedidoDto>> GetAllPedidos()
        {
            try
            {
                var pedidosDto = await _httpClient.GetFromJsonAsync<IEnumerable<PedidoDto>>("api/pedido");

                return pedidosDto;
            }
            catch (Exception)
            {
                _logger.LogError("Erro ao acessar produtos: api/pedido");
                throw;
            }
        }

        public async Task<PedidoDto> GetByIdPedido(int? id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/pedido/{id}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return default(PedidoDto);
                    }
                    return await response.Content.ReadFromJsonAsync<PedidoDto>();
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

        public async Task<PedidoDto> PostPedido(PedidoDto pedidoDto)
        {
            try
            {
                var response = await _httpClient
                              .PostAsJsonAsync<PedidoDto>("api/pedido",
                               pedidoDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return default(PedidoDto);
                    }
                    return await response.Content.ReadFromJsonAsync<PedidoDto>();
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

        public async Task<IEnumerable<PedidoDto>> GetPedidosPorIntervaloDeData(DateTime dataInicial, DateTime dataFinal)
        {
            try
            {
                string dataInicialFormatada = dataInicial.ToString("yyyy-MM-dd");
                string dataFinalFormatada = dataFinal.ToString("yyyy-MM-dd");

                var url = $"api/pedido/porIntervaloDeData/{Uri.EscapeDataString(dataInicialFormatada)}/{Uri.EscapeDataString(dataFinalFormatada)}";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<IEnumerable<PedidoDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    _logger.LogError($"Erro ao buscar pedidos por intervalo de data: {response.StatusCode} - {message}");
                    return Enumerable.Empty<PedidoDto>();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao processar a resposta: {ex.Message}");
                throw;
            }
        }
    }
}
