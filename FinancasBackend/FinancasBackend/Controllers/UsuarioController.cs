using FinancasBackend.Models;
using FinancasBackend.Models.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinancasBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ContextoEF _dbContext;

        public UsuarioController(ContextoEF dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            return Ok(await _dbContext.Usuarios.ToListAsync());
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> GetUsuarioById([FromRoute] int id)
        {
            var usuario = await _dbContext.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveUsuario([FromRoute] int id)
        {
            var usuario = await _dbContext.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            else
            {
                _dbContext.Usuarios.Remove(usuario);
                await _dbContext.SaveChangesAsync();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> AddUsuario(Usuario usuarioRequest)
        {
            var usuario = new Usuario()
            {
                nome = usuarioRequest.nome,
                idade = usuarioRequest.idade,
                email = usuarioRequest.email,
            };
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            return Ok(usuario);
        }
    }
}
