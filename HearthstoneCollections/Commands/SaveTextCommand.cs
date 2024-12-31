using HearthstoneCollections.MyExceptions;

namespace HearthstoneCollections.Commands;

public class SaveTextCommand : Command
{
    LocalizationService _localizationService;
    
    public SaveTextCommand(LocalizationService localizationService, Collections collections, string[] commandArguments) : base(collections, commandArguments)
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
        
        StreamWriter sw = new StreamWriter(path);
        
        Collections.Save(sw);
        
        sw.Flush();
        sw.Close();
        Console.WriteLine(_localizationService.GetMessage("msg.SaveTsv") + path);
    }
    
    string AddExtension(string path)
    {
        if (!path.Contains("."))
        {
            return $"{path}.tsv";
        }

        return path;
    }

    public override void Documentation()
    {
        Console.WriteLine(_localizationService.GetMessage("msg.SaveHelp"));
    }
}