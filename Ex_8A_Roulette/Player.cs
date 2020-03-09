using System;
using System.Collections.Generic;
using System.Text;

namespace Ex_8A_Roulette
{
    public class Player
    {
        public string Name { get; set; }
        public int ChipCount { get; set; }

        public int PlayerChipBet { get; set; }
        public int PlayerBetType { get; set; }
        public bool PlayerDidWin { get; set; }

        public int PlayerBetNumber { get; set; }
        public int PlayerWinnings { get; set; }

        public Player(string name = "No-Name")
        {
            ChipCount = 500;
            this.Name = name;
            PlayerChipBet = 0;
            PlayerWinnings = 0;
        }

        public void DisplayWallet()
        {
            Console.Write($"{this.Name}, You currently have ");
            WalletCount();
            Console.WriteLine(" Chips to bet");
        }

        public void WalletCount()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(this.ChipCount);
            Console.ResetColor();
        }

        public void DisplayPlayerBet()
        {
            Console.Write($"You are betting ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(this.PlayerChipBet);
            Console.ResetColor();
            Console.WriteLine(" Chips\n");
        }

    }
}
