using GestaoRestaurante.Api.Entities;
using GestaoRestaurante.Api.Mappings;
using GestaoRestaurante.Api.Repositories;
using GestaoRestaurante.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GestaoRestaurante.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> GetByIdUsuario(int id)
        {
            try
            {
                var usuario = await _usuarioRepository.GetByIdUsuario(id);
                if (usuario is null)
                {
                    return Ok();
                }
                else
                {
                    var usuarioDto = usuario.ConverterUsuarioParaDto();
                    return Ok(usuarioDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao acessar a base de dados");
            }
        }

        [HttpGet("valida-login/{email}/{senha}")]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> GetByEmailAndSenhaUsuario(string email, string senha)
        {
            try
            {
                var usuario = await _usuarioRepository.GetByEmailAndSenhaUsuario(email, senha);
                if (usuario is null)
                {
                    return BadRequest("Usuário não localizado.");
                }
                else
                {
                    var usuarioDto = usuario.ConverterUsuarioParaDto();
                    return Ok(usuarioDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao acessar a base de dados");
            }
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> GetByEmailUsuario(string email)
        {
            try
            {
                var usuario = await _usuarioRepository.GetByEmailUsuario(email);
                if (usuario is null)
                {
                    return BadRequest("Usuário não localizado.");
                }
                else
                {
                    var usuarioDto = usuario.ConverterUsuarioParaDto();
                    return Ok(usuarioDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao acessar a base de dados");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            var user = await _usuarioRepository.GetByIdUsuario(usuario.Id);
            if (user is null)
            {
                await _usuarioRepository.PostByUsuario(usuario);
                return CreatedAtAction(nameof(GetByIdUsuario), new { id = usuario.Id }, usuario);
            }
            else
            {
                var usuarioDto = usuario.ConverterUsuarioParaDto();
                return Ok(usuarioDto);
            }           
        }

        [HttpPut("altera-senha/{email}/{novaSenha}")]
        public async Task<IActionResult> UpdatePassword(string email, string novaSenha)
        {
            try
            {
                var usuarioAtualizado = await _usuarioRepository.UpdateSenha(email, novaSenha);

                if (usuarioAtualizado)
                {
                    return Ok("Senha atualizada com sucesso.");
                }
                else
                {
                    return NotFound("Usuário não encontrado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar a senha do usuário: {ex.Message}");
            }
        }
    }
}