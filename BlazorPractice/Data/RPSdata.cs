using System;

namespace BlazorPractice.Data
{
    public class RPSdata
    {
        public string ComputerChoice { get; private set; }
        public string GameResult { get; private set; }

        private Random random = new Random();

        public void PlayGame(string choice)
        {
            // Generate computer's choice randomly
            int computerRandom = random.Next(1, 4);

            // Map the random number to Rock, Paper, or Scissors
            switch (computerRandom)
            {
                case 1:
                    ComputerChoice = "Rock";
                    break;
                case 2:
                    ComputerChoice = "Paper";
                    break;
                case 3:
                    ComputerChoice = "Scissors";
                    break;
            }

            // Determine the game result
            if (choice == ComputerChoice)
            {
                GameResult = "It's a tie!";
            }
            else if ((choice == "Rock" && ComputerChoice == "Scissors") ||
                     (choice == "Paper" && ComputerChoice == "Rock") ||
                     (choice == "Scissors" && ComputerChoice == "Paper"))
            {
                GameResult = "You win!";
            }
            else
            {
                GameResult = "Computer wins!";
            }
        }
    }
}
