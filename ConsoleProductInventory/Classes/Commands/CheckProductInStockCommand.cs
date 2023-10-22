using ConsoleProductInventory.Interfaces;

namespace ConsoleProductInventory.Classes.Commands;

internal class CheckProductInStockCommand : CommandBase
{
    private readonly Stock _stock;

    public override string Description => "Проверить наличие продукта в инвентаре";

    public CheckProductInStockCommand(Stock stock, IOutputProvider outputProvider) : base(outputProvider)
    {
        _stock = stock;
    }

    public override string GetResult()
    {
        var isParsed = int.TryParse(Console.ReadLine(), out int productId);

        if (isParsed && _stock.Contains(productId))
            return "Данный продукт есть в инвентаре";

        return "Данный продукт отсутствует в инвентаре";
    }
}
