using System;

namespace Week3Programs
{
    class EX_3A_Exceptions
    {
        static void Main(string[] args)
        {
            try
            {
                {
                    Console.WriteLine("\tWeek3Programs.EX_3A_Exceptiopns.Main\n");
                        Part1();
                        Part2();
                        Part3();
                        Part4();
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("OverFlow Occured");
            }
            finally
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("***************************************************************");
                Console.WriteLine("\t\tThis is the end of the Program");
                Console.WriteLine("***************************************************************");
                Console.ResetColor();
            }
        }

        public static (double, bool) ValidEntry()
        {
            string userInput = Console.ReadLine();
            double doubleInput;
            bool isValid = false;
            try
            {
                doubleInput = double.Parse(userInput);
                isValid = true;
                return (doubleInput, isValid);
            }

            catch (FormatException)
            {
                doubleInput = -1;
                return (doubleInput, isValid);
            }
            finally
            {
                Console.WriteLine("Okay");
            }
        }

        // Part 1-------------------------------------------------------------
        static void Part1()
        {
            Console.WriteLine("***************************************************************");
            Console.WriteLine("\n\tPart 1, circumference and area of a circle.");
            double doubradius = 0;
            bool isValid = false;
            do
            {
                Console.Write("\nEnter a positive value for the radius: ");
                (doubradius, isValid) = ValidEntry();
                if (isValid == true && doubradius <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Out of range");
                    Console.ResetColor();
                    isValid = false;
                }
                else if (isValid == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Must be valid Number");
                    Console.ResetColor();
                }
            } while (isValid == false);


            double circumference = checked(2 * Math.PI * doubradius);
            Console.WriteLine($"\nThe circumference is {circumference}");

            //Perform math equation
            double area = Math.PI * Math.Pow(doubradius, 2);

            //Give user answer
            Console.WriteLine($"The area is {area}\n");
        }

        // Part 2----------------------------------------------------------- 
        static void Part2()
        {
            Console.WriteLine("***************************************************************");
            Console.WriteLine("\n\tPart 2, volume of a hemisphere.");

            //prompt user and ask for input
            double doubnewradius;
            bool isValid = false;
            do
            {
                Console.Write("\nEnter a positive value for the radius: ");
                (doubnewradius, isValid) = ValidEntry();
                if (isValid == true && doubnewradius <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Out of range");
                    Console.ResetColor();
                    isValid = false;
                }
                else if (isValid == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Must be valid Number");
                    Console.ResetColor();
                }
            } while (isValid == false);

            //math equation using integer input
            double volume = (((4.0 / 3.0) * Math.PI * Math.Pow(doubnewradius, 3)) / 2);

            //Give user the answer
            Console.WriteLine($"\nThe volume is {volume}\n");
        }

        // Part 3-------------------------------------------------------
        static void Part3()
        {
            Console.WriteLine("***************************************************************");
            Console.WriteLine("\n\tPart 3, area of a triangle (Heron's formula).");

            // Implementation here
            //Prompt user and store inputs
            Console.WriteLine("\nLet us call the sides of your triangle a, b, & c\n");

            //Gets and verifies side a
            bool isValid = false;
            double a, b, c;
            do
            {
                Console.Write("\nWhat is the integer length of side a: ");
                (a, isValid) = ValidEntry();
                if (isValid == true && a <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Out of range");
                    Console.ResetColor();
                    isValid = false;
                }
                else if (isValid == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Must be valid Number");
                    Console.ResetColor();
                }
                else if (Math.Ceiling(a % 1)==1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Must be an integer");
                    Console.ResetColor();
                    isValid = false;
                }
            } while (isValid == false);

            //Gets and verifies side b
            do
            {
                Console.Write("\nWhat is the integer length of side b: ");
                (b, isValid) = ValidEntry();
                if (isValid == true && b <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Out of range");
                    Console.ResetColor();
                    isValid = false;
                }
                else if (isValid == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Must be valid Number");
                    Console.ResetColor();
                }
                else if (Math.Ceiling(b % 1) == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Must be an integer");
                    Console.ResetColor();
                    isValid = false;
                }
                else if (Math.Ceiling(b % 1) == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Must be an integer");
                    Console.ResetColor();
                    isValid = false;
                }
            } while (isValid == false);

            //Gets and verifies side c
            do
            {
                Console.Write("\nWhat is the integer length of side c: ");
                (c, isValid) = ValidEntry();
                if (isValid == true && c <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Out of range");
                    Console.ResetColor();
                    isValid = false;
                }
                else if (isValid == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Must be valid Number");
                    Console.ResetColor();
                }
                else if (Math.Ceiling(c % 1) == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Must be an integer");
                    Console.ResetColor();
                    isValid = false;
                }
                else if (Math.Ceiling(c % 1) == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Must be an integer");
                    Console.ResetColor();
                    isValid = false;
                }
            } while (isValid == false);


            //Perform Math functions
            double p = checked(a + b + c) / 2.0;
            double newarea = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

            //Prompt user the answer
            Console.WriteLine($"\nWith sides of a triangle measuring {a}, {b}, & {c}:");
            Console.WriteLine($"The area is {newarea}\n");
        }

        // Part 4-------------------------------------------------------------
        static void Part4()
        {
            Console.WriteLine("***************************************************************");
            Console.WriteLine("\n\tPart 4, solving a quadratic equation.");

            // Implementation here
            // Prompt user and store inputs
            Console.WriteLine("\nThe quadratic equation has coeffecients a, b, & c\n");

            //Gets and verifies coeffeceint a
            double a, b, c;
            bool isValid;
            do
            {
                Console.Write("\nWhat is the integer value of coeffecient a: ");
                (a, isValid) = ValidEntry();
                if (isValid == true && a == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("a = 0 results in division by 0, choose a new a: ");
                    Console.ResetColor();
                    isValid = false;
                }
                else if (isValid == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Must be valid Number");
                    Console.ResetColor();
                }
            } while (isValid == false);

            //Gets and verifies coeffeceint b
            do
            {
                Console.Write("\nWhat is the integer value of coeffecient b: ");
                (b, isValid) = ValidEntry();
                if (isValid == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Must be valid Number");
                    Console.ResetColor();
                }
            } while (isValid == false);

            //Gets and verifies coeffeceint c
            do
            {
                Console.Write("\nWhat is the integer value of coeffecient c: ");
                (c, isValid) = ValidEntry();
                if (isValid == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Must be valid Number");
                    Console.ResetColor();
                }
            } while (isValid == false);

            // Calculates if the SQRT of a negative number will occur
            try
            {
                if ((4 * a * c) > (b * b))
                {
                    throw new Exception();
                }

                //Quad Formula for positive answer without denominator
                double positive_num = (-1.0) * b + Math.Sqrt(Math.Pow(b, 2.0) - 4 * a * c);

                //Quad Formula for negative answer without denominator
                double negative_num = (-1.0) * b - Math.Sqrt(Math.Pow(b, 2.0) - 4 * a * c);
                double denominator = 2.0 * a;

                //Give answers to users
                Console.WriteLine($"\nWith coeffecients a={a}, b={b}, & c={c}:");
                Console.WriteLine($"\nThe positive solution is {positive_num / denominator}");
                Console.WriteLine($"The negative solution is {negative_num / denominator}\n");
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n **ERROR** The given values cause a square root of a negative number!");
                Console.ResetColor();
                Console.WriteLine("Try increasing Absolute value of b or decreasing a and/or c.");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nLet's try again...");
                Console.ResetColor();
                Part4();
            }
        }
    }
}
