using Domain.Entites.Base;

namespace Entities
{
    public class Endereco : EntityBase
    {
        public string CEP { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public int? Numero { get; set; }
        public string Estado { get; set; }
        public string Complemento { get; set; }
        public Cliente Cliente { get; set; }
    }
}
