
using System;

namespace EX_3D_Exception_Handeling
{
    class Program
    {
        static void Main(string[] args)
        {
                Console.WriteLine("Part 1, circumference and area of a circle.\n");
                Part1();
        }

        public static int GetInteger()
        {
            try
            {
                string userInput = Console.ReadLine();
                int intInput = int.Parse(userInput);
                if (intInput <= 0) throw new ArgumentOutOfRangeException();
                return intInput;
            }


            catch (ArgumentOutOfRangeException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Your number is out of range");
                Console.ResetColor();
                return -1;
            }

            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You must enter a valid number.");
                Console.ResetColor();
                return -1;
            }

            finally
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Okay");
                Console.ResetColor();
            }
        }

        // Part 1-------------------------------------------------------------
        static void Part1()
        {

                Console.Write("Enter an integer for the radius: ");
            int radius = -1;
            radius = GetInteger();
            while (radius == -1)
            {
                Console.Write("Enter an integer for the radius: ");
                radius = GetInteger();
            }
                double circumference = 2 * Math.PI * (double)radius;
                Console.WriteLine($"\nThe circumference is {circumference}");

                //Perform math equation
                double area = Math.PI * Math.Pow(radius, 2);

                //Give user answer
                Console.WriteLine($"The area is {area}\n");

        }
    }
}
