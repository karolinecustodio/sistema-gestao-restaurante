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
        public DbSet<Endereco>? Enderecos { get; set; }
        public DbSet<Pedido>? Pedido { get; set; }
        public DbSet<PedidoItem>? PedidoItens { get; set; }
        public DbSet<Produto>? Produtos { get; set; }
        public DbSet<Categoria>? Categorias { get; set; }
        public DbSet<Usuario>? Usuarios { get; set; }
        public DbSet<UsuarioEndereco>? UsuarioEnderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().HasData(new Categoria
            {
                Id = 1,
                Nome = "Lanches",
                IconCss = "fas fa-spa"
            });

            modelBuilder.Entity<Categoria>().HasData(new Categoria
            {
                Id = 2,
                Nome = "Bebidas",
                IconCss = "fas fa-spa"
            });

            modelBuilder.Entity<Categoria>().HasData(new Categoria
            {
                Id = 3,
                Nome = "Sobremesas",
                IconCss = "fas fa-spa"
            });

            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                Id = 1,
                Nome = "X-bacon",
                Descricao = "Um x-bacon delicioso que combina bacon crocante, queijo derretido, alface, tomate e maionese.",
                ImagemUrl = "Imagens/Lanches/xbacon.png",
                ValorProd = 15,
                Quantidade = 150,
                CategoriaId = 1
            });

            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                Id = 2,
                Nome = "Guarana",
                Descricao = "Refrigerante Guarana 2l.",
                ImagemUrl = "Imagens/Bebidas/guarana.png",
                ValorProd = 10,
                Quantidade = 150,
                CategoriaId = 2
            });

            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                Id = 3,
                Nome = "X-Salada",
                Descricao = "Um x-salada delicioso que combina hambúrguer, queijo derretido, alface, tomate, maionese e cebola roxa.",
                ImagemUrl = "Imagens/Lanches/xsalada.png",
                ValorProd = 15,
                Quantidade = 150,
                CategoriaId = 1
            });

            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                Id = 4,
                Nome = "X-Salada com Fritas",
                Descricao = "Um x-salada delicioso que combina hambúrguer, queijo derretido, alface, tomate, maionese cebola roxa. Acompanha fritas.",
                ImagemUrl = "Imagens/Lanches/xsaladaFritas.png",
                ValorProd = 20,
                Quantidade = 150,
                CategoriaId = 1
            });

            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                Id = 5,
                Nome = "Pepsi",
                Descricao = "Refrigerante Pepsi 2l",
                ImagemUrl = "Imagens/Bebidas/pepsi.png",
                ValorProd = 10,
                Quantidade = 150,
                CategoriaId = 2
            });


            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                Id = 6,
                Nome = "Sukita Uva",
                Descricao = "Refrigerante Sukita Uva 2l",
                ImagemUrl = "Imagens/Bebidas/sukitauva.png",
                ValorProd = 10,
                Quantidade = 150,
                CategoriaId = 2
            });


            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                Id = 7,
                Nome = "H2O",
                Descricao = "H2O",
                ImagemUrl = "Imagens/Bebidas/h2o.png",
                ValorProd = 10,
                Quantidade = 150,
                CategoriaId = 2
            });

            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                Id = 1,
                NomeUsuario = "admin",
                Email = "karolinecustodio7@gmail.com",
                Telefone = "47997418959"
            });
        }
    }
}