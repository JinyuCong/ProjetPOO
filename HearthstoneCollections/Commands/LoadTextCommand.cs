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

        if (!path.Contains("txt") && !path.Contains("csv"))
        {
            throw new FormatException(_localizationService.GetMessage("msg.FileFormatInvalid"));
        }
        
        StreamReader streamReader = new StreamReader(path);
        
        int count = 0;
        while (!streamReader.EndOfStream)
        {
            string? line = streamReader.ReadLine();
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }
            
            string[] parts = line.Split("\t");

            if (parts.Length != 9)
            {
                Console.Error.WriteLine(_localizationService.GetMessage("msg.LineFormatInvalid") + line);
                continue;
            }
            
            // skip the first line which are titles
            if (parts[0] == "Name" && parts[8] == "Discovered")
            {
                continue;
            }
            
            string name = parts[0];
            string rarity = parts[1];
            string type = parts[2];
            string text = parts[3];
            int attack = int.Parse(parts[4]);
            int health = int.Parse(parts[5]);
            int cost = int.Parse(parts[6]);
            Class.TryParse(parts[7], out Class _class);
            bool discovered = bool.Parse(parts[8]);

            Card card = new Card(name, rarity, type, text, attack, health, cost, _class, discovered);
            
            Collections.Add(card);

            count++;
        }
        
        Console.WriteLine(count + _localizationService.GetMessage("msg.LoadCardsSuccesful"));
        
        streamReader.Close();
    }

    public override void Documentation()
    {
        Console.WriteLine(_localizationService.GetMessage("msg.LoadHelp"));
    }
}