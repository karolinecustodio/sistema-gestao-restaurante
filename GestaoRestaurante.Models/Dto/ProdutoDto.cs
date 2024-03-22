using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoRestaurante.Models.Dto
{
    public class ProdutoDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string ImagemUrl { get; set; }

        public decimal ValorProd { get; set; }

        public int Quantidade { get; set; }
        public int CategoriaId { get; set; }
        public string? CategoriaNome { get; set; }
    }
}