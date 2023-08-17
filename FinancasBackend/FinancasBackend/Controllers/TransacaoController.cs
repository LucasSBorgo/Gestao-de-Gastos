using FinancasBackend.Models;
using FinancasBackend.Models.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinancasBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransacaoController : ControllerBase
    {
        private readonly ContextoEF _dbContext;

        public TransacaoController(ContextoEF dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetTransacoes()
        {
            return Ok(await _dbContext.Transacoes.ToListAsync());
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> GetTransacoesById([FromRoute] int id)
        {
            var transacao = await _dbContext.Transacoes.FindAsync(id);
            if (transacao == null)
            {
                return NotFound();
            }
            return Ok(transacao);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveTransacao([FromRoute] int id)
        {
            var transacao = await _dbContext.Transacoes.FindAsync(id);
            if (transacao == null)
            {
                return NotFound();
            }
            else
            {

                var conta = await _dbContext.Contas.FindAsync(transacao.es_conta);
                conta.saldo -= transacao.valor;

                _dbContext.Transacoes.Remove(transacao);
                await _dbContext.SaveChangesAsync();
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> AddTransacao(Transacao transacaoRequest)
        {
            await _dbContext.Transacoes.AddAsync(transacaoRequest);

            Conta conta = await _dbContext.Contas.FindAsync(transacaoRequest.es_conta);

            conta.saldo += transacaoRequest.valor;

            await _dbContext.SaveChangesAsync();

            return Ok(transacaoRequest);
        }

    }
}
