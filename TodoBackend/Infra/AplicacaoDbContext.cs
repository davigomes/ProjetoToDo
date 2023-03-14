using Dominio.Abstracoes;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class AplicacaoDbContext : DbContext, IUnitOfWork
    {
        public AplicacaoDbContext(DbContextOptions<AplicacaoDbContext> options)
            :base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AplicacaoDbContext).Assembly);
        }
    }
}
