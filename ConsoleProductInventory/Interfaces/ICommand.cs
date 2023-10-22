namespace ConsoleProductInventory.Interfaces;

internal interface ICommand
{
    string Description { get; }

    void Execute();
}
