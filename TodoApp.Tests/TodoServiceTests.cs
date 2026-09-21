using TodoApp.Services;
using Xunit;

namespace TodoApp.Tests;

public class TodoServiceTests
{
    [Fact]
    public void DeveAdicionarUmaTarefa()
    {
        var service = new TodoService();

        var tarefa = service.Adicionar("Estudar C#");

        Assert.Equal(1, tarefa.Id);
        Assert.Equal("Estudar C#", tarefa.Descricao);
        Assert.False(tarefa.Concluida);
    }

    [Fact]
    public void DeveGerarIdsSequenciaisAoAdicionarTarefas()
    {
        var service = new TodoService();

        var primeira = service.Adicionar("Primeira tarefa");
        var segunda = service.Adicionar("Segunda tarefa");

        Assert.Equal(1, primeira.Id);
        Assert.Equal(2, segunda.Id);
    }

    [Fact]
    public void DeveListarAsTarefasAdicionadas()
    {
        var service = new TodoService();
        service.Adicionar("Estudar GitHub Actions");
        service.Adicionar("Criar Pull Request");

        var tarefas = service.Listar();

        Assert.Equal(2, tarefas.Count);
        Assert.Equal("Estudar GitHub Actions", tarefas[0].Descricao);
        Assert.Equal("Criar Pull Request", tarefas[1].Descricao);
    }

    [Fact]
    public void DeveConcluirUmaTarefa()
    {
        var service = new TodoService();
        var tarefa = service.Adicionar("Aprender Git");

        var resultado = service.Concluir(tarefa.Id);

        Assert.True(resultado);
        Assert.True(tarefa.Concluida);
    }

    [Fact]
    public void DeveRetornarFalseAoConcluirTarefaInexistente()
    {
        var service = new TodoService();

        var resultado = service.Concluir(999);

        Assert.False(resultado);
    }

    [Fact]
    public void DeveRemoverUmaTarefa()
    {
        var service = new TodoService();
        var tarefa = service.Adicionar("Criar Pull Request");

        var resultado = service.Remover(tarefa.Id);

        Assert.True(resultado);
        Assert.Empty(service.Listar());
    }

    [Fact]
    public void DeveRetornarFalseAoRemoverTarefaInexistente()
    {
        var service = new TodoService();

        var resultado = service.Remover(999);

        Assert.False(resultado);
    }
}
