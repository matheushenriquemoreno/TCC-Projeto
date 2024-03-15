using Application.Services;
using Cliente.DTO.ClienteDTO;
using Cliente.Repository.Interfaces;
using Cliente.Services.Interfaces;
using FluentValidation;
using MapsterMapper;
using BCrypt.Net;
using static BCrypt.Net.BCrypt;
using Cliente.DTO;

namespace Cliente.Services.Services
{
    public class ClienteService : ServiceBase<Entities.Cliente, ClienteInput, ClienteOutPut, IClienteRepository>, IClienteService
    {
        private readonly IServiceToken serviceToken;

        public ClienteService(IClienteRepository repository, IMapper mapper, IValidator<Entities.Cliente> validator, IServiceToken serviceToken)
            : base(repository, mapper, validator)
        {
            this.serviceToken = serviceToken;
        }

        public override async Task Adicionar(ClienteInput entity)
        {
            var cliente = mapper.Map<ClienteInput, Entities.Cliente>(entity);

            await ValidarAdicionar(cliente);

            cliente.Senha = HashPassword(cliente.Senha,workFactor: 12);

            await _repository.Adicionar(cliente);
        }

        public async Task<ResultLogin> AdicionarELogar(ClienteInput entity)
        {
            await Adicionar(entity);

            var token = serviceToken.ObterTokenLogin(entity.Email);

            return new ResultLogin
            {
                Token = token
            };
        }
    }
}
