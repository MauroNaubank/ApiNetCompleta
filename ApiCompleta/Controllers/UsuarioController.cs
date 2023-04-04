using ApiCompleta.Data.repositories;
using ApiCompleta.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCompleta.Controllers
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

        [HttpGet]
        public async Task<IActionResult> GetAllUsuarios()
        {
            return Ok(await _usuarioRepository.GetAllUsers());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuarioDetails(int id)
        {
            return Ok(await _usuarioRepository.GetDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] Usuario usuario)
        {
           if(usuario == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await _usuarioRepository.InsertarUser(usuario);
            return Created("created", created);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _usuarioRepository.UpdateUser(usuario);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _usuarioRepository.DeleteUser(new Usuario { Id = id});

            return NoContent();
        }

    }
}
