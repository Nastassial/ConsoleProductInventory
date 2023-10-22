
using ConsoleProductInventory.Interfaces;

namespace ConsoleProductInventory.Classes.Commands;

internal class TakeProductCntCommand : ICommand
{
    private readonly Stock _stock;
    public string Description => "Выбрать определенное количество продукта";

    public TakeProductCntCommand(Stock stock)
    {
        _stock = stock;
    }

    private string GetResult()
    {
        Console.WriteLine("Введите товарный код продукта:");

        if (!int.TryParse(Console.ReadLine(), out int productId))
            return "Данные введены неверно!";

        if (!_stock.Contains(productId))
            return "Такого товара нет в инвентаре!";

        Console.WriteLine("Введите количество продукта:");

        if (!int.TryParse(Console.ReadLine(), out int productCnt))
            return "Данные введены неверно!";

        if (!_stock.GetProduct(productId).Remove(productCnt))
            return "Данные введены неверно или превышено количество продукта в наличии!";

        return "Операция прошла успешно";
    }

    public void Execute()
    {
        Console.WriteLine(GetResult());
    }
}
