using FluentValidation;

namespace Cliente.Services.Validators
{
    public class ClienteValidator : AbstractValidator<Entities.Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.CPF).NotEmpty().MinimumLength(11).MaximumLength(11);
            RuleFor(x => x.NomeCompleto).NotEmpty();
            RuleFor(x => x.DataNascimento).NotEmpty().NotNull();
            RuleFor(x => x.Telefone).NotEmpty().NotNull();
            RuleFor(x => x.Genero).NotEmpty().NotNull();
            RuleFor(x => x.Senha).NotEmpty().NotNull();
        }
    }
}
