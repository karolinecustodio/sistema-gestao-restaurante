using GestaoRestaurante.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestaoRestaurante.Api.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Mappendo entidade para a tabela
        public DbSet<Carrinho>? Carrinhos { get; set; }
        public DbSet<CarrinhoItem>? CarrinhoItens { get; set; }
        public DbSet<Produto>? Produtos { get; set; }
        public DbSet<Categoria>? Categorias { get; set; }
        public DbSet<Usuario>? Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().HasData(new Categoria
            {
                Id = 1,
                Nome = "Lanches",
                IconCss = "fas fa-spa"
            });

            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                Id = 1,
                Nome = "X-bacon",
                Descricao = "Um lanche saboroso sabor bacon",
                ImagemUrl = "Imagens/Lanches/X-bacon.png",
                Preco = 15,
                Quantidade = 150,
                CategoriaId = 1
            });

            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                Id = 1,
                NomeUsuario = "Karol"
            });

        }
    }
}