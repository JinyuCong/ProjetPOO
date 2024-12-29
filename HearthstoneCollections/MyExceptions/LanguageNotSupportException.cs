namespace HearthstoneCollections.MyExceptions;

public class LanguageNotSupportException : Exception
{
    public LanguageNotSupportException() : base()
    {
        
    }

    public LanguageNotSupportException(string message) : base(message)
    {
        
    }
}