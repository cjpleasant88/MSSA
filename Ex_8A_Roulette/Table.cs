using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Ex_8A_Roulette
{
    public class Table
    {
        //Array to store roulette numbers (1-36) in the Layout of a roulette table
        public static int[,] tableLayout = new int[12, 3];

        //Identifies which numbers are red and which are black in separate arrays
        public static int[] reds = { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };
        public static int[] blacks = { 2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35 };

        //Not needed, kept for possible future uses
        //public static int[] col1 = { 1, 4, 7, 10, 13, 16, 19, 22, 25, 28, 31, 34 };
        //public static int[] col2 = { 2, 5, 8, 11, 14, 17, 20, 23, 26, 29, 32, 35 };
        //public static int[] col3 = { 3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36 };


        public Table()
        {
            //Populates the tableLayout array with the numbers 1-36 upon table instantiation
            int singleValue = 1;

            for ( int i = 0; i < tableLayout.GetLength(0); i ++)
            {
                for (int j = 0; j < tableLayout.GetLength(1); j++)
                {
                    tableLayout[i, j] = singleValue;
                    singleValue++;
                }
            }
        }

        //Displays the Table to the user in the Layout of a roulette table
        public void DisplayTable()
        {
            for (int i = 0; i < tableLayout.GetLength(0); i++)
            {
                for (int j = 0; j < tableLayout.GetLength(1); j++)
                {
                    Console.Write(tableLayout[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        //Displays the Table in color to the user in the Layout of a roulette table
        public void DisplayColorTable()
        {
            int value;
            Console.Write("\t\t  ");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("0");
            Console.Write(" ");
            Console.WriteLine("00");
            Console.ResetColor();

            for (int i = 0; i < tableLayout.GetLength(0); i++)
            {
                Console.Write("\t\t");
                for (int j = 0; j < tableLayout.GetLength(1); j++)
                {
                    value = tableLayout[i, j];
                    if (value == 0 || value == 37)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;

                    }
                    for (int k = 0; k < reds.Length; k++)
                    {
                        if (value == reds[k])
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                        }
                    }
                    for (int h = 0; h < blacks.Length; h++)
                    {
                        if (value == blacks[h])
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                    }
                    if (value < 10)
                    {
                        Console.Write(" ");
                    }
                    if (value == 37)
                    {
                        Console.Write("00");
                    }
                    else
                    {
                        Console.Write($"{value} ");
                    }

                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        //Displays the winning number
        public static void Roll()
        {
            Console.WriteLine("\nThe game has begun....No more bets....");
            for (int i = 0; i < 7; i++)
            {
                Thread.Sleep(300);
                Console.WriteLine(".");
            }
            Console.WriteLine("The winning number is....");
            for (int i = 0; i < 4; i++)
            {
                Thread.Sleep(300);
                Console.WriteLine(".");
            }
            Console.WriteLine("\t\t\t    **********");
            if (RouletteGame.winningNumber == 0 || RouletteGame.winningNumber == 37)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;

            }
            for(int i = 0; i < reds.Length; i++)
            {
                if ( RouletteGame.winningNumber == reds[i])
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }
            }
            for (int i = 0; i < blacks.Length; i++)
            {
                if (RouletteGame.winningNumber == blacks[i])
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
            }
            if (RouletteGame.winningNumber == 37)
            {
                Console.Write("\t\t\t\t00");
            }
            else
            {
                Console.Write($"\t\t\t\t{RouletteGame.winningNumber}");
            }
            Console.ResetColor();
            Console.WriteLine("!");
            Console.WriteLine("\t\t\t    **********");
        }
    }
}
