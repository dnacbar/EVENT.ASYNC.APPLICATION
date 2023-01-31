using ASYNCAPPLICATION;

int.TryParse(args[0], out int complexTaskValue);

var listOfTask = new List<Task<object>>();
var genericTaskEventHandler = new GenericTaskEventHandler<object>();
genericTaskEventHandler.GenericTaskEvent += GenericTaskEventHandler_GenericTaskEvent;

if (complexTaskValue > decimal.Zero)
{
    Console.WriteLine("Tarefa Complicada Iniciada...");
    listOfTask.Add(Task.Delay(complexTaskValue).ContinueWith(x => { return (object)"Tarefa Complicada Finalizada!"; }));
}

Console.WriteLine("Tarefa Maior Iniciada...");
listOfTask.Add(Task.Delay(10000).ContinueWith(x => { return (object)"Tarefa Maior Finalizada!"; }));

Console.WriteLine("Tarefa Média Iniciada...");
listOfTask.Add(Task.Delay(7500).ContinueWith(x => { return (object)"Tarefa Média Finalizada!"; }));

Console.WriteLine("Tarefa Menor Iniciada...");
listOfTask.Add(Task.Delay(5000).ContinueWith(x => { return (object)"Tarefa Menor Finalizada!"; }));

Console.WriteLine();

await genericTaskEventHandler.TriggerGenericTaskEvent(listOfTask);

Console.WriteLine(Environment.NewLine + "Todas Tarefas Finalizadas!");
Console.ReadLine();

static void GenericTaskEventHandler_GenericTaskEvent(object? sender, GenericTaskEventArgs<object> e)
{
    Console.WriteLine(e.TaskEventResult);
}