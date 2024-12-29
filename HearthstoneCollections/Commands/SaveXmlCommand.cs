using HearthstoneCollections.MyExceptions;
namespace HearthstoneCollections.Commands;

public class SaveXmlCommand : Command
{
    LocalizationService _localizationService;
    
    public SaveXmlCommand(LocalizationService localizationService, Collections collections, string[] commandArguments) : base(collections, commandArguments)
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
        
        string saveDirecty = "Data";
        string path = $"{saveDirecty}/{AddExtension(Arguments[0])}";
        Directory.CreateDirectory(saveDirecty);

        Collections.SaveXml(path);
        
        Console.WriteLine(_localizationService.GetMessage("msg.SaveXml") + path);
    }

    private string AddExtension(string path)
    {
        if (!path.Contains("."))
        {
            return $"{path}.xml";
        }

        return path;
    }
    
    public override void Documentation()
    {
        Console.WriteLine(_localizationService.GetMessage("msg.SavexmlHelp"));
    }
}