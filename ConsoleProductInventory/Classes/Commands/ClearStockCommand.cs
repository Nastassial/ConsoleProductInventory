using ConsoleProductInventory.Interfaces;

namespace ConsoleProductInventory.Classes.Commands;

internal class ClearStockCommand : ICommand
{
    private readonly Stock _stock;
    public string Description => "Очистить инвентарь";

    public ClearStockCommand(Stock stock)
    {
        _stock = stock;
    }

    public void Execute()
    {
        _stock.Clear();
        Console.WriteLine("Инвентарь пуст");
    }
}
