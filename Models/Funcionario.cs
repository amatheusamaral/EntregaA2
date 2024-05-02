using Microsoft.EntityFrameworkCore;
namespace matheus;

public class Funcionario
{
    public Funcionario(string nome, string cpf)
    {
        Nome = nome;
        Cpf = cpf;
        funcionarioId = Guid.NewGuid().ToString();
    }

    public string? funcionarioId { get; set; }
    public string? Nome { get; set; }
    public string Cpf { get; set; }

}
