using ConsoleProductInventory.Interfaces;

namespace ConsoleProductInventory.Classes.Commands;

internal abstract class CommandBase : ICommand
{
    private readonly IOutputProvider _outputProvider;

    public abstract string Description { get; }

    public CommandBase(IOutputProvider outputProvider)
    {
        _outputProvider = outputProvider;
    }

    public abstract string GetResult();

    public void Execute()
    {
        _outputProvider.WriteResult(GetResult());
    }
}
