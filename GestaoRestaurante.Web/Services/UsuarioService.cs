using GestaoRestaurante.Models.Dto;
using System.Net.Http.Json;
using System.Net;

namespace GestaoRestaurante.Web.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly HttpClient httpClient;

        public UsuarioService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<UsuarioDto> GetByIdUsuario(int usuarioId)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/usuario/{usuarioId}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<UsuarioDto>();
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

        public async Task<UsuarioDto> AdicionaUsuario(UsuarioDto usuarioDto)
        {
            try
            {
                var response = await httpClient
                              .PostAsJsonAsync<UsuarioDto>("api/usuario",
                               usuarioDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return default(UsuarioDto);
                    }
                    return await response.Content.ReadFromJsonAsync<UsuarioDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"{response.StatusCode} Message -{message}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
