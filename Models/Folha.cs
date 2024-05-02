using Microsoft.EntityFrameworkCore;
namespace matheus;
public class Folha
{
    public string? folhaId { get; set; }
    public double Valor { get; set; }
    public double Quantidade { get; set; }
    public int Mes { get; set; }
    public int Ano { get; set; }
    public Funcionario Funcionario { get; set; }

    public Folha(double valor, double quantidade, int mes, int ano, Funcionario funcionario)
    {
        folhaId = Guid.NewGuid().ToString();
        Valor = valor;
        Quantidade = quantidade;
        Mes = mes;
        Ano = ano;
        Funcionario = funcionario;

    }

}
