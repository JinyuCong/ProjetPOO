using HearthstoneCollections.MyExceptions;

namespace HearthstoneCollections.Commands;

public class SearchCommand : Command
{
    private LocalizationService _localizationService;
    
    public SearchCommand(LocalizationService localizationService, Collections collections, string[] commandArguments) : base(collections, commandArguments)
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

        string searchArgument = string.Join(" ",  Arguments);
        
        // capitalize the search argument and parse to class
        if (Class.TryParse(char.ToUpper(searchArgument[0])+searchArgument.Substring(1), out Class class_))
        {
            Card[] cards = Collections.GetByClass(class_);
            foreach (Card card in cards)
            {
                if (card != null)
                {
                    card.DisplayCard();
                }
            }
        }
        else
        {
            Card[]? cards = Collections.GetByName(searchArgument);

            if (cards != null && cards.Length > 0)
            {
                foreach (Card card in cards)
                {
                    card.DisplayCard();
                }
            }
            else
            {
                Console.WriteLine(_localizationService.GetMessage("msg.CardNotFount")+ $"{searchArgument}");
            }
        }
    }

    public override void Documentation()
    {
        Console.WriteLine(_localizationService.GetMessage("msg.SearchHelp"));
    }
}