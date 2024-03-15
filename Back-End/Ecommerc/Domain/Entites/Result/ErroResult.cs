using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites.Erro
{
    public class ErroResult
    {
        public List<string> Erros { get; set; } = new List<string>();

        public void AdicionarErro(string erro)
        {
            Erros.Add(erro);
        }
    }
}
