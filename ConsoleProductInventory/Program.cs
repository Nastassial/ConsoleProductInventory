using ConsoleProductInventory.Classes.Commands;
using ConsoleProductInventory.Classes;
using ConsoleProductInventory.Interfaces;

Stock stock = new Stock();

stock.AddRange(new List<Product>() 
{ 
    new Product(1000, "яблоко", 2.3m, 100),
    new Product(1001, "груша", 3m, 20),
    new Product(1002, "лемон", 7m, 50),
    new Product(1003, "картофель", 4.1m, 70)
});

List<ICommand> commands = new List<ICommand>
    {
        new ExitCommand(),
        new AddProductCommand(stock),
        new RemoveProductCommand(stock),
        new ClearStockCommand(stock),
        new TakeProductCntCommand(stock)
    };

while (true)
{
    Console.Clear();

    Console.WriteLine(stock.GetProductList());

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