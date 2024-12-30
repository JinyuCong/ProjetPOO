namespace HearthstoneCollections.Commands;

public class HelpCommand : Command
{
    LocalizationService _localizationService;
    
    public HelpCommand(LocalizationService localizationService)
    {
        this._localizationService = localizationService;
    }

    public override void Execute()
    {
        Console.WriteLine(_localizationService.GetMessage("msg.AddHelp"));
        Console.WriteLine(_localizationService.GetMessage("msg.SearchHelp"));
        Console.WriteLine(_localizationService.GetMessage("msg.DiscoverHelp"));
        Console.WriteLine(_localizationService.GetMessage("msg.LoadHelp"));
        Console.WriteLine(_localizationService.GetMessage("msg.LoadxmlHelp"));
        Console.WriteLine(_localizationService.GetMessage("msg.SaveHelp"));
        Console.WriteLine(_localizationService.GetMessage("msg.SavexmlHelp"));
        Console.WriteLine(_localizationService.GetMessage("msg.SwitchHelp"));
        Console.WriteLine(_localizationService.GetMessage("msg.CountHelp"));
        Console.WriteLine(_localizationService.GetMessage("msg.BattleHelp"));
        Console.WriteLine(_localizationService.GetMessage("msg.ExitHelp"));
        Console.WriteLine(_localizationService.GetMessage("msg.HelpHelp"));
    }

    public override void Documentation()
    {
        Console.WriteLine(_localizationService.GetMessage("msg.HelpHelp"));
    }
}