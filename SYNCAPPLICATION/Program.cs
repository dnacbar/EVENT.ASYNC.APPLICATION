_ = bool.TryParse(args[0], out bool syncExecution);
_ = int.TryParse(args[1], out int complexTaskValue);

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

if (syncExecution)
{
    Console.WriteLine("Tarefa Complicada Iniciada...");
    Thread.Sleep(complexTaskValue);
    Console.WriteLine("Tarefa Complicada Finalizada!");

    Console.WriteLine("Tarefa Maior Iniciada...");
    Thread.Sleep(5000);
    Console.WriteLine("Tarefa Maior Finalizada!");

    Console.WriteLine("Tarefa Média Iniciada...");
    Thread.Sleep(4000);
    Console.WriteLine("Tarefa Média Finalizada!");

    Console.WriteLine("Tarefa Menor Iniciada...");
    Thread.Sleep(3000);
    Console.WriteLine("Tarefa Menor Finalizada!");
}
else
{
    Console.WriteLine("Tarefa Complicada Iniciada...");
    await Task.Delay(complexTaskValue);
    Console.WriteLine("Tarefa Complicada Finalizada!");

    Console.WriteLine("Tarefa Maior Iniciada...");
    await Task.Delay(5000);
    Console.WriteLine("Tarefa Maior Finalizada!");

    Console.WriteLine("Tarefa Média Iniciada...");
    await Task.Delay(4000);
    Console.WriteLine("Tarefa Média Finalizada!");

    Console.WriteLine("Tarefa Menor Iniciada...");
    await Task.Delay(3000);
    Console.WriteLine("Tarefa Menor Finalizada!");
}

Console.WriteLine();
Console.WriteLine("Todas Tarefas Finalizadas!");
Console.ReadLine();