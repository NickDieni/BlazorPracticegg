using System;

namespace BlazorPractice.Data
{
    public class RPSdata
    {
        public RPSenum ComputerChoice { get; private set; }
        public string GameResult { get; private set; }

        private Random random = new Random();

        public void PlayGame(RPSenum choice)
        {
            // Generate computer's choice randomly
            int computerRandom = random.Next(1, 4);

            // Map the random number to Rock, Paper, or Scissors
            switch (computerRandom)
            {
                case 1:
                    ComputerChoice = RPSenum.Rock;
                    break;
                case 2:
                    ComputerChoice = RPSenum.Paper;
                    break;
                case 3:
                    ComputerChoice = RPSenum.Scissors;
                    break;
            }

            // Determine the game result
            if (choice == ComputerChoice)
            {
                GameResult = "It's a tie!";
            }
            else if ((choice == RPSenum.Rock && ComputerChoice == RPSenum.Scissors) ||
                     (choice == RPSenum.Paper && ComputerChoice == RPSenum.Rock) ||
                     (choice == RPSenum.Scissors && ComputerChoice == RPSenum.Paper))
            {
                GameResult = "You win!";
            }
            else
            {
                GameResult = "Computer wins!";
            }
        }
    }

    public enum RPSenum
    {
        Rock,
        Paper,
        Scissors
    }
}
