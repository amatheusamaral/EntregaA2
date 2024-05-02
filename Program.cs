using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using matheus;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppdbContext>();
var app = builder.Build();

List<Funcionario> funcionarios = new List<Funcionario>();
List<Folha> folhas = new List<Folha>();

app.MapGet("/matheus/funcionario/listar", ([FromServices] AppdbContext context) =>
{
    if (context.Funcionarios.Any())
    {

        return Results.Ok(context.Funcionarios.ToList());
    }
    return Results.NotFound(" Não existem funcionários na Tabela");
});

app.MapGet("/matheus/funcionario/buscar{id}", ([FromRoute] string id, [FromServices] AppdbContext context) =>
{
    Funcionario? funcionario = context.Funcionarios.FirstOrDefault(f => f.funcionarioId == id);

    if (funcionario == null)
    {
        return Results.NotFound("Funcionário não encontrado");
    }
    return Results.Ok(funcionario);
});

app.MapPost("/matheus/funcionario/cadastrar", ([FromBody] Funcionario func,
[FromServices] AppdbContext context) =>
{
    context.Funcionarios.Add(func);
    context.SaveChanges();

    return Results.Created("/matheus/funcionario/buscar/{funcionario.funcionarioId}", func);
});

app.MapPost("/matheus/folha/cadastrar", ([FromBody] Folha folha,
[FromServices] AppdbContext context) =>
{
    context.Folhas.Add(folha);
    context.SaveChanges();

    return Results.Created($"/matheus/funcionario/buscar/{folha.folhaId}", folha);
});

app.MapGet("/matheus/folha/listar", ([FromServices] AppdbContext context) =>
{




    if (context.Folhas.Any())
    {
        return Results.Ok(context.Folhas.ToList());
    }
    return Results.NotFound(" Não existem folhas na tabela");
});

app.MapGet("/matheus/folha/buscar", ([FromRoute] string cpf, int mes, int ano, [FromServices] AppdbContext context) =>
{
    Folha? folha = context.Folhas.FirstOrDefault(f => f.Funcionario.Cpf.Equals(cpf));

    if (folha != null)
    {
        return Results.Ok(folha);
    }
    return Results.NotFound("Folha não encontrada");
});

app.Run();
