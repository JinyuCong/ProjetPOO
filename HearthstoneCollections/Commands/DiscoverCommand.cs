using HearthstoneCollections.MyExceptions;

namespace HearthstoneCollections.Commands;

public class DiscoverCommand : Command
{
    private LocalizationService _localizationService;
    
    public DiscoverCommand(LocalizationService localizationService, Collections collections, string[] commandArguments) : base(collections, commandArguments) 
    {
        if (commandArguments.Length < 1)
        {
            IsValid = false;
        }
        else if (commandArguments[0] == "--help")
        {
            IsValid = true;
        }
        
        this._localizationService = localizationService;
    }

    public override void Execute()
    {
        if (!IsValid)
        {
            throw new ArgumentNotEnoughException(_localizationService.GetMessage("msg.ArgumentNotEnough"));
        }
        
        Collections.Discover(Arguments);
    }

    public override void Documentation()
    {
        Console.WriteLine(_localizationService.GetMessage("msg.DiscoverHelp"));
    }
}