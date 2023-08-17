using FinancasBackend.Models;
using FinancasBackend.Models.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinancasBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private readonly ContextoEF _dbContext;

        public ContaController(ContextoEF dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetContas()
        {
            return Ok(await _dbContext.Contas.ToListAsync());
        }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetContasById([FromRoute] int id)
        {
            var conta = await _dbContext.Contas.FindAsync(id);
            if (conta == null)
            {
                return NotFound();
            }
            return Ok(conta);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveConta([FromRoute] int id)
        {
            var conta = await _dbContext.Contas.FindAsync(id);
            if (conta == null)
            {
                return NotFound();
            }
            else
            {
                _dbContext.Contas.Remove(conta);
                await _dbContext.SaveChangesAsync();
            }
            return Ok(conta);
        }

        [HttpPost]
        public async Task<IActionResult> AddConta(Conta contaRequest)
        {
            var conta = new Conta()
            {
                saldo = contaRequest.saldo,
                es_usuario = contaRequest.es_usuario,
            };
            await _dbContext.Contas.AddAsync(conta);
            await _dbContext.SaveChangesAsync();
            return Ok(conta);
        }
    }
}
