using Entities;
using FluentValidation;

namespace Cliente.Services.Validators;

public class EnderecoValidator : AbstractValidator<Endereco>
{
    public EnderecoValidator()
    {
        RuleFor(x => x.CEP).Cascade(CascadeMode.Stop).NotEmpty().MaximumLength(8).MinimumLength(8);
        RuleFor(x => x.Rua).NotEmpty();
        RuleFor(x => x.Bairro).NotEmpty();
        RuleFor(x => x.Estado).NotEmpty();
        RuleFor(x => x.Cidade).NotEmpty();
    }
}

