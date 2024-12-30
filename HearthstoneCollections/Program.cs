using HearthstoneCollections.Commands;
using System.Text.RegularExpressions;

namespace HearthstoneCollections;

public class Program
{
    public static void Main(string[] args)
    {
        Collections collections = new Collections();
        CommandInterpreter interpreter = new CommandInterpreter(collections);
        
        while (true)
        {
            Console.Write("$ ");
            string? line = Console.ReadLine();
            
            // Use regular expressions to enable the program to recognize text
            // enclosed in double quotes as a single string.
            string pattern = @"[\""].+?[\""]|[^ ]+";

            int commandLength = 0;

            if (line != null)
            {
                foreach (Match m in Regex.Matches(line, pattern))
                {
                    commandLength += 1;
                }
                
                string[] commandArgs = new string[commandLength];
                
                int index = 0;
                
                foreach (Match match in Regex.Matches(line, pattern))
                {
                    string value = match.Value;
                    
                    // exculde the double quotes
                    if (value.StartsWith("\"") && value.EndsWith("\""))
                    {
                        value = value.Substring(1, value.Length - 2);
                    }
                    
                    commandArgs[index] = value;
                    index += 1;
                }
                
                try
                {
                    Command command = interpreter.Interpret(commandArgs);
                    if (commandArgs.Length > 1 && commandArgs[1] == "--help")
                    {
                        command.Documentation();
                    }
                    else
                    {
                        command.Execute();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine();
        }
    }
}