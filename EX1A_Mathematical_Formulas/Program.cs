using System;

namespace EX_1A_Mathematical_Formulas
{
    class Program
    {
        static void Main(string[] args)
        {
            // Part 1-------------------------------------------------------------
            // Partially worked example
            Console.WriteLine("\nPart 1, circumference and area of a circle.");
            Console.Write("Enter a positive value for the radius: ");
            string strradius = Console.ReadLine();
            double doubradius = double.Parse(strradius);
            double circumference = 2 * Math.PI * doubradius;
            Console.WriteLine($"The circumference is {circumference}");

            // Implementation for area here
            //Perform math equation
            double area = Math.PI * Math.Pow(doubradius, 2.0);

            //Give user answer
            Console.WriteLine($"The area is {area}");

           
            // Part 2-----------------------------------------------------------      
            Console.WriteLine("\nPart 2, volume of a hemisphere.");


            // Implementation here
            //prompt user and ask for input
            Console.Write("Enter an integer for the radius: ");
            strradius = Console.ReadLine();

            //convert input to integer
            doubradius = double.Parse(strradius);

            //math equation using integer input
            double volume = (((4.0 / 3.0) * Math.PI * Math.Pow(doubradius, 3.0)) / 2.0);

           //Give user the answer
            Console.WriteLine($"The volume is {volume}");
       

            // Part 3-------------------------------------------------------

            Console.WriteLine("\nPart 3, area of a triangle (Heron's formula).");

            // Implementation here
            //Prompt user and store inputs
            Console.WriteLine("Let us call the sides of your triangle a, b, & c");
            Console.Write("What is the integer length of side a: ");
            string stra = Console.ReadLine();
            Console.Write("What is the integer length of side b: ");
            string strb = Console.ReadLine();
            Console.Write("What is the integer length of side c: ");
            string strc = Console.ReadLine();

            //convert inputs to integers
            int inta = int.Parse(stra);
            int intb = int.Parse(strb);
            int intc = int.Parse(strc);

            //Perform Math functions
            double p = ((double)inta + (double)intb + (double)intc) / 2.0;
            area = Math.Sqrt(p * (p - (double)inta) * (p - (double)intb) * (p - (double)intc));

           //Prompt user the answer
            Console.WriteLine($"With sides of a triangle measuring {inta}, {intb}, & {intc}:");
            Console.WriteLine($"The area is {area}");

            
            // Part 4-------------------------------------------------------------
            Console.WriteLine("\nPart 4, solving a quadratic equation.");

            // Implementation here
            //Prompt user and store inputs
            Console.WriteLine("The quadratic equation has coeffecients a, b, & c");
            Console.Write("What is the integer value of coeffecient a: ");
            stra = Console.ReadLine();
            Console.Write("What is the integer value of coeffecient b: ");
            strb = Console.ReadLine();
            Console.Write("What is the integer value of coeffecient c: ");
            strc = Console.ReadLine();

            //Convert inputs to integers
            inta = int.Parse(stra);
            intb = int.Parse(strb);
            intc = int.Parse(strc);

            //Quad Formula for positive answer without denominator
            double positive_num = (-1.0) * (double)intb + Math.Sqrt(Math.Pow((double)intb, 2.0) - 4 * (double)inta * (double)intc);

            //Quad Formula for negative answer without denominator
            double negative_num = (-1.0) * (double)intb - Math.Sqrt(Math.Pow((double)intb, 2.0) - 4 * (double)inta * (double)intc);
            double denominator = 2.0 * (double)inta;

            //Give answers to users
            Console.WriteLine($"The positive solution is {positive_num / denominator}");
            Console.WriteLine($"The negative solution is {negative_num / denominator}");
            
        }
    }
}
