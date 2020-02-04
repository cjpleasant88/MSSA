using System;
/*
 * SYNTACTIC SUGAR
 * In a quick sentence, Sytactic sugar is combination of "clever" coding and visual appeal.
 * Appeal could be more organized or easier to read. 
 * It is a "Sweet" way to write the code. I think you can get too clever with it and actually
 * make it harder to read becuse so many things are being done a line of code that make it hard to either remember or
 * distunguish. 
 * Another more simple example is :    sum += number;      is the same as:      sum = sum + number
 * 
 * There is no added funstionality to the code. It simply is another way to do somehting that is easier or simpler.
 */
namespace EX_2B_Optional_Parameters
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\tHomeWorkPrograms.Program.EX_2B_Optional_Parameters");
            PayAmount();
            PayAmount(20, 40.0);
            PayAmount(10);
            PayAmount(wage:10.0);
        }

        //One method that can actually take in 0, 1, or 2 arguments written in a single line of code.
        static void PayAmount( int hours = 40, double wage = 18.5)
        {
            Console.WriteLine($"Your {hours} hour week just earned you ${wage * hours} !!!");
        }

    }
}
