
using ConsoleProductInventory.Interfaces;

namespace ConsoleProductInventory.Classes.OutputProviders;

internal class ConsoleOutputProvider : IOutputProvider
{
    public void WriteResult(string result)
    {
        Console.WriteLine(result);
        Console.ReadLine();
    }
}
