using GestaoRestaurante.Api.Entities;
using GestaoRestaurante.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<IEnumerable<UsuarioEndereco>>> GetUsuarioEnderecos()
        {
            var usuarioEnderecos = await _repository.GetAllUsuarioEnderecos();
            return Ok(usuarioEnderecos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioEndereco>> GetUsuarioEnderecoById(int id)
        {
            var usuarioEndereco = await _repository.GetByIdUsuarioEndereco(id);

            if (usuarioEndereco == null)
            {
                return NotFound();
            }

            return usuarioEndereco;
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioEndereco>> PostUsuarioEndereco(UsuarioEndereco usuarioEndereco)
        {
            try
            {
                var createdUsuarioEndereco = await _repository.PostByUsuarioEnderecos(usuarioEndereco);
                return CreatedAtAction(nameof(GetUsuarioEnderecoById), new { id = createdUsuarioEndereco.Id }, createdUsuarioEndereco);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
