using System.ComponentModel.DataAnnotations;

namespace GestaoRestaurante.Api.Entities
{
    public class Usuario
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string? NomeUsuario { get; set; }
        
        [MaxLength(100)]
        public string? Email { get; set; }

        [MaxLength(100)]
        public string? Senha { get; set; }

        [MaxLength(20)]
        public string? Telefone { get; set; }

        public TipoUsuario? TipoUsuario { get; set; }

        public ICollection<Carrinho> Carrinho { get; set; }
            = new List<Carrinho>();

        public ICollection<Pedido> Pedido { get; set; }
            = new List<Pedido>();

        public ICollection<UsuarioEndereco> Enderecos { get; set; }
            = new List<UsuarioEndereco>();
    }
}