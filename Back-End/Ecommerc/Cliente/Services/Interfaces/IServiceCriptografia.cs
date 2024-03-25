namespace Cliente.Services.Interfaces
{
    public interface IServiceCriptografia
    {
        public string Cripgrafar(string texto);
        public bool VerificarIgualdade(string texto1, string textoCriptogradado);
    }
}
