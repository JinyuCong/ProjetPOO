namespace HearthstoneCollections.Commands;

public class CountCommand : Command
{
    LocalizationService _localizationService;
    
    public CountCommand(LocalizationService localizationService, Collections collections, string[] commandArguments) : base(collections, commandArguments)
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

        string @class = Arguments[0];

        int numCard = Collections.Count(@class);
        
        Console.WriteLine(@class + _localizationService.GetMessage("msg.CardNumber") + numCard);
    }

    public override void Documentation()
    {
        Console.WriteLine(_localizationService.GetMessage("msg.CountHelp"));
    }
}