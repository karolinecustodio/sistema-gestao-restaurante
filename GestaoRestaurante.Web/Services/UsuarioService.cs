using GestaoRestaurante.Models.Dto;
using System.Net.Http.Json;
using System.Net;
using System.Text.Json;
using System.Text;
using System.Data;
using System.Net.Mail;

namespace GestaoRestaurante.Web.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly HttpClient httpClient;

        public UsuarioService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<UsuarioDto> GetByIdUsuario(int usuarioId)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/usuario/{usuarioId}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<UsuarioDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http Status Code: {response.StatusCode} Mensagem: {message}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UsuarioDto> GetByEmailSenhaUsuario(string email, string senha)
        {
            try
            {
                string url = $"api/usuario/valida-login/{Uri.EscapeDataString(email)}/{Uri.EscapeDataString(senha)}";

                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<UsuarioDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http Status Code: {response.StatusCode} Mensagem: {message}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UsuarioDto> GetByEmailUsuario(string email)
        {
            try
            {
                string url = $"api/usuario/{email}";

                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<UsuarioDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http Status Code: {response.StatusCode} Mensagem: {message}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UsuarioDto> AdicionaUsuario(UsuarioDto usuarioDto)
        {
            try
            {
                var response = await httpClient
                              .PostAsJsonAsync<UsuarioDto>("api/usuario",
                               usuarioDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return default(UsuarioDto);
                    }
                    return await response.Content.ReadFromJsonAsync<UsuarioDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"{response.StatusCode} Message -{message}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AtualizarSenha(string email, string novaSenha)
        {
            try
            {

                var rota = $"altera-senha/{email}/{novaSenha}";
                var response = await httpClient.PutAsync($"api/usuario/{rota}", null);

                if (!response.IsSuccessStatusCode)
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Falha ao atualizar a senha: {message}");
                }
            }
            catch (Exception ex)
            {
                // Tratar o erro conforme necessário
                Console.WriteLine($"Erro ao atualizar a senha: {ex.Message}");
            }
        }

        public string EnviarEmail(string email)
        {
            var emailDestinatario = email;
            var assunto = "Teste envio de email";
            var mensagem = "Essa é uma mensagem para testar se esta enviando o email";
            string dominio = email.Split('@')[1];

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("karolinecustodio7@gmail.com"); // DE
                mail.To.Add(emailDestinatario); // PARA
                mail.Subject = assunto;
                mail.Body = mensagem;

                if (dominio.Contains("gmail.com"))
                {
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.UseDefaultCredentials = false;
                        smtp.EnableSsl = true;
                        smtp.Credentials = new NetworkCredential("karolinecustodio7@gmail.com", "12345");

                        smtp.Send(mail);
                        return "Email Sent";
                    }
                }

                else if (dominio.Contains("hotmail.com") || dominio.Contains("outlook.com"))
                {
                    using SmtpClient smtp = new SmtpClient("smtp.live.com", 587);
                    smtp.UseDefaultCredentials = false;
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential("seuemail@hotmail.com", "suasenha");
                    return "Email Sent";
                }
                else
                {
                    throw new ArgumentException("Domínio de e-mail não suportado.");
                }
            }

        }
    }
}
