using Domain;
using Domain.Clientes;
using Domain.Emprestimos;
using Microsoft.EntityFrameworkCore;

namespace Data.Data
{
    public interface IContextApplication
    {
        DbSet<Cliente> Clientes { get; set; }
        DbSet<Emprestimo> Emprestimos { get; set; }

        int SaveChanges();
    }
}