using ConsoleProductInventory.Interfaces;

namespace ConsoleProductInventory.Classes.Commands;

internal class GetStockListCommand : ICommand
{
    private readonly Stock _stock;
    public string Description => "Получить список продуктов из инвентаря";

    public GetStockListCommand(Stock stock)
    {
        _stock = stock;
    }

    public void Execute()
    {
        Console.Write(_stock.GetProductList());
    }
}
