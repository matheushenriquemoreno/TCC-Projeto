using Entities;
using FluentValidation;

namespace FluentValidationTeste.Validator
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator() {

            RuleFor(x => x.NomeCompleto).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
        }
    }
}
