using System;
using System.Text.RegularExpressions;

namespace MessageDecrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfInputs = int.Parse(Console.ReadLine());

            var correctMessage = @"^([$%])[A-Z][a-z][a-z]+\1[:][ ][[][\d]+[]][|][[][\d]+[]][|][[][\d]+[]][|]$";

            var tag = @"^([$%])[A-Z][a-z][a-z]+\1";

            var toDecode = @"[\d]+";

            for (int i = 0; i < numberOfInputs; i++)
            {
                var input = Console.ReadLine();

                if (Regex.IsMatch(input, correctMessage))
                {
                    var result = "";

                    var beginning = Regex.Match(input, tag).ToString();

                    var toBegin = "";

                    for (int j = 1; j < beginning.Length-1; j++)
                    {
                        toBegin += beginning[j];
                    }

                    foreach (var item in Regex.Matches(input, toDecode))
                    {
                        result += (char)int.Parse(item.ToString());
                    }                    

                    Console.WriteLine($"{toBegin}: {result}");
                }

                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
