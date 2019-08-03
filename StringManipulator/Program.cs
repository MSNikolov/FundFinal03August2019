using System;
using System.Linq;

namespace StringManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();

            var command = Console.ReadLine();

            while (command != "End")
            {
                var commands = command.Split();

                switch(commands[0])
                {
                    case "Translate":
                        var letter = char.Parse(commands[1]);
                        var replacement = char.Parse(commands[2]);
                        var retext = text.ToCharArray();
                        for (int i = 0; i < retext.Length; i++)
                        {
                            if (retext[i] == letter)
                            {
                                retext[i] = replacement;
                            }
                        }
                        text = "";
                        foreach (var item in retext)
                        {
                            text += item;
                        }
                        Console.WriteLine(text);
                        break;
                    case "Includes":
                        var toCheck = commands[1];
                        if (text.Contains(toCheck))
                        {
                            Console.WriteLine("True");
                        }
                        else
                        {
                            Console.WriteLine("False");
                        }
                        break;
                    case "Start":
                        if (text.StartsWith(commands[1]))
                        {
                            Console.WriteLine("True");
                        }
                        else
                        {
                            Console.WriteLine("False");
                        }
                        break;
                    case "Lowercase":
                        var res = text.ToLower();
                        Console.WriteLine(res);
                        text = res;
                        break;
                    case "FindIndex":
                        var ind = text.LastIndexOf(char.Parse(commands[1]));
                        Console.WriteLine(ind);
                        break;
                    case "Remove":
                        text = text.Remove(int.Parse(commands[1]), int.Parse(commands[2]));
                        Console.WriteLine(text);
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
