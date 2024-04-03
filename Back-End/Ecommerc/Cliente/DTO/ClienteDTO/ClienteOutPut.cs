using Application.Interfaces;
using Mapster;

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
        public EnderecoDTO Endereco { get; set; }

        public void Mapear()
        {
            TypeAdapterConfig<Entities.Cliente, ClienteOutPut>.NewConfig()
                .AfterMapping((a, b) =>
                {
                   if(b.Endereco is not null)
                    {
                        b.Endereco.IdCliente = a.Id;
                    }
                });
        }
    }
}
