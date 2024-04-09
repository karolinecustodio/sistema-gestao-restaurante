using GestaoRestaurante.Api.Entities;
using GestaoRestaurante.Models.Dto;
using GestaoRestaurante.Web.Pages;
using Endereco = GestaoRestaurante.Api.Entities.Endereco;

namespace GestaoRestaurante.Api.Mappings
{
    public static class MappingDtos
    {
        public static IEnumerable<CategoriaDto> ConverterCategoriasParaDto(
            this IEnumerable<Categoria> categorias)
        {
            return (from categoria in categorias
                    select new CategoriaDto
                    {
                        Id = categoria.Id,
                        Nome = categoria.Nome,
                        IconCss = categoria.IconCss
                    }).ToList();
        }

        public static CategoriaDto ConverterCategoriaParaDto(
            this Categoria categoria)
        {
            return new CategoriaDto
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
                IconCss = categoria.IconCss
            };
        }

        public static PedidoDto ConverterPedidoParaDto(
            this Pedido pedido)
        {
            return new PedidoDto
            {
                Id = pedido.Id,
                DataEmissao = pedido.DataEmissao,
                ValorPedido = pedido.ValorPedido,
                FormaPagamento = new FormaPagamentoDto
                {
                    Nome = pedido.FormaPagamento.ToString(),
                    Valor = (int)pedido.FormaPagamento
                },
                StatusPedido = new StatusPedidoDto
                {
                    Nome = pedido.StatusPedido.ToString(),
                    Valor = (int)pedido.StatusPedido
                },
                PedidoItem = pedido.PedidoItens.Select(item => new PedidoItemDto
                {
                    Id = item.Id,
                    Produto = new ProdutoDto
                    {
                        Id = item.Produto.Id,
                        Nome = item.Produto.Nome,
                        Descricao = item.Produto.Descricao,
                        ImagemUrl = item.Produto.ImagemUrl,
                        ValorProd = item.Produto.ValorProd,
                        Quantidade = item.Produto.Quantidade,
                        CategoriaId = item.Produto.CategoriaId,
                        CategoriaNome = item.Produto.Categoria.Nome,
                    },
                    PedidoId = pedido.Id,
                    ValorProd = pedido.ValorPedido,
                    Quantidade = item.Quantidade

                }).ToList()
            };
        }

        public static IEnumerable<ProdutoDto> ConverterProdutosParaDto(
            this IEnumerable<Produto> produtos)
        {
            return (from produto in produtos
                    select new ProdutoDto
                    {
                        Id = produto.Id,
                        Nome = produto.Nome,
                        Descricao = produto.Descricao,
                        ImagemUrl = produto.ImagemUrl,
                        ValorProd = produto.ValorProd,
                        Quantidade = produto.Quantidade,
                        CategoriaId = produto.Categoria.Id,
                        CategoriaNome = produto.Categoria.Nome
                    }).ToList();
        }

        public static ProdutoDto ConverterProdutoParaDto(
            this Produto produto)
        {
            return new ProdutoDto
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                ImagemUrl = produto.ImagemUrl,
                ValorProd = produto.ValorProd,
                Quantidade = produto.Quantidade,
                CategoriaId = produto.Categoria.Id,
                CategoriaNome = produto.Categoria.Nome
            };
        }

        public static IEnumerable<CarrinhoItemDto> ConverterCarrinhoItensParaDto(
            this IEnumerable<CarrinhoItem> carrinhoItens, IEnumerable<Produto> produtos)
        {
            return (from carrinhoItem in carrinhoItens
                    join produto in produtos
                    on carrinhoItem.ProdutoId equals produto.Id
                    select new CarrinhoItemDto
                    {
                        Id = carrinhoItem.Id,
                        ProdutoId = carrinhoItem.ProdutoId,
                        ProdutoNome = produto.Nome,
                        ProdutoDescricao = produto.Descricao,
                        ProdutoImagemURL = produto.ImagemUrl,
                        Preco = produto.ValorProd,
                        CarrinhoId = carrinhoItem.CarrinhoId,
                        Quantidade = carrinhoItem.Quantidade,
                        PrecoTotal = produto.ValorProd * carrinhoItem.Quantidade
                    }).ToList();
        }

        public static CarrinhoItemDto ConverterCarrinhoItemParaDto(
            this CarrinhoItem carrinhoItem, Produto produto)
        {
            return new CarrinhoItemDto
            {
                Id = carrinhoItem.Id,
                ProdutoId = carrinhoItem.ProdutoId,
                ProdutoNome = produto.Nome,
                ProdutoDescricao = produto.Descricao,
                ProdutoImagemURL = produto.ImagemUrl,
                Preco = produto.ValorProd,
                CarrinhoId = carrinhoItem.CarrinhoId,
                Quantidade = carrinhoItem.Quantidade,
                PrecoTotal = produto.ValorProd * carrinhoItem.Quantidade
            };
        }

        public static UsuarioDto ConverterUsuarioParaDto(
            this Usuario usuario)
        {
            return new UsuarioDto
            {
                Id = usuario.Id,
                NomeUsuario = usuario.NomeUsuario,
                Email = usuario.Email,
                Telefone = usuario.Telefone,
                Senha = usuario.Senha,
                TipoUsuario = (TipoUsuarioDto)usuario.TipoUsuario
            };
        }

        public static EnderecoDto ConverterEnderecoParaDto(
          this Endereco endereco)
        {
            return new EnderecoDto
            {
                Rua = endereco.Rua,
                Numero = endereco.Numero,
                Complemento = endereco.Complemento,
                Cidade = endereco.Cidade,
                Estado = endereco.Estado,
                Bairro = endereco.Bairro,
                Cep = endereco.Cep
            };
        }

        public static IEnumerable<EnderecoDto> ConverterEnderecosParaDto(
            this IEnumerable<Endereco> enderecos)
        {
            return (from endereco in enderecos
                    select new EnderecoDto
                    {
                        Rua = endereco.Rua,
                        Numero = endereco.Numero,
                        Complemento = endereco.Complemento,
                        Bairro = endereco.Bairro,
                        Cidade = endereco.Cidade,
                        Estado = endereco.Estado,
                        Cep = endereco.Cep
                    }).ToList();
        }

        public static UsuarioEnderecoDto ConverterUsuarioEnderecoParaDto(
            this UsuarioEndereco usuarioEndereco)
        {
            return new UsuarioEnderecoDto
            {
                Id = usuarioEndereco.Id,
                UsuarioId = usuarioEndereco.UsuarioId,
                Usuario = new UsuarioDto
                {
                    Id = usuarioEndereco.Usuario.Id,
                    NomeUsuario = usuarioEndereco.Usuario.NomeUsuario,
                    Email = usuarioEndereco.Usuario.Email,
                    Telefone = usuarioEndereco.Usuario.Telefone,
                    Senha = usuarioEndereco.Usuario.Senha,
                    TipoUsuario = (TipoUsuarioDto)usuarioEndereco.Usuario.TipoUsuario
                },
                EnderecoId = usuarioEndereco.EnderecoId,
                Endereco = new EnderecoDto
                {
                    Rua = usuarioEndereco.Endereco.Rua,
                    Numero = usuarioEndereco.Endereco.Numero,
                    Complemento = usuarioEndereco.Endereco.Complemento,
                    Cidade = usuarioEndereco.Endereco.Cidade,
                    Estado = usuarioEndereco.Endereco.Estado,
                    Bairro = usuarioEndereco.Endereco.Bairro,
                    Cep = usuarioEndereco.Endereco.Cep
                }
            };
        }
    }
}
