using ConsoleProductInventory.Interfaces;

namespace ConsoleProductInventory.Classes.Commands;

internal class GetStockListCommand : CommandBase
{
    private readonly Stock _stock;

    public override string Description => "Получить список продуктов из инвентаря";

    public GetStockListCommand(Stock stock, IOutputProvider outputProvider) : base(outputProvider)
    {
        _stock = stock;
    }

    public override string GetResult()
    {
        return _stock.GetProductList();
    }
}
