using ConsoleProductInventory.Interfaces;

namespace ConsoleProductInventory.Classes.Commands;

internal class AddProductCommand : CommandBase
{
    private const string _errorMessage = "Данные введены неверно!";

    private readonly Stock _stock;

    public override string Description => "Добавить продукт в инвентарь";

    public AddProductCommand(Stock stock, IOutputProvider outputProvider) : base(outputProvider)
    {
        _stock = stock;
    }

    public override string GetResult()
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
}
