namespace HearthstoneCollections.Commands;

public class BattleCommand : Command
{
    LocalizationService _localizationService;

    public BattleCommand(LocalizationService localizationService, Collections collections, string[] commandArguments) :
        base(collections, commandArguments)
    {
        if (commandArguments.Length < 2)
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

        string cardName1 = Arguments[0];
        string cardName2 = Arguments[1];

        bool card1Alive = true;
        bool card2Alive = true;
        
        Card? card1 = Collections.GetByName(cardName1)?.FirstOrDefault();
        Card? card2 = Collections.GetByName(cardName2)?.FirstOrDefault();
        
        if (card1 != null && card2 != null)
        {
            if (card1.Attack >= card2.Health)
            {
                card2Alive = false;
            }

            if (card2.Attack >= card1.Health)
            {
                card1Alive = false;
            }

            if (card1Alive && !card2Alive)
            {
                Console.WriteLine(_localizationService.GetMessage("msg.CardWin") + card1.Name);
            }
            else if (!card1Alive && card2Alive)
            {
                Console.WriteLine(_localizationService.GetMessage("msg.CardWin") + card2.Name);
            }
            else
            {
                Console.WriteLine(_localizationService.GetMessage("msg.NoWinner"));
            }
        }
        else
        {
            if (card1 == null)
            {
                Console.WriteLine(_localizationService.GetMessage("msg.CardNotFount") + cardName1);
            }

            if (card2 == null)
            {
                Console.WriteLine(_localizationService.GetMessage("msg.CardNotFount") + cardName2);
            }
        }
        
    }

    public override void Documentation()
    {
        Console.WriteLine(_localizationService.GetMessage("msg.BattleHelp"));
    }
}