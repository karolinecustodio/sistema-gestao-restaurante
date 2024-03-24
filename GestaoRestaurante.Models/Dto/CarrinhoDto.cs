namespace GestaoRestaurante.Models.Dto
{
    public class CarrinhoDto
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }

        public ICollection<CarrinhoItemDto> Itens { get; set; }
            = new List<CarrinhoItemDto>();
    }
}
