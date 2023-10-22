using ConsoleProductInventory.Interfaces;

namespace ConsoleProductInventory.Classes.Commands;

internal class RemoveProductCommand : ICommand
{
    private readonly Stock _stock;
    public string Description => "Удалить продукт из инвентаря";

    public RemoveProductCommand(Stock stock)
    {
        _stock = stock;
    }

    private string GetResult()
    {
        Console.WriteLine("Введите товарный код продукта для удаления:");

        if (!int.TryParse(Console.ReadLine(), out int productId)) 
            return "Данные введены неверно!";

        if (!_stock.Contains(productId))
            return "Такого товара нет в инвентаре!";

        _stock.Remove(productId);

        return $"Продукт {productId} успешно удален";
    }

    public void Execute()
    {
        Console.WriteLine(GetResult());
    }
}
