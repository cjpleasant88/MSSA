using System;

namespace ISTA_421_EX_3B_Math_Games
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\tISTA_421_EX_3B_Math_Games.Program.Main()");
            int probType = 0;
            int numProb = 0;
            int score = 0;
            (probType, numProb) = Util.Initialize();
            if (probType == 1)
            {
                score = Util.Add(numProb);
            }
            else if (probType == 2)
            {
                score = Util.Subtract(numProb);
            }
            else if (probType == 3)
            {
                score = Util.Multiply(numProb);
            }
            else if (probType == 4)
            {
                score = Util.Divide(numProb);
            }
            else
            {
                Console.WriteLine("Sorry you made an invalid choice.");
            }
            string report = Util.Report(score, numProb);
            Console.WriteLine(report);
        }

        public static class Util
        {
            static Random random = new Random();
            static int score;
            static int correctAnswer;
            static int userAnswer;



            public static (int, int) Initialize()
            {
                int probType = -1;
                int numProb = 1;
                Console.WriteLine("Welcome to Math Games");
                Console.WriteLine("  To add, enter 1,");
                Console.WriteLine("  To subtract, enter 2,");
                Console.WriteLine("  To multiply, enter 3,");
                Console.WriteLine("  To divide, enter 4,");
                do
                {
                    Console.Write("Choose your problem type: ");
                    probType = CheckChoice(4);
                } while (probType == -1);
                do
                {
                    Console.Write("Enter number of problems between 1 and 12: ");
                    numProb = CheckChoice(12);
                } while (numProb == -1);

                return (probType, numProb);
            }

            public static int Add(int numProb)
            {
                Summarize("Addition", numProb);
                score = 0;
                for (int i = 0; i < numProb; i++)
                {
                    int a = GetRandom();
                    int b = GetRandom();
                    correctAnswer = a + b;
                    Console.Write($"{i + 1}. {a} + {b} = ");
                    userAnswer = GetUserAnswer();
                    CheckAnswer(userAnswer, correctAnswer);
                }
                return score;
            }

            public static int Subtract(int numProb)
            {
                Summarize("Subtraction", numProb);
                score = 0;
                for (int i = 0; i < numProb; i++)
                {
                    int a = GetRandom();
                    int b = GetRandom();
                    if (b > a)
                    {
                        int temp = a;
                        a = b;
                        b = temp;
                    }
                    correctAnswer = a - b;
                    Console.Write($"{i + 1}. {a} - {b} = ");
                    userAnswer = GetUserAnswer();
                    CheckAnswer(userAnswer, correctAnswer);
                }
                return score;
            }

            public static int Multiply(int numProb)
            {
                Summarize("Multiplication", numProb);
                score = 0;
                for (int i = 0; i < numProb; i++)
                {
                    int a = GetRandom();
                    int b = GetRandom();
                    correctAnswer = a * b;
                    Console.Write($"{i + 1}. {a} * {b} = ");
                    userAnswer = GetUserAnswer();
                    CheckAnswer(userAnswer, correctAnswer);
                }
                return score;
            }

            public static int Divide(int numProb)
            {
                Summarize("Division", numProb);
                score = 0;
                double tolerance = 0.01;
                for (int i = 0; i < numProb; i++)
                {
                    int a = GetRandom();
                    int b = GetRandom();
                    double userDivisionAnswer;
                    double correctDivisionAnswer = (double)a / b;
                    Console.Write($"{i + 1}. {a} / {b} = ");
                    //gets user answer and catches if the enter characters
                    try
                    {
                        userDivisionAnswer = Convert.ToDouble(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        userDivisionAnswer = -1;
                    }

                    //Checks to make sure their answer is +/- 10% of the correct answer
                    if (userDivisionAnswer >= correctDivisionAnswer * (1 - tolerance) && userDivisionAnswer <= correctDivisionAnswer * (1 + tolerance))
                    {
                        userDivisionAnswer = correctDivisionAnswer;
                    }

                    if (userDivisionAnswer == correctDivisionAnswer)
                    {
                        Console.WriteLine("Correct.");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, the correct answer is {correctDivisionAnswer}");
                    }
                }
                return score;
            }

            public static string Report(int score, int numProb)
            {
                double grade = (double)score / numProb * 100;
                return $"You got {score} out of {numProb} correct and your grade is {Math.Round(grade, 2)}";
            }

            //Generates a random integer number between 1 and 12
            public static int GetRandom() => random.Next(1, 12 + 1);

            //Gets an integer value from the user
            public static int GetUserAnswer()
            {
                int userAnswer;
                try
                {
                    userAnswer = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    userAnswer = -1;
                }
                return userAnswer;
            }

            //Common Intro to each Math Method
            public static void Summarize(string utilName, int numProb)
            {
                Console.WriteLine($"You are testing {utilName} and you have {numProb} problems");
                Console.Write("To begin your test, type any key:");
                Console.ReadKey();
                Console.Clear();
            }

            //Compares userAnswer and correctAnswer for all Math Methods
            public static void CheckAnswer(int userAnswer, int correctAnswer)
            {
                if (userAnswer == correctAnswer)
                {
                    Console.WriteLine("Correct.");
                    score++;
                }
                else
                {
                    Console.WriteLine($"Sorry, the correct answer is {correctAnswer}");
                }
            }

            //Makes sure user enters an integer value in a given range
            public static int CheckChoice(int choices)
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
                    Console.WriteLine("Sorry, you made an invalid choice.");
                }
                return choice;
            }
        }

    }
}
