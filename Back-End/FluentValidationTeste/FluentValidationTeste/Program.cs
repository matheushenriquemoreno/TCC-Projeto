using System.Globalization;
using Entities;
using FluentValidation;
using FluentValidationTeste.Validator;

ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("pt-BR");

var customer = new Cliente();
var validator = new ClienteValidator();

try
{
    validator.ValidateAndThrow(customer);
}
catch(ValidationException ex)
{
    Console.WriteLine(ex.Errors);
}