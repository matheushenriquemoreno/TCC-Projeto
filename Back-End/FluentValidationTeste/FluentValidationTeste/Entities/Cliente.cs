namespace Entities;

public class Cliente
{
    public string Email { get; set; }
    public string CPF { get; set; }
    public string NomeCompleto { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Telefone { get; set; }
    public int Genero { get; set; }
    public string Senha { get; set; }
}