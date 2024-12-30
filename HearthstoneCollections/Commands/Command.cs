using System.Security.Cryptography;

namespace HearthstoneCollections.Commands;

public abstract class Command
{
    protected Collections Collections = new Collections();
    protected bool IsValid = true;
    protected string[] Arguments = Array.Empty<string>();

    public Command()
    {
        
    }

    public Command(Collections collections, string[] commandArguments)
    {
        Collections = collections;
        Arguments = commandArguments;
    }
    public abstract void Execute();
    public abstract void Documentation();
}