using GestaoRestaurante.Api.Entities;
using GestaoRestaurante.Api.Mappings;
using GestaoRestaurante.Api.Repositories;
using GestaoRestaurante.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace GestaoRestaurante.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioEnderecoController : ControllerBase
    {
        private readonly IUsuarioEnderecoRepository _repository;

        public UsuarioEnderecoController(IUsuarioEnderecoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioEnderecoDto>>> GetUsuarioEnderecos()
        {
            var usuarioEnderecos = await _repository.GetAllUsuarioEnderecos();
            return Ok(usuarioEnderecos);
        }

        [HttpGet("{usuarioId}")]
        public async Task<ActionResult<UsuarioEnderecoDto>> GetUsuarioEnderecoByUsuarioId(int usuarioId)
        {
            try
            {
                var usuarioEndereco = await _repository.GetUsuarioEnderecoByUsuarioId(usuarioId);
                if (usuarioEndereco is null)
                {
                    return NotFound();
                }
                else
                {
                    var usuarioEnderecoDto = usuarioEndereco.ConverterUsuarioEnderecoParaDto();
                    return Ok(usuarioEnderecoDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao acessar a base de dados");
            }

        }

        [HttpPost]
        public async Task<ActionResult<UsuarioEnderecoDto>> PostUsuarioEndereco(UsuarioEndereco usuarioEndereco)
        {
            try
            {
                var existingUsuarioEndereco = await _repository.GetUsuarioEnderecoByUsuarioId(usuarioEndereco.UsuarioId);
                if (existingUsuarioEndereco != null)
                {
                    existingUsuarioEndereco.EnderecoId = usuarioEndereco.EnderecoId;

                    await _repository.UpdateUsuarioEndereco(existingUsuarioEndereco);

                    var options = new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.Preserve
                    };

                    return Ok(JsonSerializer.Serialize(existingUsuarioEndereco, options));
                }
                else
                {
                    var createdUsuarioEndereco = await _repository.PostByUsuarioEnderecos(usuarioEndereco);
                    return CreatedAtAction(nameof(GetUsuarioEnderecoByUsuarioId), new { id = createdUsuarioEndereco.Id }, createdUsuarioEndereco);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
