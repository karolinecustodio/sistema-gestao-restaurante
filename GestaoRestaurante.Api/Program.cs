using GestaoRestaurante.Api.Context;
using GestaoRestaurante.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<ICarrinhoCompraRepository, CarrinhoCompraRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioEnderecoRepository, UsuarioEnderecoRepository>();
builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IPedidoItemRepository, PedidoItemRepository>();
    
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

app.UseAuthentication();
app.MapControllers();

app.Run();

