using Data.Data;
using Data.Repositories;
using Domain;
using Domain.Emprestimos;

namespace Data.RepositoryEntity
{
    public class EmprestimoRepository : Repository<Emprestimo>, IEmprestimoRepository
    {
        public EmprestimoRepository(ContextApplication context) : base(context)
        {
        }
    }
}