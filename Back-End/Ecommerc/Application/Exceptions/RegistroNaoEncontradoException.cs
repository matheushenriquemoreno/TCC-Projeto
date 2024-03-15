using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class RegistroNaoEncontradoException : Exception
    {
        public RegistroNaoEncontradoException() : base("Registro não encontrado")
        {

        }
    }
}
