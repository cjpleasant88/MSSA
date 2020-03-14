using System;
using System.Threading;

namespace EX_9A_Guess_My_Number_Game
{
    class Program
    {
        //ranges and random seed initialized
        public static int rangeLow = 1;
        public static int rangeHigh = 100;
        public static int rangeRealHigh = 1000;
        public static Random random = new Random();

        //Stat keeping for player
        public static int playerTotalGuesses = 0;
        public static int playerGameGuesses = 0;
        public static int playerGames = 0;

        //Stat keeping for computer
        public static int computerTotalGuesses = 0;
        public static int computerGameGuesses = 0;
        public static int computerGames = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("\n\tEX_9A_Guess_My_Number.Program.Main()");
            Start();
        }

        public static void Start()
        {
            int gameType;
            bool playAgain = false;
            Console.WriteLine("\nWelcome to Guess My Number where we....you Guessed it,");
            Console.WriteLine("\tWe Guess your freaking Number!");
            Continue();

            do
            {
                //Determines if computer plays or Human plays (1 or 2)
                gameType = GameType();

                if (gameType == 1)
                {
                    playAgain = ComputerPlays();
                }
                else
                { 
                   playAgain = HumanPlays();
                }
                //Will keeping playing new games until user says to stop
            } while (playAgain);

            //Thanks user for playing
            EndGame();
        }

        //Asks user which game they would like to play
        public static int GameType()
        {
            Console.Clear();
            int choice;

            Console.WriteLine("\nNow we can play one of two ways:");
            Console.WriteLine("\n1) You have a number in your head and we try to guess it");
            Console.WriteLine("2) We pick a number and you try to guess it");

            //Keeps asking until a valid input is received
            do
            {
                Console.Write("\nHow would you like to play? [1-2]: ");
                choice = Choice(2);
            } while (choice == -1);
            return choice;
        }

        //Common game action put into a method
        public static void Continue()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        public static bool ComputerPlays()
        {
            computerGameGuesses = 0;
            int choice = -1;
            int low = rangeLow;
            int high = rangeHigh;
            Console.WriteLine("\nSo you think you can outwit the Computer... Well let's find out");
            Console.WriteLine($"Pick a number between {low} and {high} for the computer to guess.");
            Thread.Sleep(1500);
            Console.WriteLine("\nDon't try and tell me! Keep it to your self, and I will try and guess....");
            Thread.Sleep(1000);
            Console.WriteLine("\nAre you ready!?");
            Thread.Sleep(1000);
            Console.WriteLine("\nOkay, here we go....");

            //Will keep guessing until the user tells the computer it guessed correctly
            do
            {
                    //bisects the range and asks user if that is the number
                choice = ComputerGuess(low, high);

                    //if user says it was too low, the low number is reset to the bisected number
                    //the range is now only the top half of the numbers
                if (choice == 1)
                {
                    low = BisectionGuess(low, high);
                }

                    //if user says it was too high, the high number is reset to the bisected number
                    //the range is now only the bottom half of the numbers
                else if (choice == 2)
                {
                    high = BisectionGuess(low, high);
                }

                //if the number was guessed correctly, the loop will exit and track statistics
                //and ask if the user would like to play again.
            } while (choice != 3);
            computerGames++;
            computerTotalGuesses += computerGameGuesses;
            Console.WriteLine($"\nThat took the computer {computerGameGuesses} guesses.");
            Console.WriteLine($"The average right now is {(double)computerTotalGuesses / computerGames} guesses.");
            return PlayAgain();
        }

        //Gets bisected number and asks user if that is the correct number
        public static int ComputerGuess(int low, int high)
        {
            int choice = -1;
            int guess = BisectionGuess(low, high);

            computerGameGuesses++;
            Console.WriteLine("\n1) Too Low");
            Console.WriteLine("2) Too High");
            Console.WriteLine("3) THAT IS IT!!!");
            Console.Write($"\nIs it {guess}? ");
            do
            {
                choice = Choice(3);
            } while (choice == -1);
            return choice;
        }

        //Gets a random number from the computer and asks user to guess the number
        public static bool HumanPlays()
        {
            playerGameGuesses = 0;
            int low = rangeLow;
            int high = rangeRealHigh;
            int computerNumber = random.Next(1,rangeRealHigh + 1);
            int userNumber;
            Console.WriteLine("\nSo you think you are faster than the Computer... Well let's find out");
            Console.WriteLine($"The computer has picked a number between {rangeLow} and {rangeRealHigh}.");
            Console.WriteLine("Please enter what you think the number is below.");

            //Keeps asking user to guess the number and keeps track of statistics with each guess
            do
            {
                //gets a number form user
                //validates that it is an integer and in the valid range
                do
                {
                    Console.Write("\nEnter your Guess: ");
                    userNumber = Choice(rangeRealHigh);
                } while (userNumber == -1);

                //if user guesses above the correct number
                if (userNumber > computerNumber)
                {
                    Console.WriteLine("Too High");
                    playerGameGuesses++;
                }

                //if user guesses below the correct number
                else if (userNumber < computerNumber)
                {
                    Console.WriteLine("Too Low");
                    playerGameGuesses++;
                }

                //if the user guessed the correct number
                else
                {
                    Console.WriteLine("\nBam, nicely done!");
                    playerGameGuesses++;
                    playerGames++;
                    playerTotalGuesses += playerGameGuesses;
                }
                //will exit this loop when the user guessed the correct number
            } while (computerNumber != userNumber);

            Console.WriteLine($"\nThat took you {playerGameGuesses} guesses.");
            Console.WriteLine($"Your average right now is {(double)playerTotalGuesses / playerGames} guesses.");
            return PlayAgain();
        }

        //This is the actual bisection alogrothim used
        public static int BisectionGuess(int lowNum, int highNum)
        {
            return (lowNum + highNum) / 2;
        }

        public static bool PlayAgain()
        {
            int choice = -1;
            do
            {
                Console.WriteLine("\n1) Yes");
                Console.WriteLine("2) No");
                Console.Write("\n\tThat was fun, would you like to play again? ");
                choice = Choice(2);
            } while (choice == -1);
            if (choice == 1)
            {
                return true;
            }
            return false;
        }

        public static void EndGame()
        {
            Console.WriteLine("**************************************");
            Console.WriteLine("\n\t  Thanks for playing!");
            Console.WriteLine("**************************************");
            System.Environment.Exit(1);
        }

        //Common validation method used throughout the program
        //makes sure the input is an integer
        //makes sure the input is between 1 and a specified range (int choices)
        public static int Choice(int choices)
        {
            int choice = -1;
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                choice = -1;
            }
            if (choice < 1 || choice > choices)
            {
                choice = -1;
                Console.WriteLine("[INVALID] That is not one of the choices");
            }
            return choice;
        }
    }
}
