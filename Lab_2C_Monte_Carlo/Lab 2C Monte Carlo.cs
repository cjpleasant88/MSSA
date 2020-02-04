using System;

namespace Lab_2C_Monte_Carlo
{
    //This is a test change
    class Program
    {
        //ANSERS TO THE HOMEWORK QUESTIONS ARE 
        //IN A COMMENT BLOCK AT THE END OF ALL THE CODE


            //This is a change
        //Main Method
        static void Main(string[] args)
        {
            Console.WriteLine("\tHomeWorkPrograms.Lab_2C_Monte_Carlo.Program.cs");

           // Console.Write("\nHow many iterations would you like to do: ");
            //int iterations = Convert.ToInt32(Console.ReadLine());
            GetPiValue();
        }

        //Makes sure that at least  1 iteration is computed
        public static void GetPiValue()
        {
           /// if (iterations == 0)
           // {
          //      Console.WriteLine("\nYou need to do at least 1 iteration to approximate PI!");
          //  }
          //  else if (iterations >= 1)
         //   {
                MathStuff();
          //  }
        }

        //Calculates coordinates and outputs Pi Estimate
        public static void MathStuff()
        {
            for (int i = 1; i < 12; i++)
            {
                double x;
                double y;
               int  iterations = (int)Math.Pow(10, i);
                int total = iterations;
                int isInCircle = 0;
                Console.WriteLine($"{iterations} iterations:");
                Random random = new Random();
                //Will go through the number of iterations predetermined by the user
                for (int k = iterations; k > 0; k--)
                {
                    x = random.NextDouble();
                    y = random.NextDouble();
                    //(x, y) = CreateCoordinate();
                    isInCircle += GetHypotenuse(x, y);
                }

                //Uses PI estimate formula from Homework and outputs to user.
                double piEstimate = (((double)isInCircle / (double)total)) * 4.0;
                //Console.WriteLine($"\n{isInCircle} coordinates out of {total} were in the Unit Circle!");

                //Calculates the Absolut Difference between calculated PI and Math.PI
                double piDifference = Math.Abs(piEstimate - Math.PI);
                Console.WriteLine($"\nYour estimate of PI is {piEstimate}");
                Console.WriteLine($"The difference between your value and C#'s valu of PI is {piDifference}");
            }
        }

        /*
        //Will create a random coordinate everytime it is called and pass the coordinate to user
       // public static (double, double) CreateCoordinate()
       {
            Random random = new Random();
            double x = random.NextDouble();
            double y = random.NextDouble();
           return (x, y);
        }
        */
        //Takes in a coordinate and checks to see if it is within the unit circle ot not
        public static int GetHypotenuse(double x, double y)
        {
            double hypotenuse = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            if (hypotenuse <= 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}


/*
 * Answers to home work problems:
 * 
 * 1) Why do we multiply the value from step 5 above by 4?
 * 
 * We do this because we are only calculating an area of coorinates in
 * one quadrant of the circle. To get the ratio for the whole circle, we must
 * multiply by 4. The ratio of insde circle to outside is PI/4.
 * ---------------------------------------------------------------------------------
 * 2) What do you observe in the output when running your
 * program with parameters of increasing size?
 * 
 * The approximation gets closer and closer to the actual value of PI.
 * In other words the Difference that we are calculating gets smaller as 
 * iterations increase.
 * ---------------------------------------------------------------------------------
 * 3) If you run the program multiple times with the same
 * parameter, does the output remain the same? Why or why not?
 * 
 * The ouput does vary. This is likely due that the coordinates are randomly
 * generated. The ratio will vary due to the hypotenuse being generated from the
 * random coordinates.
 * -------------------------------------------------------------------------------
 * 4) Find a parameter that requires multiple seconds of run 
 * time. What is that parameter?
 * 
 * 500,000 requires about 1 second,
 * 1,000,000 requires 2-3 seconds
 * 5,000,000 requires about 13 seconds to run.
 * -------------------------------------------------------------------------------
 * 5) How accurate is the estimated value of pi?
 * 
 * When I ran the parameter of 5,000,000 there was a difference of only 0.00013485
 * from the Math.PI value.
 * -------------------------------------------------------------------------------
 * 6) Research one other use of Monte-Carlo methods. Record
 * it in your exercise submission and be prepared to discuss it in class.
 * 
 * This method is used a lot in the finance industry. Stocks have a lot of uncertainty 
 * and running current price through algorithms that include some of these random parameters
 * many times can give you a general sense of where the price will end up---sometimes.
 */
