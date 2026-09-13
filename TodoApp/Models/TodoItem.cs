namespace TodoApp.Models;

public class TodoItem
{
    public int Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public bool Concluida { get; set; }
}
