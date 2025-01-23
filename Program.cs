using System;
using System.Collections.Generic;
using System.Linq;

namespace DiceGame
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Error: You must specify at least three dice configurations as arguments.");
                Console.WriteLine("Each configuration must contain exactly six integers separated by commas.");
                Console.WriteLine("Example: dotnet run 2,2,4,4,9,9 6,8,1,1,8,6 7,5,3,7,5,3");
                return;
            }

            var diceSet = new List<Dice>();
            foreach (var arg in args)
            {
                var parts = arg.Split(',');
                if (parts.Length != 6)
                {
                    Console.WriteLine($"Error: Each dice configuration must contain exactly six integers. Invalid input: '{arg}'");
                    Console.WriteLine("Example: dotnet run 2,2,4,4,9,9 6,8,1,1,8,6 7,5,3,7,5,3");
                    return;
                }

                if (!parts.All(p => int.TryParse(p, out _)))
                {
                    Console.WriteLine($"Error: All values in a dice configuration must be integers. Invalid input: '{arg}'");
                    Console.WriteLine("Example: dotnet run 2,2,4,4,9,9 6,8,1,1,8,6 7,5,3,7,5,3");
                    return;
                }

                var faces = parts.Select(int.Parse).ToArray();
                diceSet.Add(new Dice(faces));
            }

            var game = new DiceGame(diceSet);
            game.Start();
        }
    }
}
