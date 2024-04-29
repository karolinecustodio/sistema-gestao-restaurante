using GestaoRestaurante.Models.Dto;
using System.Net;
using System.Text.Json;
using System.Text;
using System.Net.Http.Json;
using System.Net.Http;

namespace GestaoRestaurante.Web.Services
{

    public class CarrinhoService : ICarrinhoService
    {
        public HttpClient _httpClient;
        public ILogger<CarrinhoService> _logger;

        public CarrinhoService(HttpClient httpClient, ILogger<CarrinhoService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<IEnumerable<CarrinhoDto>> GetAllCarrinho()
        {
            try
            {
                var carrinhoDtos = await _httpClient.GetFromJsonAsync<IEnumerable<CarrinhoDto>>("api/carrinho");

                return carrinhoDtos;
            }
            catch (Exception)
            {
                _logger.LogError("Erro ao acessar produtos: api/pedido");
                throw;
            }
        }

        public async Task<CarrinhoDto> GetByIdCarrinho(int? carrinhoId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/carrinho/{carrinhoId}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return default(CarrinhoDto);
                    }
                    return await response.Content.ReadFromJsonAsync<CarrinhoDto>();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                _logger.LogError($"Erro a obter carrinho pelo id={carrinhoId}");
                throw;
            }
        }

        public async Task<CarrinhoDto> GetCarrinhoByUsuarioId(int? usuarioId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/carrinho/{usuarioId}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return default(CarrinhoDto);
                    }
                    return await response.Content.ReadFromJsonAsync<CarrinhoDto>();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                _logger.LogError($"Erro a obter carrinho pelo id={usuarioId}");
                throw;
            }
        }

        public async Task<CarrinhoDto> PostCarrinho(CarrinhoDto carrinhoDto)
        {
            try
            {
                var response = await _httpClient
                              .PostAsJsonAsync<CarrinhoDto>("api/carrinho",
                               carrinhoDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return default(CarrinhoDto);
                    }
                    return await response.Content.ReadFromJsonAsync<CarrinhoDto>();
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

        public async Task DeleteCarrinho(int carrinhoId)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync($"api/carrinho/{carrinhoId}");

                if (response.IsSuccessStatusCode)
                {
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new Exception($"Carrinho com ID {carrinhoId} não encontrado.");
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Erro ao excluir o carrinho: {message}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao processar a resposta: {ex.Message}");
            }
        }
    }
}
