using Application.Interfaces;

namespace Cliente.DTO.ClienteDTO;

public class ClienteCreate : IInputEntity<Entities.Cliente>
{
    public int? Id { get; set; }
    public string Email { get; set; }
    public string CPF { get; set; }
    public string NomeCompleto { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Telefone { get; set; }
    public int Genero { get; set; }
    public string Senha { get; set; }

    public void Mapear()
    {
    }
}
