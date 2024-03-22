using System.ComponentModel.DataAnnotations;

namespace GestaoRestaurante.Api.Entities
{
    public class UsuarioEndereco
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        public int EnderecoId { get; set; }
        public Endereco? Endereco { get; set; }
    }
}
