using System;

namespace TestArea
{
    class Program
    {
        static void Main()
        {

            try
            {
                cOfCircle();
                vOfHemisphere();
                aOfTriangle();
                quadratic();
            }
            catch (FormatException fOe)
            {
                Console.WriteLine("You must enter a valid number.");
                Main();
            }
            catch (ArgumentOutOfRangeException aorOe)
            {
                Console.WriteLine("Your number is out of range.");
                Main();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Main();
            }
            finally
            {
                Console.WriteLine("Your Number is okay.");
            }
        }
        static void cOfCircle()
        {
            // Part 1
            Console.WriteLine("\nPart 1, circumference and area of a circle.");
            Console.Write("Enter an integer for the radius: ");
            int intradius = int.Parse(Console.ReadLine());
            double circumference = checked(2 * Math.PI * intradius);
            if (circumference < 0) throw new ArgumentOutOfRangeException("Area yields a negative value.");
            Console.WriteLine($"The circumference is {circumference}");

            // Implementation for area here
            try
            {
                Console.WriteLine($"The area is {checked(Math.PI * Math.Pow(intradius, 2))}");
            }
            catch (FormatException fOe)
            {
                Console.WriteLine(fOe.Message);
            }

        }
        static void vOfHemisphere()
        {
            //// Part 2
            Console.WriteLine("\nPart 2, volume of a hemisphere.");
            Console.Write("Enter an integer for the radius of the Hemisphere: ");
            int intHemRadius = int.Parse(Console.ReadLine());
            try
            {
                double volume = checked((2.0 / 3.0) * Math.PI * Math.Pow(intHemRadius, 3));
                if (volume < 0) throw new ArgumentOutOfRangeException("Area yields a negative value.");
                Console.WriteLine($"The volume is {volume}");
            }
            catch (FormatException fOe)
            {
                Console.WriteLine(fOe.Message);
            }
        }

        static void aOfTriangle()
        {
            //// Part 3
            Console.WriteLine("\nPart 3, area of a triangle (Heron's formula).");
            Console.WriteLine("\nEnter an integer for each of the three sides:");
            Console.Write("Side A: ");
            double dblSideA = double.Parse(Console.ReadLine());
            Console.Write("Side B: ");
            double dblSideB = double.Parse(Console.ReadLine());
            Console.Write("Side C: ");
            double dblSideC = double.Parse(Console.ReadLine());
            //Find half of the circumference
            double halfCirc = (dblSideA + dblSideB + dblSideB) / 2;
            try
            {
                double areaTriangle = checked(Math.Sqrt(halfCirc * (halfCirc - dblSideA) * (halfCirc - dblSideB) * (halfCirc - dblSideC)));
                if (areaTriangle < 0) throw new ArgumentOutOfRangeException("Area yields a negative value.");
                Console.WriteLine($"The area is {areaTriangle}");
            }
            catch (FormatException fOe)
            {
                Console.WriteLine(fOe.Message);
            }
        }

        static void quadratic()
        {
            // Part 4
            Console.WriteLine("\nPart 4, solving a quadratic equation.");
            Console.WriteLine("\nEnter an integer for the a, b,and c values: ");
            Console.Write("Value A: ");
            int intValueA = int.Parse(Console.ReadLine());
            Console.Write("Value B: ");
            int intValueB = int.Parse(Console.ReadLine());
            Console.Write("Value C: ");
            int intValueC = int.Parse(Console.ReadLine());

            //Convert strings to integers 
            double dblToSquare = checked(Math.Pow(intValueB, 2.0) - (4.0 * intValueA * intValueC));
            if (dblToSquare < 0)
            {
                throw new ArgumentOutOfRangeException("Square root yields a negative value.");
            }
            else
            {
                Console.WriteLine($"The positive solution is {((-intValueB) + (Math.Sqrt(dblToSquare))) / (2.0 * intValueA)}");
                Console.WriteLine($"The negative solution is {((-intValueB) - (Math.Sqrt(dblToSquare))) / (2.0 * intValueA)}");
            }
        }
    }

}
