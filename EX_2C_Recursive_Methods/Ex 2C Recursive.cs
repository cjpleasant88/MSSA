using System;

namespace EX_2C_Recursive_Methods
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("\n\tHomeWorkProgram.EX_2C_Recursive_Methods.Program.cs");
            WhichPart();
        }

        //Determines which Part of the homework to run between the averages and the Fibanacci series
        public static void WhichPart()
        {
            Console.WriteLine("\nPress any button to continue....");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("********************************************************************************");
            Console.WriteLine("\n----> Hit 'CTRL + C' at any time to exit this Program <----");
            Console.WriteLine("\n\nAlso, please don't enter characters unless asked, not quite sure how to catch those yet...");
            Console.WriteLine("\n\tWhich Part of the Homework would you like to run?");
            Console.WriteLine("Push '1' for the Averaging of Test Scores (Parts 1-3)");
            Console.WriteLine("Push '2' to Find phi using the Fibanacci Series (Part 4)");
            Console.Write("\nYour Choice: ");
            int difficultyLevel = int.Parse(Console.ReadLine());
            if (difficultyLevel == 1 || difficultyLevel == 2)
            {
                switch (difficultyLevel)
                {
                    case 1:
                        AskDifficulty();
                        break;
                    case 2:
                        FibanacciSeries();
                        break;
                }
            }

            //This is for if any other number than 1-2 is entered
            else
            {
                Console.WriteLine("That is not an option!?");
                WhichPart();
            }
        }

        //Determines which difficulty Level to determine Average and call that method
        public static void AskDifficulty()
        {
            Console.WriteLine("\n\tWhich difficulty of Averaging do you want to use? (1-3)");
            Console.WriteLine("(1) Basic Difficulty (Part 1)");
            Console.WriteLine("(2) Intermediate Difficulty (Part 2)");
            Console.WriteLine("(3) Advanced Difficulty (Part 3)");
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
            Console.WriteLine("--------------------------------------------------------\n");
            Console.WriteLine("PART 1");
            Console.WriteLine("Please Enter 10 Test scores between 0 and 100, Hit enter between each test!");
            double sum = 0;
            double average = 0;
            for (int i = 0; i < 10; i++)
            {

                Console.Write($"What is Test Score {i + 1}: ");
                sum += GetEntry();

            }
            average = sum / 10;
            GiveGrade(average);
        }

        //Intermediate Difficulty - Average of user defined number of tests
        public static void IntermediateAverage()
        {
            Console.WriteLine("--------------------------------------------------------\n");
            Console.WriteLine("PART 2");
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
            Console.WriteLine("--------------------------------------------------------\n");
            Console.WriteLine("PART 3");
            Console.WriteLine("Give me your all your tests scores, I can help you out with the average.");
            int numOfTests = 0;
            Console.WriteLine($"Please Enter your Test scores between 0 and 100, Hit enter between each test!\n");
            Console.WriteLine("When you are done, Enter a '-1' as a Test Score!\n");
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

        //Determines if user entered a Valid Test Score
        public static double GetEntry()
        {
            bool isValid = false;
            double userEntry = 0;
            char toStop = 'N';
            while (!isValid)
            {
                userEntry = double.Parse(Console.ReadLine());
                //If it is Valid, returns the user Score
                if (userEntry >= 0 && userEntry <= 100)
                {
                    isValid = true;
                }
                //If it is not Valid tells the user
                else
                {
                    Console.Write($"\n***ERROR***: {userEntry} is not valid,\n\n what is that test score again: ");
                    //Asks the user if they want to stop adding scores if they want to continue entering more
                    if (userEntry == -1)
                    {
                        Console.Write("\n....Wait, are you done entering Tests? [Y / N]: ");
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
            Console.WriteLine("--------------------------------------------------------\n");
            Console.WriteLine($"Your Test Average is :{average}");
            if (average > 89.49)
            {
                Console.WriteLine("You have an A in the class so far, WOW!");
            }
            else if (average > 79.49)
            {
                Console.WriteLine("You have a B in the class so far, great job!");
            }
            else if (average > 69.49)
            {
                Console.WriteLine("You have a C in the class so far, keep it up!");
            }

            else if (average > 59.49)
            {
                Console.WriteLine("You have a D in the class so far, study much?");
            }

            else
            {
                Console.WriteLine("You have an F, change your ways!");
            }
            Console.WriteLine("\n--------------------------------------------------------");
            //returns to pick another part of the homework
            WhichPart();
        }

        //The initialization of the Fibanacci Program
        public static void FibanacciSeries()
        {
            int i = 1;
            long oldNum = 1;
            long currentNum = 1;
            long sum = oldNum + currentNum;
            double phi = 0;
            Console.WriteLine("\nWe are going to use the Fibanacci Series to estimate the value of Phi.");
            Console.Write("\n\nHow many numbers of the Fibancci Series do you want to compute: ");
            int seriesNumber = GetSeriesNumber();
            Console.WriteLine("\nPART 4");
            (i, oldNum, currentNum) = MoreMathStuff(i, seriesNumber, oldNum, currentNum, sum);
            Console.WriteLine($"{i}. phi is {(double)currentNum/(double)oldNum}");
            WhichPart();
        }

        //Retrieves and validates a number from the user
        public static int GetSeriesNumber()
        {
            bool isValid = false;
            int userEntry = 0;
            while (!isValid)
            {
                userEntry = int.Parse(Console.ReadLine());
                if (userEntry >= 0 && userEntry <= 100)
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine($"\n***ERROR***: {userEntry} is not valid,\n\n please keep it between 0 and 100!");
                    Console.Write("How many numbers do you want to compute again: ");
                }
            }
            return userEntry;
        }

        //The computations for the Fibanacci Portion
        public static (int, long, long) MoreMathStuff(int i, int seriesNumber, long oldNum, long currentNum, long sum)
        {
            if (seriesNumber > 1)
            {
                Console.WriteLine($"{i}. {oldNum} + {currentNum} = {sum}");
                seriesNumber--;
                oldNum = currentNum;
                currentNum = sum;
                sum = oldNum + currentNum;
                //Console.WriteLine($"{i}. {oldNum} + {currentNum} = {sum}");
                i++;
                return (MoreMathStuff(i, seriesNumber, oldNum, currentNum, sum));

            }
            return (i, oldNum, currentNum);
        }
    }
}
