namespace HearthstoneCollections.Commands;
using System.Linq;
using System.Xml.Linq;

public class LoadXmlCommand : Command
{
    LocalizationService _localizationService;
    
    public LoadXmlCommand(LocalizationService localizationService, Collections collections, string[] commandArguments) : base(collections, commandArguments)
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
        
        string xmlPath = Arguments[0];

        if (!File.Exists(xmlPath))
        {
            throw new FileNotFoundException(_localizationService.GetMessage("msg.PathNotFound"));
        }

        if (!xmlPath.Contains(".xml"))
        {
            throw new FormatException(_localizationService.GetMessage("msg.FileFormatInvalid"));
        }
        
        XDocument doc = XDocument.Load(xmlPath);

        XElement? root = doc.Root;

        if (root != null)
        {
            int count = 0;
            foreach (var cardElement in root.Elements("Card"))
            {
                string name = cardElement.Element("Name")?.Value ?? "Unknown";
                string rarity = cardElement.Element("Rarity")?.Value ?? "Unknown";
                string type = cardElement.Element("Type")?.Value ?? "Unknown";
                int attack = int.Parse(cardElement.Element("Attack")?.Value ?? "0");
                int health = int.Parse(cardElement.Element("Health")?.Value ?? "0");
                int cost = int.Parse(cardElement.Element("Cost")?.Value ?? "0");
                Class.TryParse(cardElement.Element("Class")?.Value ?? "Neutral", out Class @class);
                string text = cardElement.Element("Text")?.Value ?? "Unknown";
                bool discovered = false;

                Card card = new Card(name, rarity, type, text, attack, health, cost, @class, discovered);
                Collections.Add(card);

                count++;
            }
            
            Console.WriteLine(count + _localizationService.GetMessage("msg.LoadCardsSuccesful"));
        }
        
    }

    public override void Documentation()
    {
        Console.WriteLine(_localizationService.GetMessage("msg.LoadxmlHelp"));
    }
}