using TodoApp.Services;

var service = new TodoService();

while (true)
{
    Console.WriteLine("\n=== TODO APP ===");
    Console.WriteLine("1 - Adicionar tarefa");
    Console.WriteLine("2 - Listar tarefas");
    Console.WriteLine("3 - Concluir tarefa");
    Console.WriteLine("4 - Remover tarefa");
    Console.WriteLine("0 - Sair");
    Console.Write("Escolha: ");

    var opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            Console.Write("Descrição: ");
            var descricao = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(descricao))
            {
                service.Adicionar(descricao);
                Console.WriteLine("Tarefa adicionada.");
            }
            break;

        case "2":
            var tarefas = service.Listar();

            if (tarefas.Count == 0)
            {
                Console.WriteLine("Nenhuma tarefa cadastrada.");
                break;
            }

            foreach (var tarefa in tarefas)
            {
                var status = tarefa.Concluida ? "[X]" : "[ ]";
                Console.WriteLine($"{tarefa.Id} - {status} {tarefa.Descricao}");
            }
            break;

        case "3":
            Console.Write("ID da tarefa: ");
            if (int.TryParse(Console.ReadLine(), out var idConcluir))
            {
                Console.WriteLine(service.Concluir(idConcluir)
                    ? "Tarefa concluída."
                    : "Tarefa não encontrada.");
            }
            break;

        case "4":
            Console.Write("ID da tarefa: ");
            if (int.TryParse(Console.ReadLine(), out var idRemover))
            {
                Console.WriteLine(service.Remover(idRemover)
                    ? "Tarefa removida."
                    : "Tarefa não encontrada.");
            }
            break;

        case "0":
            return;

        default:
            Console.WriteLine("Opção inválida.");
            break;
    }
}
