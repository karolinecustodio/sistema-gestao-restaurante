namespace GestaoRestaurante.Models.Dto
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string? NomeUsuario { get; set; }
        public string? Email { get; set; } 
        public string? Senha { get; set; } 
        public string? Telefone { get; set; } 
        public TipoUsuarioDto? TipoUsuario { get; set; }
    }
}
