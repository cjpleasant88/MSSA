using System;
using System.Collections.Generic;
using System.Text;

namespace Ex_8A_Roulette
{
    public class Bet
    {
        public static int BetNumber { get; set; }

        //Displays the different bets and payout ratios
        public static void DisplayBets1()
        {
            Console.Clear();
            Console.WriteLine("\nHere are the Bets you can make and their payouts:");
            Console.WriteLine("\n#\tBET TYPE\tPAYOUT");
            Console.WriteLine("----------------------------");
            Console.WriteLine("1)\tStraight Up\t35:1");
            Console.WriteLine("2)\tOdds/Evens\t1:1");
            Console.WriteLine("3)\tRed/Blacks\t1:1");
            Console.WriteLine("4)\tLows/Highs\t1:1");
            Console.WriteLine("5)\tDozens\t\t2:1");
            Console.WriteLine("6)\tColumns\t\t2:1");
            Console.WriteLine("7)\tStreet\t\t11:1");
            Console.WriteLine("8)\t6 Numbers\t5:1");
            Console.WriteLine("9)\tSplit\t\t17:1");
            Console.WriteLine("10)\tCorner\t\t8:1");
            Console.WriteLine();
            RouletteGame.player.DisplayWallet();
        }

        public static void DisplayBets2()
        {
            Console.Clear();
            RouletteGame.player.DisplayWallet();
            Console.WriteLine("\nHere are the Bets you can make and their payouts:");
            Console.WriteLine("\n#\tBET TYPE\tPAYOUT");
            Console.WriteLine("----------------------------");
            Console.WriteLine("1)\tStraight Up\t35:1");
            Console.WriteLine("2)\tOdds/Evens\t1:1");
            Console.WriteLine("3)\tRed/Blacks\t1:1");
            Console.WriteLine("4)\tLows/Highs\t1:1");
            Console.WriteLine("5)\tDozens\t\t2:1");
            Console.WriteLine("6)\tColumns\t\t2:1");
            Console.WriteLine("7)\tStreet\t\t11:1");
            Console.WriteLine("8)\t6 Numbers\t5:1");
            Console.WriteLine("9)\tSplit\t\t17:1");
            Console.WriteLine("10)\tCorner\t\t8:1");
        }

        public static int ChooseBetType()
        {
            int betChoice;
            Console.WriteLine();
            RouletteGame.player.DisplayPlayerBet();

            do
            {
                Console.Write("\nWhat kind of bet would you like to make [1-10]: ");

                try
                {
                    betChoice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    betChoice = 0;
                }

                if (betChoice > 0 && betChoice < 11)
                {
                    return betChoice;
                }
                else
                {
                    Console.WriteLine();
                    RouletteGame.Invalid();
                    Console.WriteLine("That kind of bet doesn't make the House any money, please choose one from the list!");
                    betChoice = 0;
                }
            } while (betChoice == 0);
            return betChoice;
        }

        public static int BetAmount(int chipCount)
        {
            if(chipCount == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nYou are all out of chips!!!");
                Console.ResetColor();
                RouletteGame.EndGame();
            }
            int betAmount = 0;
            bool isValid = false;
            do
            {
                isValid = true;
                Console.Write("\nHow much would you like to bet? ");
                try
                {
                    betAmount = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    //Console.WriteLine("\nThat is not something I can accept!");
                    betAmount = 0;
                }

                if (betAmount > RouletteGame.player.ChipCount)
                {
                    Console.WriteLine();
                    RouletteGame.Invalid();
                    Console.WriteLine("You don't have that much to bet!");
                    Console.Write("Please enter an amount less than or equal to ");
                    RouletteGame.player.WalletCount();
                    Console.WriteLine();
                    isValid = false;
                }
                else if (betAmount < 0)
                {
                    Console.WriteLine();
                    RouletteGame.Invalid();
                    Console.WriteLine("You can not bet a negative number!");
                    Console.Write("Please enter a postive number less than or equal to ");
                    RouletteGame.player.WalletCount();
                    Console.WriteLine();
                    isValid = false;
                }
                else if (betAmount == 0)
                {
                    Console.WriteLine();
                    RouletteGame.Invalid();
                    Console.WriteLine("You can not play if you do not bet Chips!");
                    Console.Write("Please enter a postive number less than or equal to ");
                    RouletteGame.player.WalletCount();
                    Console.WriteLine();
                    isValid = false;
                }
            } while (isValid == false);

            return betAmount;
        }
    }
}
