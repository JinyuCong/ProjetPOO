namespace HearthstoneCollections.Commands;

public class SwitchLanguageCommand : Command
{
    private LocalizationService _localizationService;
    
    public SwitchLanguageCommand(LocalizationService localizationService, Collections collections, string[] commandArguments) : base(collections, commandArguments)
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

        string newLanguage = Arguments[0];

        if (newLanguage != "fr" && newLanguage != "zh")
        {
            throw new LanguageNotSupportException(_localizationService.GetMessage("msg.LanguageNotSupport") + newLanguage);
        }
        
        _localizationService.ChangeLanguage(newLanguage);
        Console.WriteLine(_localizationService.GetMessage("msg.LanguageChanged"));
    }

    public override void Documentation()
    {
        Console.WriteLine(_localizationService.GetMessage("msg.SwitchHelp"));
    }
}