using ConsoleProductInventory.Interfaces;

namespace ConsoleProductInventory.Classes.Commands;

internal class CheckProductInStockCommand : ICommand
{
    private readonly Stock _stock;
    public string Description => "Проверить наличие продукта в инвентаре";

    public CheckProductInStockCommand(Stock stock)
    {
        _stock = stock;
    }

    private string GetResult()
    {
        string prodName = Console.ReadLine() ?? "Неизвестно";

        if (_stock.Contains(prodName))
            return "Данный продукт есть в инвентаре";

        return "Данный продукт отсутствует в инвентаре";
    }
    public void Execute()
    {
        Console.WriteLine(GetResult());
    }
}
