using System;
using System.Collections.Generic;
using System.Linq;

namespace DiceGame
{
    public class DiceGame
    {
        private readonly List<Dice> _originalDiceSet; // stores the initial dice set
        private List<Dice> _diceSet;
        private Dice? _userDice;
        private Dice? _computerDice;

        public DiceGame(List<Dice> diceSet)
        {
            _originalDiceSet = new List<Dice>(diceSet);
            _diceSet = new List<Dice>(diceSet);
        }

        public void Start()
        {
            Console.WriteLine("Let's determine who makes the first move.");

            // generate HMAC for computer's choice (0 or 1)
            var (hmac, key, computerChoice) = FairRandomGenerator.GenerateHMAC(2);
            Console.WriteLine($"I selected a random value in the range 0..1 (HMAC: {hmac})");

            Console.WriteLine("Try to guess my selection.");
            var userChoice = GetUserInput(0, 1);

            Console.WriteLine($"My selection: {computerChoice} (KEY={key}).");

            if (userChoice == computerChoice)
            {
                Console.WriteLine("You guessed correctly. You make the first move.");
                UserSelectsDice();
                ComputerSelectsDice();
            }
            else
            {
                Console.WriteLine("You guessed incorrectly. I make the first move.");
                ComputerSelectsDice();
                UserSelectsDice();
            }

            PlayRound();
        }

        private void UserSelectsDice()
        {
            var choice = GetUserInput(0, _diceSet.Count - 1, true);

            _userDice = _diceSet[choice];
            _diceSet.RemoveAt(choice);

            Console.WriteLine($"\u001b[34mYou chose the [{string.Join(",", _userDice.Faces)}] dice.\u001b[0m");
        }

        private void ComputerSelectsDice()
        {
            var random = new Random();
            int randomIndex = random.Next(0, _diceSet.Count);

            _computerDice = _diceSet[randomIndex];

            _diceSet.RemoveAt(randomIndex);

            Console.WriteLine($"\u001b[34mI chose the [{string.Join(",", _computerDice.Faces)}] dice.\u001b[0m");
        }

        private int GetUserInput(int min, int max, bool diceSelection = false)
        {
            while (true)
            {
                if (diceSelection == true)
                {
                    Console.WriteLine("Choose your dice:");
                    for (int i = 0; i < _diceSet.Count; i++)
                    {
                        Console.WriteLine($"{i} - {string.Join(",", _diceSet[i].Faces)}");
                    }
                } else
                {
                    for (int i = min; i <= max; i++)
                    {
                        Console.WriteLine($"{i} - {i}");
                    }
                }
                Console.WriteLine("X - exit\n? - help");

                Console.Write("Your selection: ");
                var input = Console.ReadLine()?.Trim();
                if (input?.ToLower() == "x")
                {
                    Console.WriteLine("Exiting the game. Goodbye!");
                    Environment.Exit(0); // terminate the game
                }
                if (input == "?")
                {
                    HelpTableGenerator.DisplayHelpTable(_originalDiceSet);
                    continue;
                }

                if (int.TryParse(input, out var choice) && choice >= min && choice <= max)
                    return choice;

                Console.WriteLine("Invalid input. Try again.");
            }
        }

        private void PlayRound()
        {
            if (_userDice == null || _computerDice == null) return;

            // computer's turn
            var (computerHmac, computerKey, computerChoice) = FairRandomGenerator.GenerateHMAC(6);
            Console.WriteLine("It's time for my throw.");
            Console.WriteLine($"I selected a random value in the range 0..5 (HMAC={computerHmac}).");

            Console.WriteLine("Add your number modulo 6.");
            var userChoiceComputerTurn = GetUserInput(0, 5);

            Console.WriteLine($"My number is {computerChoice} (KEY={computerKey}).");
            var computerIndex = (computerChoice + userChoiceComputerTurn) % 6;
            Console.WriteLine($"The result is {computerChoice} + {userChoiceComputerTurn} = {computerIndex} (mod 6).");

            var computerResult = _computerDice.Faces[computerIndex];
            Console.WriteLine($"My throw is {computerResult}.");

            // user's turn
            var (userHmac, userKey, computerChoiceUserTurn) = FairRandomGenerator.GenerateHMAC(6);
            Console.WriteLine("It's time for your throw.");
            Console.WriteLine($"I selected a random value in the range 0..5 (HMAC={userHmac}).");

            Console.WriteLine("Add your number modulo 6.");
            var userChoice = GetUserInput(0, 5);

            Console.WriteLine($"My number is {computerChoiceUserTurn} (KEY={userKey}).");
            var userIndex = (computerChoiceUserTurn + userChoice) % 6;
            Console.WriteLine($"The result is {computerChoiceUserTurn} + {userChoice} = {userIndex} (mod 6).");

            var userResult = _userDice.Faces[userIndex];
            Console.WriteLine($"Your throw is {userResult}.");

            // check winner
            if (userResult > computerResult)
            {
                Console.WriteLine($"You win ({userResult} > {computerResult})!");
            }
            else if (userResult < computerResult)
            {
                Console.WriteLine($"I win ({computerResult} > {userResult})!");
            }
            else
            {
                Console.WriteLine($"It's a tie ({userResult} = {computerResult})!");
            }
        }
    }
}
