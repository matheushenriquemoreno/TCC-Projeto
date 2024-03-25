using Application.Interfaces;
using Cliente.DTO;
using Cliente.DTO.ClienteDTO;
using Cliente.DTO.Login;
using Cliente.Repository.Interfaces;

namespace Cliente.Services.Interfaces
{
    public interface IClienteService : IServiceBase<Entities.Cliente, ClienteCreate, ClienteOutPut,IClienteRepository>
    {
       Task<ResultLogin> AdicionarELogar(ClienteCreate entity);
        Task<ResultLogin> LogarCliente(LoginDTO dadosLogin);
        Task GerenciarEndereco(EnderecoDTO enderecoDTO);
    }
}
