namespace Domain.Excecoes;
/// <summary>
/// Exeção que representa um erro de validação
/// </summary>
public class ValidatorException : Exception
{
    public ValidatorException(string mensage) :base(mensage) { }
}
