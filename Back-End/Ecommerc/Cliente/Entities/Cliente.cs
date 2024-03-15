using Domain.Entites.Base;
using Entities.Enum;

namespace Entities
{
    public class Cliente : EntityBase
    {
        public string Email { get; set; }
        public string CPF { get; set; }
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public Genero Genero { get; set; }
        public string Senha { get; set; }
        public int? IdEndereco { get; set; }
        public Endereco? Endereco { get; set; }
    }
}
