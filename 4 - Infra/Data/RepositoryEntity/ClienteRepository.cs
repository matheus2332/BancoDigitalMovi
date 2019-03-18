using Data.Data;
using Data.Repositories;
using Domain.Clientes;

namespace Data.RepositoryEntity
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ContextApplication context) : base(context)
        {
        }
    }
}