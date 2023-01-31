using ASYNCAPPLICATION;

int.TryParse(args[0], out int complexTaskValue);

var listOfTask = new List<Task<string>>();
var genericTaskEventHandler = new GenericTaskEventHandler<string>();
genericTaskEventHandler.GenericTaskEvent += GenericTaskEventHandler_GenericTaskEvent;

if (complexTaskValue > decimal.Zero)
{
    Console.WriteLine("Tarefa Complicada Iniciada...");
    listOfTask.Add(Task.Delay(complexTaskValue).ContinueWith(x => { return "Tarefa Complicada Finalizada!"; }));
}

Console.WriteLine("Tarefa Maior Iniciada...");
listOfTask.Add(Task.Delay(10000).ContinueWith(x => { return "Tarefa Maior Finalizada!"; }));

Console.WriteLine("Tarefa Média Iniciada...");
listOfTask.Add(Task.Delay(7500).ContinueWith(x => { return "Tarefa Média Finalizada!"; }));

Console.WriteLine("Tarefa Menor Iniciada...");
listOfTask.Add(Task.Delay(5000).ContinueWith(x => { return "Tarefa Menor Finalizada!"; }));

Console.WriteLine();

await genericTaskEventHandler.TriggerGenericTaskEvent(listOfTask);

Console.WriteLine(Environment.NewLine + "Todas Tarefas Estão Concluídas!");
Console.ReadLine();

void GenericTaskEventHandler_GenericTaskEvent(object? sender, GenericTaskEventArgs<string> e)
{
    Console.WriteLine(e.TaskEventResult);
}