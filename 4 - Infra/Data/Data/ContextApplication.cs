using Domain;
using Domain.Clientes;
using Domain.Emprestimos;
using Microsoft.EntityFrameworkCore;

namespace Data.Data
{
    public class ContextApplication : DbContext, IContextApplication
    {
        public ContextApplication(DbContextOptions options) :
                    base(options)
        { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasKey(o => o.Id);
            modelBuilder.Entity<Emprestimo>().HasKey(o => o.Id);

            modelBuilder.Entity<Cliente>()
                .HasMany(x => x.Emprestimos)
                .WithOne(m => m.Cliente);
        }
    }
}