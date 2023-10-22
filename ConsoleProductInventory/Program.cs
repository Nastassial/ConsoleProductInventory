using ConsoleProductInventory.Classes.Commands;
using ConsoleProductInventory.Classes;
using ConsoleProductInventory.Interfaces;

Stock stock = new Stock();

List<ICommand> commands = new List<ICommand>
    {
        new ExitCommand(),
        new GetStockListCommand(stock),
        new AddProductCommand(stock),
        new RemoveProductCommand(stock),
        new CheckProductInStockCommand(stock),
        new ClearStockCommand(stock)
    };

while (true)
{
    Console.Clear();
    Console.WriteLine("Выберите операцию:");

    for (int i = 0; i < commands.Count; i++)
    {
        Console.WriteLine($"{i} - {commands[i].Description}");
    }

    var isParsed = int.TryParse(Console.ReadLine() ?? "0", out int commandNum);

    if (isParsed && commandNum < commands.Count && commandNum >= 0)
    {
        commands[commandNum].Execute();
    }
    else
    {
        Console.WriteLine("Такой операции нет");
    }

    Console.ReadLine();
}