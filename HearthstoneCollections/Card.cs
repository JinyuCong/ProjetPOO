namespace HearthstoneCollections;

public class Card
{
    public string Name { get; set; }
    public string Rarity{ get; set; }
    public string Type { get; set; }
    public string Text { get; set; }
    public int Attack{ get; set; }
    public int Health{ get; set; }
    public int Cost { get; set; }
    public Class Class { get; set; }
    public bool Discovered { get; set; }
    
    public Card(
        string name, 
        string rarity, 
        string type, 
        string text, 
        int attack, 
        int health, 
        int cost,
        Class class_,
        bool discovered
    )
    { 
        Name = name;
        Rarity = rarity;
        Type = type;
        Text = text;
        Attack = attack;
        Health = health;
        Cost = cost;
        Class = class_;
        Discovered = discovered;
    }
    
    // DisplayCard() can plot a ractangle frame arround the card information,
    // size adjusted by the length of the longest information
    public void DisplayCard()
    {
        string[] lines = new string[]
        {
            $"|Name: {Name}", $"|Rarity: {Rarity}", $"|Type: {Type}", $"|Text: {Text}",
            $"|Attack: {Attack}", $"|Health: {Health}", $"|Cost: {Cost}", $"|Class: {Class}",
            $"|Discovered: {Discovered}"
        };
        
        PrintLine(lines);
        
        foreach (string line in lines)
        {
            Console.Write(line);
            PrintSpaceAndBar(lines, line);
        }
        
        PrintLine(lines);
    }

    private void PrintLine(string[] lines)
    {
        string longestLine = lines[0];
        

        foreach (string line in lines)
        {
            if (line.Length > longestLine.Length)
            {
                longestLine = line;
            }
        }
        
        int longestLineLength = longestLine.Length;

        for (int i = 0; i < longestLineLength+1; i++)
        {
            Console.Write("-");
        }
        Console.WriteLine();
    }

    private void PrintSpaceAndBar(string[] lines, string line)
    {
        string longestLine = lines[0];
        

        foreach (string l in lines)
        {
            if (l.Length > longestLine.Length)
            {
                longestLine = l;
            }
        }
        
        int longestLineLength = longestLine.Length;
        
        for (int i = 0; i < longestLineLength-line.Length; i++)
        {
            Console.Write(" ");
        }

        Console.WriteLine("|");
    }
}