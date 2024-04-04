namespace GestaoRestaurante.Web.Services
{
    public interface IGerenciaUsuarioEnderecoLocalStorageService
    {
        Task<int?> GetUserId();
        Task SaveUserId(int userId);
        Task RemoveUserId();
    }
}
