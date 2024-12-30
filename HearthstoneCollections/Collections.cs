using System.Xml.Linq;
using System.Linq;
using System.Net;

namespace HearthstoneCollections;

public class Collections
{
    private Card[] collections = new Card[0];
    private LocalizationService _localizationService = new LocalizationService();
    public Collections()
    {
        
    }

    public void Add(Card newCard)
    {
        if (collections.Any(card => card?.Id == newCard.Id))
        {
            Console.Error.WriteLine(_localizationService.GetMessage("msg.DuplicateCard") + newCard.Name);
            return;
        }
        
        Card[] newCollections = new Card[collections.Length + 1];
        
        for (int i = 0; i < collections.Length; i++)
        {
            newCollections[i] = collections[i];
        }
        
        newCollections[collections.Length] = newCard;
        
        collections = newCollections;
    }

    public Card[]? GetByName(string name)
    {
        Card[] results = collections.Where(n => n.Name.ToLower() == name.ToLower()).ToArray();
        return results;
    }

    public Card[] GetByClass(Class class_)
    {
        Card[] results = collections.Where(n => n.Class == class_).ToArray();
        return results;
    }
    
    // can discover multiple cards on the same time
    public void Discover(string[] args)
    {
        foreach (string cardName in args)
        {
            foreach (Card card in collections)
            {
                if (card.Name.ToLower() == cardName.ToLower())
                {
                    card.Discovered = true;
                    Console.WriteLine(_localizationService.GetMessage("msg.DiscoverCard") + $"{card.Name}");
                }
            }
        }
    }

    public int Count(string value)
    {
        int count = 0;
        
        if (value.ToLower() == "all")
        {
            foreach (Card card in collections)
            {
                count++;
            }
            return count;
        }
        
        value = value.Substring(0, 1).ToUpper() + value.Substring(1, value.Length - 1);
        
        Class.TryParse(value, out Class @class);

        if (@class == 0)
        {
            return 0;
        }
        
        foreach (Card card in collections)
        {
            if (card.Class == @class)
            {
                count++;
            }
        }

        return count;
    }
    
    public void Save(StreamWriter file)
    {
        file.WriteLine($"Id\tName\tRarity\tType\tText\tAttack\tHealth\tCost\tClass\tDiscovered");
        foreach (Card card in collections)
        {
            if (card != null)
            {
                file.WriteLine($"{card.Id}\t{card.Name}\t{card.Rarity}\t{card.Type}\t{card.Text}\t{card.Attack}\t" +
                               $"{card.Health}\t{card.Cost}\t{card.Class}\t{card.Discovered}");
            }            
        }
    }

    public void SaveXml(string filePath)
    {
        XElement root = new XElement("cards");

        foreach (Card card in collections)
        {
            XElement cardElement = new XElement("card",
                    new XElement("id", card.Id),
                    new XElement("name", card.Name),
                    new XElement("rarity", card.Rarity),
                    new XElement("type", card.Type),
                    new XElement("text", card.Text),
                    new XElement("attack", card.Attack),
                    new XElement("health", card.Health),
                    new XElement("cost", card.Cost),
                    new XElement("class", card.Class),
                    new XElement("discovered", card.Discovered)
                );
            root.Add(cardElement);
        }

        XDocument doc = new XDocument(
            new XDeclaration("1.0", "utf-8", "yes"),
            root
        );
        
        doc.Save(filePath);
    }

    public void Battle(string cardName1, string cardName2)
    {
        bool card1Alive = true;
        bool card2Alive = true;
        
        Card? card1 = GetByName(cardName1)?.FirstOrDefault();
        Card? card2 = GetByName(cardName2)?.FirstOrDefault();

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
                Console.WriteLine($"{cardName1} win!");
            }
            else if (!card1Alive && card2Alive)
            {
                Console.WriteLine($"{cardName2} win!");
            }
            else
            {
                Console.WriteLine($"No winner");
            }
        }
        else
        {
            Console.WriteLine($"no card found");
        }
        
    }
    
}