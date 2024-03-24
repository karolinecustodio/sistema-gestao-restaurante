namespace GestaoRestaurante.Models.Dto
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; } 
        public string Senha { get; set; } 
        public string Telefone { get; set; } 
        public TipoUsuarioDto? TipoUsuario { get; set; }
        public ICollection<CarrinhoDto> Carrinho { get; set; } = new List<CarrinhoDto>();
        public ICollection<UsuarioEnderecoDto> Enderecos { get; set; } = new List<UsuarioEnderecoDto>();
    }
}
