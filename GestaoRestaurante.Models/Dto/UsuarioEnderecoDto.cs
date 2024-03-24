namespace GestaoRestaurante.Models.Dto
{
    public class UsuarioEnderecoDto
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }
        public UsuarioDto? Usuario { get; set; }

        public int EnderecoId { get; set; }
        public EnderecoDto? Endereco { get; set; }
    }
}
