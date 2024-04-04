using Blazored.LocalStorage;

namespace GestaoRestaurante.Web.Services
{
    public class GerenciaUsuarioEnderecoLocalStorageService : IGerenciaUsuarioEnderecoLocalStorageService
    {
        const string UserIdKey = "UserId";

        private readonly ILocalStorageService _localStorageService;

        public GerenciaUsuarioEnderecoLocalStorageService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public async Task<int?> GetUserId()
        {
            if (await _localStorageService.ContainKeyAsync(UserIdKey))
            {
                return await _localStorageService.GetItemAsync<int>(UserIdKey);
            }
            return null;
        }

        public async Task SaveUserId(int userId)
        {
            await _localStorageService.SetItemAsync(UserIdKey, userId);
        }

        public async Task RemoveUserId()
        {
            await _localStorageService.RemoveItemAsync(UserIdKey);
        }
    }
}
