using GestaoRestaurante.Models.Dto;
using System.Net.Http.Json;
using System.Net;

namespace GestaoRestaurante.Web.Services
{
    public class PedidoItemService: IPedidoItemService
    {
        public HttpClient _httpClient;
        public ILogger<PedidoItemService> _logger;

        public PedidoItemService(HttpClient httpClient, ILogger<PedidoItemService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<IEnumerable<PedidoItemDto>> GetAllPedidoItem()
        {
            try
            {
                var produtosDto = await _httpClient.GetFromJsonAsync<IEnumerable<PedidoItemDto>>("api/pedidoItem");

                return produtosDto;
            }
            catch (Exception)
            {
                _logger.LogError("Erro ao acessar produtos: api/pedidoItem");
                throw;
            }
        }

        public async Task<PedidoItemDto> GetPedidoItemByUsuarioId(int? usuarioId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/pedidoItem/{usuarioId}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return default(PedidoItemDto);
                    }
                    return await response.Content.ReadFromJsonAsync<PedidoItemDto>();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                _logger.LogError($"Erro a obter pedidoItem pelo id={usuarioId}");
                throw;
            }
        }

        public async Task<PedidoItemDto> PostPedidoItem(PedidoItemDto pedidoItemDto)
        {
            try
            {
                var response = await _httpClient
                              .PostAsJsonAsync<PedidoItemDto>("api/pedidoItem",
                               pedidoItemDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return default(PedidoItemDto);
                    }
                    return await response.Content.ReadFromJsonAsync<PedidoItemDto>();
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

        public async Task<IEnumerable<PedidoItemDto>> GetItensPorPedidoId(int pedidoId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/pedidoItem/pedido/{pedidoId}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<IEnumerable<PedidoItemDto>>();
                }
                else if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    return Enumerable.Empty<PedidoItemDto>();
                }
                else
                {
                    _logger.LogError($"Erro ao obter itens do pedido ID={pedidoId}. StatusCode={response.StatusCode}");
                    return Enumerable.Empty<PedidoItemDto>();
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"Erro ao obter itens do pedido ID={pedidoId}", ex);
                throw;
            }
        }
    }
}
