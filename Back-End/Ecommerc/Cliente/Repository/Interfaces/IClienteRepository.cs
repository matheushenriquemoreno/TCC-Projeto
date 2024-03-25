using Domain.Interfaces;

namespace Cliente.Repository.Interfaces
{
    public interface IClienteRepository : IRepositoryBase<Entities.Cliente>   
    {
        Task GerenciarEnderecoCliente(Entities.Cliente cliente);
    }
}
