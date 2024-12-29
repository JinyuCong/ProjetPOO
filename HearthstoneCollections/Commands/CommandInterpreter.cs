using HearthstoneCollections.MyExceptions;

namespace HearthstoneCollections.Commands;

public class CommandInterpreter
{
    Collections _collections;
    LocalizationService _localizationService = new LocalizationService();
    
    public CommandInterpreter(Collections collections)
    {
        this._collections = collections;
    }

    public Command Interpret(string[] arguments)
    {
        if (arguments.Length < 1)
        {
            throw new CommandNotGivenException(_localizationService.GetMessage("msg.CommandRequiesArgument"));
        }
        
        string commandName = arguments[0];
        string[] commandArguments = arguments.Skip(1).ToArray();

        switch (commandName)
        {
            case "add" or "ajouter":
                Command addCommand = new AddCommand(_localizationService, _collections, commandArguments);
                return addCommand;
            case "search" or "rechercher":
                Command searchCommand = new SearchCommand(_localizationService, _collections, commandArguments);
                return searchCommand;
            case "discover" or "découvrir":
                Command discoverCommand = new DiscoverCommand(_localizationService, _collections, commandArguments);
                return discoverCommand;
            case "count" or "compter":
                Command countCommand = new CountCommand(_localizationService, _collections, commandArguments);
                return countCommand;
            case "save" or "enregistrer":
                Command saveTextCommand = new SaveTextCommand(_localizationService, _collections, commandArguments);
                return saveTextCommand;
            case "load" or "charger":
                Command loadTextCommand = new LoadTextCommand(_localizationService, _collections, commandArguments);
                return loadTextCommand;
            case "savexml" or "enregistrerxml":
                Command saveXmlCommand = new SaveXmlCommand(_localizationService, _collections, commandArguments);
                return saveXmlCommand;
            case "loadxml" or "chargerxml":
                Command loadXmlCommand = new LoadXmlCommand(_localizationService, _collections, commandArguments);
                return loadXmlCommand;
            case "switch" or "changer":
                Command switchLanguageCommand = new SwitchLanguageCommand(_localizationService, _collections, commandArguments);
                return switchLanguageCommand;
            case "help" or "aide":
                Command helpCommand = new HelpCommand(_localizationService);
                return helpCommand;
            case "exit" or "quitter":
                Command exitCommand = new ExitCommand(_localizationService);
                return exitCommand;
            default:
                throw new CommandNotFoundException(_localizationService.GetMessage("msg.CommandUnknown") + commandName);
        }
        
    }
}