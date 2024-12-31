using HearthstoneCollections.MyExceptions;
namespace HearthstoneCollections.Commands;

public class LoadTextCommand : Command
{
    private LocalizationService _localizationService;
    
    public LoadTextCommand(LocalizationService localizationService, Collections collections, string[] commandArguments) : base(collections, commandArguments)
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

        string path = Arguments[0];
        
        if (!File.Exists(path))
        {
            throw new FileNotFoundException(_localizationService.GetMessage("msg.PathNotFound") + path);
        }

        if (!path.Contains("txt") && !path.Contains("csv") && !path.Contains("tsv"))
        {
            throw new FormatException(_localizationService.GetMessage("msg.FileFormatInvalid"));
        }
        
        StreamReader streamReader = new StreamReader(path);
        
        while (!streamReader.EndOfStream)
        {
            string? line = streamReader.ReadLine();
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }
            
            string[] parts = line.Split("\t");

            if (parts.Length != 10)
            {
                Console.Error.WriteLine(_localizationService.GetMessage("msg.LineFormatInvalid") + line);
                continue;
            }
            
            // skip the first line which are titles
            if (parts[0] == "Id" && parts[9] == "Discovered")
            {
                continue;
            }

            string id = parts[0];
            string name = parts[1];
            string rarity = parts[2];
            string type = parts[3];
            string text = parts[4];
            int attack = int.Parse(parts[5]);
            int health = int.Parse(parts[6]);
            int cost = int.Parse(parts[7]);
            Class.TryParse(parts[8], out Class _class);
            bool discovered = bool.Parse(parts[9]);

            Card card = new Card(id, name, rarity, type, text, attack, health, cost, _class, discovered);
            
            Collections.Add(card);

        }
        
        Console.WriteLine(_localizationService.GetMessage("msg.LoadCardsSuccesful") + Collections.Count("all"));
        
        streamReader.Close();
    }

    public override void Documentation()
    {
        Console.WriteLine(_localizationService.GetMessage("msg.LoadHelp"));
    }
}