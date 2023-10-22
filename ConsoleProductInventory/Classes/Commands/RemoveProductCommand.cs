using ConsoleProductInventory.Interfaces;

namespace ConsoleProductInventory.Classes.Commands;

internal class RemoveProductCommand : CommandBase
{
    private readonly Stock _stock;

    public override string Description => "Удалить продукт из инвентаря";

    public RemoveProductCommand(Stock stock, IOutputProvider outputProvider) : base(outputProvider)
    {
        _stock = stock;
    }

    public override string GetResult()
    {
        Console.WriteLine("Введите товарный код продукта для удаления:");

        if (!int.TryParse(Console.ReadLine(), out int productId)) 
            return "Данные введены неверно!";

        if (!_stock.Contains(productId))
            return "Такого товара нет в инвентаре!";

        _stock.Remove(productId);

        return $"Продукт {productId} успешно удален";
    }
}
