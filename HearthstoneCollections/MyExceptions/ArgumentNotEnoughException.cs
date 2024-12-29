namespace HearthstoneCollections.MyExceptions;

public class ArgumentNotEnoughException : Exception
{
    public ArgumentNotEnoughException() : base()
    {
        
    }

    public ArgumentNotEnoughException(string message) : base(message)
    {
        
    }
}