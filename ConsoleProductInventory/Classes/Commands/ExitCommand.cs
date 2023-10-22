using ConsoleProductInventory.Interfaces;

namespace ConsoleProductInventory.Classes.Commands;

internal class ExitCommand : ICommand
{
    public string Description => "Выход";
    public void Execute()
    {
        Environment.Exit(0);
    }
}
