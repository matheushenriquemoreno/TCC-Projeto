namespace Domain.Excecoes;

public class ValidatorException : Exception
{
    public ValidatorException(string mensage) :base(mensage) { }
}
