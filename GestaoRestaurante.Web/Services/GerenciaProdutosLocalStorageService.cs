using Blazored.LocalStorage;
using GestaoRestaurante.Models.Dto;

namespace GestaoRestaurante.Web.Services
{
    public class GerenciaProdutosLocalStorageService : IGerenciaProdutosLocalStorageService
    {
        const string key = "ProdutoCollection";

        private readonly ILocalStorageService localStorageService;
        private readonly IProdutoService produtoService;

        public GerenciaProdutosLocalStorageService(ILocalStorageService localStorageService, IProdutoService produtoService)
        {
            this.localStorageService = localStorageService;
            this.produtoService = produtoService;
        }

        public async Task<IEnumerable<ProdutoDto>> GetCollection()
        {
            return await localStorageService.GetItemAsync<IEnumerable<ProdutoDto>>(key)
                         ?? await AddCollection();
        }

        public async Task RemoveCollection()
        {
            await localStorageService.RemoveItemAsync(key);
        }

        private async Task<IEnumerable<ProdutoDto>> AddCollection()
        {
            var produtoCollection = await produtoService.GetItens();
            if (produtoCollection != null)
            {
                await localStorageService.SetItemAsync(key, produtoCollection);
            }
            return produtoCollection;
        }
    }
}
