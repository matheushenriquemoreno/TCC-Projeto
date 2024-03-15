using Cliente.Repository.Interfaces;
using Infra.Data.Context;
using Infra.Data.Repository.Base;

namespace Cliente.Repository.Implementacoes
{
    public class ClienteRepository : RepositoryBase<Entities.Cliente>, IClienteRepository
    {
        public ClienteRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
