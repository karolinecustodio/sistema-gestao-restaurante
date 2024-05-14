using GestaoRestaurante.Web.Services;

namespace GestaoRestaurante.Web
{
    public class UsuarioLogado
    {
        public int UsuarioId { get; set; }
        public int TipoUsuario { get; set; }

        public async Task SalvarIdUsuario(int usuarioId, IGerenciaUsuarioEnderecoLocalStorageService gerenciaUsuarioEnderecoService, int tipoUsuario)
        {
            UsuarioId = usuarioId;
            TipoUsuario = tipoUsuario;
            await gerenciaUsuarioEnderecoService.SaveUserId(UsuarioId);
        }
    }
}