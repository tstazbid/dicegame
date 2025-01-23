using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using Spectre.Console;

namespace DiceGame
{
    public static class HelpTableGenerator
    {
        public static void DisplayHelpTable(List<Dice> diceSet)
        {
            Console.WriteLine("\u001b[34mProbability of the win for the user:\u001b[0m");

            var table = new Table();
            table.Border = TableBorder.Rounded;

            table.AddColumn("[yellow]User Dice v[/]");
            foreach (var dice in diceSet)
            {
                table.AddColumn($"[aqua]{string.Join(",", dice.Faces)}[/]");
            }

            foreach (var userDice in diceSet)
            {
                var row = new List<string> { $"[magenta]{string.Join(",", userDice.Faces)}[/]" };

                foreach (var opponentDice in diceSet)
                {
                    if (userDice == opponentDice)
                    {
                        row.Add("[red]-[/]");
                    }
                    else
                    {
                        // calculate the probability
                        var winProbability = ProbabilityCalculator.CalculateWinProbability(userDice, opponentDice);
                        row.Add($"[green]{winProbability:0.0000}[/]");
                    }
                }

                table.AddRow(row.ToArray());
            }

            // render table
            AnsiConsole.Write(table);
        }
    }
}
