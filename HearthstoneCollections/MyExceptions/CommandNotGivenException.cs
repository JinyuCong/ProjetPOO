namespace HearthstoneCollections.MyExceptions;

public class CommandNotGivenException : Exception
{
    public CommandNotGivenException()
    {
        
    }

    public CommandNotGivenException(string message) : base(message)
    {
        
    }
}