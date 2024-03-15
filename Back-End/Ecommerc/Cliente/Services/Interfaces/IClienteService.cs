using Application.Interfaces;
using Cliente.DTO;
using Cliente.DTO.ClienteDTO;
using Cliente.Repository.Interfaces;

namespace Cliente.Services.Interfaces
{
    public interface IClienteService : IServiceBase<Entities.Cliente, ClienteInput, ClienteOutPut,IClienteRepository>
    {
       Task<ResultLogin> AdicionarELogar(ClienteInput entity);
    }
}
