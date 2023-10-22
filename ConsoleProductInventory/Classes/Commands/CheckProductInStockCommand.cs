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
        var isParsed = int.TryParse(Console.ReadLine(), out int productId);

        if (isParsed && _stock.Contains(productId))
            return "Данный продукт есть в инвентаре";

        return "Данный продукт отсутствует в инвентаре";
    }

    public void Execute()
    {
        Console.WriteLine(GetResult());
    }
}
