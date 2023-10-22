using ConsoleProductInventory.Interfaces;

namespace ConsoleProductInventory.Classes.Commands;

internal class AddProductCommand : ICommand
{
    private const string _errorMessage = "Error";

    private readonly Stock _stock;

    public string Description => "Добавить продукт в инвентарь";

    public AddProductCommand(Stock stock)
    {
        _stock = stock;
    }

    private string GetResult()
    {
        Console.WriteLine("Товарный код:");

        if (!int.TryParse(Console.ReadLine(), out int productId))
            return _errorMessage;

        Console.WriteLine("Наименовение:");

        string? productName = Console.ReadLine();

        if (productName == null)
            return _errorMessage;

        Console.WriteLine("Цена:");

        if (!decimal.TryParse(Console.ReadLine(), out decimal productPrice))
            return _errorMessage;

        Console.WriteLine("Количество:");

        if (!int.TryParse(Console.ReadLine(), out int productCnt))
            return _errorMessage;

        Product product = new Product(productId, productName, productPrice, productCnt);

        if (_stock.Contains(productId))
            return "Такой товар уже есть в инвентаре";

        _stock.Add(product);

        return $"Продукт {productName} успешно добавлен";
    }

    public void Execute()
    {
        var result = GetResult();

        if (result == _errorMessage)
        {
            Console.WriteLine("Данные введены неверно!");
            return;
        }

        Console.WriteLine(result);
    }
}
