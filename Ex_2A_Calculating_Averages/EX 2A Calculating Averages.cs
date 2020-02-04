using System;

namespace Ex_2A_Calculating_Averages
{
    class Program
    {
        // Main Method
        static void Main(string[] args)
        {
            Console.WriteLine("\n\tHomeWorkPrograms.EX_2A_Calculating_Averages.Prgram.cs");
            AskDifficulty();
        }

        //Determines which difficulty Level to determine Average and call that method
        public static void AskDifficulty()
        {
            Console.WriteLine("\nWhich difficulty of Averaging do you want to use? (1-3)");
            Console.WriteLine("(1) Basic Difficulty");
            Console.WriteLine("(2) Intermediate Difficulty");
            Console.WriteLine("(3) Advanced Difficulty");
            Console.Write("\nYour Choice: ");
            int difficultyLevel = int.Parse(Console.ReadLine());
            if (difficultyLevel == 1 || difficultyLevel == 2 || difficultyLevel == 3)
            {
                switch (difficultyLevel)
                {
                    case 1:
                        BasicAverage();
                        break;
                    case 2:
                        IntermediateAverage();
                        break;
                    case 3:
                        AdvancedAverage();
                        break;
                }
            }

            //This is for if any other number than 1-3 is entered
            else
            {
                Console.WriteLine("That is not an option!?");
                AskDifficulty();
            }
        }

        //Baisc Difficulty - Average of exactly 10 test Scores
        public static void BasicAverage()
        {
            Console.WriteLine("Please Enter 10 Test scores between 0 and 100, Hit enter between each test!");
            double sum = 0;
            double average = 0;
            for (int i = 0; i < 10; i++)
            {

                Console.Write($"What is Test Score {i+1}: ");
                sum += GetEntry();

            }
            average = sum / 10;
            GiveGrade(average);
        }

        //Intermediate Difficulty - Average of user defined number of tests
        public static void IntermediateAverage()
        {
            Console.Write("How many Tests do you want to enter: ");
            int numOfTests = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Please Enter your {numOfTests} Test scores between 0 and 100, Hit enter between each test!\n");
            double sum = 0;
            double average = 0;
            for (int i = 0; i < numOfTests; i++)
            {

                Console.Write($"What is Test Score {i + 1}: ");
                sum += GetEntry();

            }
            average = sum / numOfTests;
            GiveGrade(average);
        }

        //Advanced Difficulty - Gives average of the number of tests entered until -1 is seen
        public static void AdvancedAverage()
        {
            Console.WriteLine("Give me your all your tests scores, I can help you out with the average.");
            int numOfTests = 0;
            Console.WriteLine($"Please Enter your Test scores between 0 and 100, Hit enter between each test!\n");
            Console.WriteLine("When you are done, Enter a '-1' as a Test Score!");
            double sum = 0;
            double average = 0;
            bool enterAnotherTest = true;
            double testScore = 0;

            for (int i = 0; enterAnotherTest; i++)
            {
                if (enterAnotherTest == true)
                {
                    Console.Write($"What is Test Score {i + 1}: ");
                    testScore = GetEntry();
                    if (testScore == -1)
                    {
                        enterAnotherTest = false;
                    }
                    else
                    {
                        sum += testScore;
                        numOfTests++;
                    }
                }
            }
            Console.WriteLine($"\n\tYou gave me {numOfTests} Tests to Average!");
            average = sum / numOfTests;
            GiveGrade(average);
        }

        public static double GetEntry()
        {
            bool isValid = false;
            double userEntry = 0;
            char toStop = 'N';
            while (!isValid)
            {
                userEntry = double.Parse(Console.ReadLine());
                if (userEntry >= 0 && userEntry <= 100)
                {
                    isValid = true;
                }
                else
                {
                    Console.Write($"\n***ERROR***: {userEntry} is not valid,\n\n what is that test score again: ");
                    if (userEntry == -1)
                    {
                        Console.WriteLine("\n\tWait, are you done entering Tests [Y / N]");
                        if (char.Parse(Console.ReadLine()) == 'Y')
                        {
                            return userEntry;
                        }

                        else
                        {
                            Console.Write("Oh ok, what is that test score again: ");
                        }
                    }
                }
            }
            return userEntry;
        }

        //Once the average is computed, this method converts to a Letter grade
        public static void GiveGrade(double average)
        {
            Console.WriteLine($"\nYour Test Average is :{average}");
            if (average > 89.49)
            {
                Console.WriteLine("Your have an A in the class so far, WOW!");
            }
            else if (average > 79.49)
            {
                Console.WriteLine("Your have a B in the class so far, great job!");
            }
            else if (average > 69.49)
            {
                Console.WriteLine("Your have a C in the class so far, keep it up!");
            }
            else if (average > 59.49)
            {
                Console.WriteLine("Your have a D in the class so far, study much?");
            }
            else
            {
                Console.WriteLine("You have an F, change your ways!");
            }
        }
    }
}
