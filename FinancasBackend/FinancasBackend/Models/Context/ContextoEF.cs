using Microsoft.EntityFrameworkCore;

namespace FinancasBackend.Models.Context
{
    public class ContextoEF : DbContext
    {
        public ContextoEF (DbContextOptions<ContextoEF> options)
            : base(options)
        {

        }
        public DbSet<Usuario> Usuarios { get; set; } = null;
        public DbSet<Conta> Contas { get; set; } = null;
        public DbSet<Transacao> Transacoes { get; set; } = null;
    }
}
