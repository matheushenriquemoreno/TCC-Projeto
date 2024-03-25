using Application.Services;
using Cliente.DTO.ClienteDTO;
using Cliente.Repository.Interfaces;
using Cliente.Services.Interfaces;
using FluentValidation;
using MapsterMapper;
using Cliente.DTO;
using Cliente.DTO.Login;
using Domain.Excecoes;
using Application.Exceptions;
using Cliente.Services.Validators;

namespace Cliente.Services.Services
{
    public class ClienteService : ServiceBase<Entities.Cliente, ClienteCreate, ClienteOutPut, IClienteRepository>, IClienteService
    {
        private readonly IServiceToken _serviceToken;
        private readonly IServiceCriptografia _serviceCriptografia;

        public ClienteService(IClienteRepository repository, IMapper mapper, IValidator<Entities.Cliente> validator, IServiceToken serviceToken, IServiceCriptografia serviceCriptografia)
            : base(repository, mapper, validator)
        {
            _serviceToken = serviceToken;
            _serviceCriptografia = serviceCriptografia;
        }


        public async Task GerenciarEndereco(EnderecoDTO enderecoDTO)
        {
            var cliente = await _repository.ObterOnde(x => x.Id == enderecoDTO.IdCliente);

            if (cliente is null)
                throw new RegistroNaoEncontradoException();

            var endereco = mapper.Map<EnderecoDTO, Entities.Endereco>(enderecoDTO);

            if (cliente.Endereco is not null)
                endereco.Id = cliente.Endereco.Id;

            var validator = new EnderecoValidator();

            validator.ValidateAndThrow(endereco);

            cliente.Endereco = endereco;

            await _repository.GerenciarEnderecoCliente(cliente);
        }

        public override async Task ValidarAdicionar(Entities.Cliente entity)
        {
            await base.ValidarAdicionar(entity);

            var clienteComEmailExistente = await _repository.ObterOnde(x => x.Email.ToLower().Equals(entity.Email.ToLower()));

            if(clienteComEmailExistente is not null)
                throw new ValidatorException("Foi verificado que ja existe uma conta cadastrada.");

            var clienteComCPFExistente = await _repository.ObterOnde(x => x.CPF.ToLower().Equals(entity.CPF.ToLower()));

            if (clienteComCPFExistente is not null)
                throw new ValidatorException("Foi verificado que ja existe uma conta cadastrada.");
        }

        public override async Task<Entities.Cliente> Adicionar(ClienteCreate entity)
        {
            var cliente = mapper.Map<ClienteCreate, Entities.Cliente>(entity);

            await ValidarAdicionar(cliente);

            cliente.Senha = _serviceCriptografia.Cripgrafar(cliente.Senha);

            await _repository.Adicionar(cliente);

            return cliente;
        }

        public async Task<ResultLogin> LogarCliente(LoginDTO dadosLogin)
        {
            var cliente = await _repository.ObterOnde(x => x.Email.ToLower().Equals(dadosLogin.Email.ToLower()));

            if (cliente is null)
                throw new ValidatorException("Email ou senha invalido!");

            if (!_serviceCriptografia.VerificarIgualdade(dadosLogin.Senha, cliente.Senha))
                throw new ValidatorException("Email ou senha invalido!");

            return ObterTokenCliente(cliente);
        }

        public async Task<ResultLogin> AdicionarELogar(ClienteCreate entity)
        {
            var cliente = await Adicionar(entity);

            return ObterTokenCliente(cliente);
        }

        private ResultLogin ObterTokenCliente(Entities.Cliente cliente)
        {
            var token = _serviceToken.ObterTokenLogin(cliente);

            return new ResultLogin
            {
                Token = token,
                Nome = cliente.NomeCompleto,
                IdCliente = cliente.Id,
            };
        }
    }
}
