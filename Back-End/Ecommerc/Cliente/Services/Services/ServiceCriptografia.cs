using BCrypt.Net;
using Cliente.Services.Interfaces;
using static BCrypt.Net.BCrypt;

namespace Cliente.Services.Services
{
    public class ServiceCriptografia : IServiceCriptografia
    {
        public string Cripgrafar(string texto)
        {
            const int WorkFactor = 12;
            return HashPassword(texto, WorkFactor);
        }

        public bool VerificarIgualdade(string texto1, string textoCriptogradado)
        {
            return Verify(texto1, textoCriptogradado);
        }
    }
}
