using Cliente.Repository.Interfaces;
using Infra.Data.Context;
using Infra.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Cliente.Repository.Implementacoes
{
    public class ClienteRepository : RepositoryBase<Entities.Cliente>, IClienteRepository
    {
        public ClienteRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task GerenciarEnderecoCliente(Entities.Cliente cliente)
        {
            if(cliente.Endereco.Id > 0)
            {
                _context.Entry(cliente.Endereco).State = EntityState.Modified;
            }
            else
            {
                _context.Entry(cliente.Endereco).State = EntityState.Added;
            }

            await Salvar();
        }
    }
}
