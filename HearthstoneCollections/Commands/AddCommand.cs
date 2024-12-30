namespace HearthstoneCollections.Commands;

public class AddCommand : Command
{
    LocalizationService _localizationService;
    
    public AddCommand(LocalizationService localizationService, Collections collections, string[] commandArguments) : base(collections, commandArguments)
    {
        if (commandArguments.Length < 10)
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

        string id = Arguments[0];
        string name = Arguments[1];
        string rarity = Arguments[2];
        string type = Arguments[3];
        string text = Arguments[4];

        if (!int.TryParse(Arguments[5], out int attack))
        {
            Console.Error.WriteLine(_localizationService.GetMessage("msg.ParsingError") + name);
            return;
        }
        
        if (!int.TryParse(Arguments[6], out int health))
        {
            Console.Error.WriteLine(_localizationService.GetMessage("msg.ParsingError") + name);
            return;
        }
        
        if (!int.TryParse(Arguments[7], out int cost))
        {
            Console.Error.WriteLine(_localizationService.GetMessage("msg.ParsingError") + name);
            return;
        }
        
        if (!Class.TryParse(Arguments[8], out Class class_))
        {
            Console.Error.WriteLine(_localizationService.GetMessage("msg.ParsingError") + name);
            return;
        }

        if (!bool.TryParse(Arguments[9], out bool discovered))
        {
            Console.Error.WriteLine(_localizationService.GetMessage("msg.ParsingError") + name);
            return;
        }
        
        Card newCard = new Card(id, name, rarity, type, text, attack, health, cost, class_, discovered);
        
        Collections.Add(newCard);

        Console.WriteLine(_localizationService.GetMessage("msg.CardAdded") + newCard.Name);
    }
    
    public override void Documentation()
    {
        Console.WriteLine(_localizationService.GetMessage("msg.AddHelp"));
    }
}