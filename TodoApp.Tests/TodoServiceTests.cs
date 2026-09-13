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
    public void DeveConcluirUmaTarefa()
    {
        var service = new TodoService();
        var tarefa = service.Adicionar("Aprender Git");

        var resultado = service.Concluir(tarefa.Id);

        Assert.True(resultado);
        Assert.True(tarefa.Concluida);
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
}
