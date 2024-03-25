using Application.Interfaces;

namespace Cliente.DTO.ClienteDTO
{
    public class ClienteOutPut : IOutPutEntity<Entities.Cliente>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public int Genero { get; set; }

        public void Mapear()
        {

        }
    }
}
