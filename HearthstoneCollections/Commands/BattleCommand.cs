namespace HearthstoneCollections.Commands;

public class BattleCommand : Command
{
    LocalizationService _localizationService;

    public BattleCommand(LocalizationService localizationService, Collections collections, string[] commandArguments) :
        base(collections, commandArguments)
    {
        if (commandArguments.Length < 2)
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

        string cardName1 = Arguments[0];
        string cardName2 = Arguments[1];
        
        Collections.Battle(cardName1, cardName2);
    }

    public override void Documentation()
    {
        Console.WriteLine(_localizationService.GetMessage("msg.BattleHelp"));
    }
}