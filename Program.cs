using System;

namespace GuessingNumber
{
    class Program
    {
        static Random random = new Random();
        static int attempts = 5; // Number of attempts allowed
        static int totalPoints = 100; // Initial total points
        static int pointsLost = 0; // Points lost on each incorrect attempt

        static void Main()
        {
            StartGuessingGame();
        }

        static void StartGuessingGame()
        {
            while (true) // Loop to allow replay
            {
                Console.WriteLine("A random number between 1 and 10 has been generated. Can you guess it?");
                int randomNumber = random.Next(1, 11); // Generate random number
                attempts = 5; // Reset attempts
                pointsLost = 0; // Reset points lost

                while (attempts > 0)
                {
                    Console.WriteLine("Guess the number between 1 and 10:");
                    int userInput;

                    while (!int.TryParse(Console.ReadLine(), out userInput) || userInput < 1 || userInput > 10)
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 10:");
                    }

                    if (userInput == randomNumber)
                    {
                        int finalScore = Math.Max(totalPoints - pointsLost, 0);
                        Console.WriteLine($"Congratulations! You guessed the right number.\nYour total score is {finalScore}");
                        break; // End the game loop if the guess is correct
                    }
                    else
                    {
                        pointsLost += 20; // Deduct 20 points for each incorrect attempt
                        attempts--; // Decrement attempts

                        if (attempts > 0)
                        {
                            Console.WriteLine($"Oops! You're wrong. Please try again. You have {attempts} attempts left.");

                            if (attempts < 3) // Provide hints when only 1 or 2 attempts remain
                            {
                                Console.WriteLine($"Hint: The number is {(randomNumber % 2 == 0 ? "even" : "odd")}.");
                            }
                        }
                        else
                        {
                            int finalScore = Math.Max(totalPoints - pointsLost, 0);
                            Console.WriteLine($"You've used all your attempts! The correct number was {randomNumber}.\n" +
                                              $"Game over. You scored {finalScore} points.");
                        }
                    }
                }

                // Ask if the user wants to play again
                Console.WriteLine("Would you like to play again? (yes/no)");
                string replayChoice = Console.ReadLine()?.Trim().ToLower();
                if (replayChoice != "yes")
                {
                    Console.WriteLine("Thanks for playing! Goodbye.");
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
