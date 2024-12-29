namespace HearthstoneCollections.Commands;

public class ExitCommand : Command
{
    LocalizationService _localizationService;
    
    public ExitCommand(LocalizationService localizationService)
    {
        this._localizationService = localizationService;
    }

    public override void Execute()
    {
        Environment.Exit(0);
    }
    public override void Documentation()
    {
        Console.WriteLine(_localizationService.GetMessage("msg.ExitHelp"));
    }
}