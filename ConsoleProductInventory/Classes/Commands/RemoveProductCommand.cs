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
        Console.WriteLine("Выберите продукт для удаления:");

        Console.Write(_stock.GetProductList());

        return Console.ReadLine() ?? "0";
    }

    public void Execute()
    {
        int userChoice = Convert.ToInt32(GetResult()) - 1;

        _stock.Remove(userChoice);

        Console.WriteLine("Продукт успешно удален");
    }
}
