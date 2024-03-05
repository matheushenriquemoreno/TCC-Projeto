using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Excecoes;

namespace Domain.Validator
{
    public static class Validator
    {
        public static void When(bool hasError, string error)
        {
            if (hasError)
                throw new ValidatorException(error);
        }

        public static void StringVazia(this string valor, string erro)
        {
            if (string.IsNullOrEmpty(valor) || string.IsNullOrWhiteSpace(valor))
                throw new ValidatorException(erro);
        }

        public static void TamanhoMaximo(this string valor, int quantidadeMaxima, string erro)
        {
            if (valor.Length > quantidadeMaxima)
                throw new ValidatorException(erro);
        }

        public static void ObjetoNaoPodeSerNullo(this object entidade, string erro)
        {
            if (entidade is null)
                throw new ValidatorException(erro);
        }


    }
}
