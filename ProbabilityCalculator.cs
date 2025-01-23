using System.Collections.Generic;

namespace DiceGame
{
    public static class ProbabilityCalculator
    {
        public static double CalculateWinProbability(Dice userDice, Dice opponentDice)
        {
            if (userDice == null || opponentDice == null)
                return 0;

            int userWins = 0;
            int totalRolls = userDice.Faces.Count() * opponentDice.Faces.Count();

            foreach (var userRoll in userDice.Faces)
            {
                foreach (var opponentRoll in opponentDice.Faces)
                {
                    if (userRoll > opponentRoll)
                        userWins++;
                }
            }

            return (double)userWins / totalRolls;
        }

    }
}
