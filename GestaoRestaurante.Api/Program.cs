using Blazored.LocalStorage;
using GestaoRestaurante.Api.Context;
using GestaoRestaurante.Api.Repositories;
using GestaoRestaurante.Web;
using GestaoRestaurante.Web.Services;
using Microsoft.EntityFrameworkCore;
using Host = GestaoRestaurante.Web.Host;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

builder.Services.AddControllersWithViews();
builder.Services.AddMemoryCache();
builder.Services.AddRazorPages();
builder.Services.AddRazorComponents().AddInteractiveWebAssemblyComponents();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<ICarrinhoCompraRepository, CarrinhoCompraRepository>();
builder.Services.AddScoped<ICarrinhoRepository, CarrinhoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioEnderecoRepository, UsuarioEnderecoRepository>();
builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IPedidoItemRepository, PedidoItemRepository>();
builder.Services.AddScoped<ITaxaDeEntregaRepository, TaxaDeEntregaRepository>();
builder.Services.AddScoped<ICepService, CepService>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<ICarrinhoCompraService, CarrinhoCompraService>();
builder.Services.AddScoped<ICarrinhoService, CarrinhoService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IUsuarioEnderecoService, UsuarioEnderecoService>();
builder.Services.AddScoped<IEnderecoService, EnderecoService>();
builder.Services.AddScoped<IPedidoService, PedidoService>();
builder.Services.AddScoped<IPedidoItemService, PedidoItemService>();
builder.Services.AddScoped<ITaxaEntregaService, TaxaEntregaService>();
builder.Services.AddScoped<ICepService, CepService>();
builder.Services.AddScoped<UsuarioLogado>();

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<IGerenciaProdutosLocalStorageService,
    GerenciaProdutosLocalStorageService>();

builder.Services.AddScoped<IGerenciaCarrinhoItensLocalStorageService,
    GerenciaCarrinhoItensLocalStorageService>();

builder.Services.AddScoped<IGerenciaUsuarioEnderecoLocalStorageService,
    GerenciaUsuarioEnderecoLocalStorageService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseCors(policy =>
    policy.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);
app.UseAntiforgery();
app.UseAuthentication();
app.MapControllers();
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseCors(options => {
    options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}
);

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapControllers();
    endpoints.MapRazorComponents<Host>().AddInteractiveWebAssemblyRenderMode();
});

app.Run();
