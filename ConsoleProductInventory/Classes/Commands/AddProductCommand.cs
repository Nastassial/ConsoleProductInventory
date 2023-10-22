using ConsoleProductInventory.Interfaces;
using System.Text;

namespace ConsoleProductInventory.Classes.Commands
{
    internal class AddProductCommand : ICommand
    {
        private readonly Stock _stock;

        public string Description => "Добавить продукт в инвентарь";

        public AddProductCommand(Stock stock)
        {
            _stock = stock;
        }

        private string GetResult()
        {
            StringBuilder stringBuilder = new StringBuilder();

            Console.WriteLine("Наименовение:");

            string productName = Console.ReadLine() ?? "Неизвестно";

            Console.WriteLine("Цена:");

            decimal productPrice = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Количество:");

            int productCnt = Convert.ToInt32(Console.ReadLine());

            Product product = new Product(productName, productPrice, productCnt);

            _stock.Add(product);

            stringBuilder.AppendLine("Продукт успешно добавлен");

            return stringBuilder.ToString();
        }
        public void Execute()
        {
            Console.WriteLine(GetResult());
        }
    }
}
