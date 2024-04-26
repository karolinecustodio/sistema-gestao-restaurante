using Blazored.LocalStorage;
using GestaoRestaurante.Web;
using GestaoRestaurante.Web.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var baseUrl = "https://localhost:7294";

builder.Services.AddScoped(sp => new HttpClient 
{
    BaseAddress = new Uri(baseUrl) 
});

builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<ICarrinhoCompraService, CarrinhoCompraService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IUsuarioEnderecoService, UsuarioEnderecoService>();
builder.Services.AddScoped<IEnderecoService, EnderecoService>();
builder.Services.AddScoped<IPedidoService, PedidoService>();
builder.Services.AddScoped<IPedidoItemService, PedidoItemService>();
builder.Services.AddScoped<ITaxaEntregaService, TaxaEntregaService>();
builder.Services.AddScoped<UsuarioLogado>();

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<IGerenciaProdutosLocalStorageService,
    GerenciaProdutosLocalStorageService>();

builder.Services.AddScoped<IGerenciaCarrinhoItensLocalStorageService,
    GerenciaCarrinhoItensLocalStorageService>();

builder.Services.AddScoped<IGerenciaUsuarioEnderecoLocalStorageService,
    GerenciaUsuarioEnderecoLocalStorageService>();

await builder.Build().RunAsync();
