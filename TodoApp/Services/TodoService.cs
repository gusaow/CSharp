using TodoApp.Models;

namespace TodoApp.Services;

public class TodoService
{
    private readonly List<TodoItem> _tarefas = new();
    private int _proximoId = 1;

    public TodoItem Adicionar(string descricao)
    {
        var tarefa = new TodoItem
        {
            Id = _proximoId++,
            Descricao = descricao,
            Concluida = false
        };

        _tarefas.Add(tarefa);
        return tarefa;
    }

    public List<TodoItem> Listar()
    {
        return _tarefas.ToList();
    }

    public bool Concluir(int id)
    {
        var tarefa = _tarefas.FirstOrDefault(t => t.Id == id);

        if (tarefa is null)
            return false;

        tarefa.Concluida = true;
        return true;
    }

    public bool Remover(int id)
    {
        var tarefa = _tarefas.FirstOrDefault(t => t.Id == id);

        if (tarefa is null)
            return false;

        _tarefas.Remove(tarefa);
        return true;
    }
}
