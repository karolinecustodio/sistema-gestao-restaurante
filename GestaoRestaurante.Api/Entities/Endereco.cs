using System.ComponentModel.DataAnnotations;

namespace GestaoRestaurante.Api.Entities
{
    public class Endereco
    {
        public int Id { get; set; }
        
        [MaxLength(100)]
        public string Rua { get; set; } = string.Empty;

        [MaxLength(10)]
        public string Numero { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Complemento { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Cidade { get; set; } = string.Empty;

        [MaxLength(2)]
        public string Estado { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Bairro { get; set; } = string.Empty;

        [MaxLength(8)]
        public string Cep { get; set; } = string.Empty;

        public ICollection<UsuarioEndereco> UsuarioEndereco { get; set; }
            = new List<UsuarioEndereco>();
    }
}
