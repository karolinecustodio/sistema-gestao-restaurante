using Blazored.LocalStorage;
using GestaoRestaurante.Models.Dto;

namespace GestaoRestaurante.Web.Services
{
    public class GerenciaCarrinhoItensLocalStorageService : IGerenciaCarrinhoItensLocalStorageService
    {
        const string key = "CarrinhoItemCollection";

        private readonly ILocalStorageService localStorageService;
        private readonly ICarrinhoCompraService carrinhoCompraService;

        public GerenciaCarrinhoItensLocalStorageService(ILocalStorageService localStorageService,
            ICarrinhoCompraService carrinhoCompraService,
            UsuarioLogado usuarioLogado)
        {
            this.localStorageService = localStorageService;
            this.carrinhoCompraService = carrinhoCompraService;
        }

        public async Task<List<CarrinhoItemDto>> GetCollection(UsuarioLogado usuarioLogado)
        {
            return await localStorageService.GetItemAsync<List<CarrinhoItemDto>>(key)
                   ?? await AddCollection(usuarioLogado);
        }

        public async Task RemoveCollection()
        {
            await localStorageService.RemoveItemAsync(key);
        }

        public async Task SaveCollection(List<CarrinhoItemDto> carrinhoItensDto)
        {
            await localStorageService.SetItemAsync(key, carrinhoItensDto);
        }

        //obtem os dados do servidor e armazena no localstorage
        private async Task<List<CarrinhoItemDto>> AddCollection(UsuarioLogado usuarioLogado)
        {
            var carrinhoCompraCollection = await carrinhoCompraService
                                              .GetItens(usuarioLogado.UsuarioId);

            if (carrinhoCompraCollection != null)
            {
                await localStorageService.SetItemAsync(key, carrinhoCompraCollection);
            }
            return carrinhoCompraCollection;
        }
    }
}
