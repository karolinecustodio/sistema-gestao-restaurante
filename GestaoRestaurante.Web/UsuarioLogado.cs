using GestaoRestaurante.Web.Services;

namespace GestaoRestaurante.Web
{
    public class UsuarioLogado
    {
        public int UsuarioId { get; set; }
        public int CarrinhoId { get; set; }
        public int EnderecoId { get; set; }
        public string Nome { get; set; }
        public int Telefone { get; set; }
        public int TipoUsuario { get; set; }

        public Task<int> GetLoggedUserId()
        {
            return Task.FromResult(UsuarioId);
        }

        public async Task SalvarIdUsuario(int usuarioId, IGerenciaUsuarioEnderecoLocalStorageService gerenciaUsuarioEnderecoService, int tipoUsuario)
        {
            UsuarioId = usuarioId;
            TipoUsuario = tipoUsuario;
            await gerenciaUsuarioEnderecoService.SaveUserId(UsuarioId);
        }
    }
}