using System;
using System.Threading;

namespace Ex_8A_Roulette
{
    public class RouletteGame
    {
        //Creates a player
        public static Player player = new Player();

        //Creates Table
        public static Table table = new Table();

        //Generates random variable object for deciding winning number
        public static Random random = new Random();

        //Stores winning number to be used by any method
        public static int winningNumber;
        public static int straightUpRatio = 35;

        //Displayed only once when game is program is started
        public static void Welcome()
        {
            Console.WriteLine("\nWelcome to CPR..... Caleb Pleasant's Roulette\n");
            table.DisplayColorTable();
            Console.WriteLine("\nHopefully you won't need CPR by the end of it!");
            Continue();

            //Get player name and store it
            Console.Write("\nWhat is your name: ");
            player.Name = Console.ReadLine();

            //Initiate Game
            Console.WriteLine($"\nWell, {player.Name}, let's take your mo...errm, Let's get started!");    
            Continue();
            GameStart();
        }

        public static void GameStart()
        {
            player.PlayerWinnings = 0;
            int playAgain;

            //Yes, the game gets the winning Number before the bets are made
            winningNumber = GetWinningNumber();

            //Displays the bet types and the winning ratios asks player how much they want to bet
            Bet.DisplayBets1();
            player.PlayerChipBet = Bet.BetAmount(player.ChipCount);

            //Displays bet types and ask the user which bet they would like to make
            Bet.DisplayBets2();
            player.PlayerBetType = Bet.ChooseBetType();

            //Goes to the game the player selected
            PlayGame(player.PlayerBetType);

            //Displays the winning Numebr to the user
            Table.Roll();
            Thread.Sleep(1500);
            //Decides if they player won or lost and tracks their chip numbers
            if (player.PlayerDidWin == true)
            {
                Console.WriteLine("\n\t\t\tCongrats, you won!");
                Console.Write("\t\t\tYou just won ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{player.PlayerWinnings + player.PlayerChipBet}");
                Console.ResetColor();
                Console.WriteLine(" chips!!!");
                player.ChipCount += player.PlayerWinnings;
                Console.Write("\n\t\t\tYou now have ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{player.ChipCount}");
                Console.ResetColor();
                Console.WriteLine(" Chips.");
            }
            else
            {
                Console.Write("\n\tThe house wins again and gained your ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{player.PlayerChipBet}");
                Console.ResetColor();
                Console.WriteLine(" Chips");
                player.ChipCount -= player.PlayerChipBet;
                Console.Write("\n\t\tYou now have ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{player.ChipCount}");
                Console.ResetColor();
                Console.WriteLine(" Chips remaining");
            }

            //Asks the user if they would like to play again
            Console.WriteLine("\n\tWould you like to play again?");
            Console.WriteLine("\n1)\tYes!");
            Console.WriteLine("2)\tNah, I've had enough...");

            //keeps asking until a valid input is given
            do
            {
                Console.Write("\nPlease select [1-2]: ");
                try
                {
                    playAgain = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    playAgain = -1;
                }

                if (playAgain != 1 && playAgain != 2)
                {
                    Invalid();
                    Console.WriteLine("Please select 1 or 2");
                    playAgain = -1;
                }
            } while (playAgain == -1);

            //plays another game or exits program
            if (playAgain == 1)
            {
                GameStart();
            }
            else
            {
                EndGame();
            }
        }

        public static void EndGame()
        {
            Console.WriteLine($"\n{player.Name}, Thanks for stopping by! Hope to see you again!");
            Continue();
            System.Environment.Exit(1);
        }

        public static int GetWinningNumber()
        {
            //generates a number between 0 and 37
            //0-37 are face value winning numbers
            //37 represents a winning number of 00
            int winningNumber = random.Next(38);
            return winningNumber;
        }

        public static void PlayGame(int betType)
        {
            switch (betType)
            {
                case 1:
                    player.PlayerDidWin = StraightUp();
                    break;
                case 2:
                    player.PlayerDidWin = OddsEvens();
                    break;
                case 3:
                    player.PlayerDidWin = RedsBlacks();
                    break;
                case 4:
                    player.PlayerDidWin = LowsHighs();
                    break;
                case 5:
                    player.PlayerDidWin = Dozens();
                    break;
                case 6:
                    player.PlayerDidWin = Columns();
                    break;
                case 7:
                    player.PlayerDidWin = Street();
                    break;
                case 8:
                    player.PlayerDidWin = LineBet();
                    break;
                case 9:
                    player.PlayerDidWin = Split();
                    break;
                case 10:
                    player.PlayerDidWin = Corner();
                    break;
            }
        }

        public static bool StraightUp()
        {
            int winRatio = 35;
            player.PlayerWinnings += (winRatio * player.PlayerChipBet);
            string strPlayerNumber;
            int intPlayerNumber;
            Console.Clear();
            Console.WriteLine("\t\tSTRAIGHT UP BET");
            Console.WriteLine();
            table.DisplayColorTable();
            do
            {
                Console.Write("\nWhich number would you like to put your bet on? [0,00, or 1-36]: ");
                strPlayerNumber = Console.ReadLine();
                switch (strPlayerNumber)
                {
                    case "0":
                        intPlayerNumber = 0;
                        break;
                    case "00":
                        intPlayerNumber = 37;
                        break;
                    default:
                        try
                        {
                            intPlayerNumber = Convert.ToInt32(strPlayerNumber);
                        }
                        catch (Exception)
                        {
                            intPlayerNumber = -1;
                        }
                        if (intPlayerNumber < 0 || intPlayerNumber > 36)
                        {
                            Invalid();
                            Console.WriteLine("Must enter a number of 0, 00, or 1-36");
                            intPlayerNumber = -1;
                        }
                        break;
                }
            } while (intPlayerNumber == -1);

            if (intPlayerNumber == winningNumber)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool OddsEvens()
        {
            int winRatio = 1;
            player.PlayerWinnings += (winRatio * player.PlayerChipBet);
            int choice;

            Console.Clear();
            Console.WriteLine("\t\tODDS/EVENS BET");
            Console.WriteLine();
            table.DisplayColorTable();
            Console.WriteLine("\n1)\tOdds");
            Console.WriteLine("2)\tEvens");
            
            do
            {
                Console.Write("\nDo you want to select odds or evens? [1-2]: ");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    choice = -1;
                }

                if (choice != 1 && choice != 2)
                {
                    Invalid();
                    Console.WriteLine("Please select from the list.");
                    choice = -1;
                }
            } while (choice == -1);

            //If the winning number is 0 or 00 then player automatically loses
            if (winningNumber == 0 || winningNumber == 37)
            {
                return false;
            }

            //If winning number is odd and player selected odd, player wins
            if (winningNumber % 2 == 1 && choice == 1)
            {
                return true;
            }

            //If winning number is even and player selected even, player wins
            if (winningNumber % 2 == 0 && choice == 2)
            {
                return true;
            }
            
            //all other cases casue player to loose
            return false;
        }

        public static bool RedsBlacks()
        {
            int winRatio = 1;
            player.PlayerWinnings += (winRatio * player.PlayerChipBet);
            int choice;
            bool isRed = false;

            Console.Clear();
            Console.WriteLine("\t\tREDS/BLACKS BET");
            Console.WriteLine();
            table.DisplayColorTable();
            Console.WriteLine("\n1)\tReds");
            Console.WriteLine("2)\tBlacks");

            do
            {
                Console.Write("\nDo you want to select reds or blacks? [1-2]: ");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    choice = -1;
                }

                if (choice != 1 && choice != 2)
                {
                    Invalid();
                    Console.WriteLine("Please select from the list.");
                    choice = -1;
                }
            } while (choice == -1);

            //If the winning number is 0 or 00 then player automatically loses
            if (winningNumber == 0 || winningNumber == 37)
            {
                return false;
            }

           for (int i = 0; i < Table.reds.Length; i++)
            {
                if(winningNumber == Table.reds[i])
                {
                    isRed = true;
                    break;
                }
            }

           //if player chooses red and winning number is red, player wins
           if(choice == 1 && isRed == true)
            {
                return true;
            }

           //if player chooses blacks and winning number is black, player wins
           if(choice == 2 && isRed == false)
            {
                return true;
            }

            //all other cases casue player to loose
            return false;
        }

        public static bool LowsHighs()
        {
            int winRatio = 1;
            player.PlayerWinnings += (winRatio * player.PlayerChipBet);
            int choice;
            Console.Clear();
            Console.WriteLine("\t\tLOWS/HIGHS BET");
            Console.WriteLine();
            table.DisplayColorTable();
            Console.WriteLine("\n1)\tLows (1-18)");
            Console.WriteLine("2)\tHighs (19-36)");

            do
            {
                Console.Write("\nDo you want to select lows or Highs? [1-2]: ");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    choice = -1;
                }

                if (choice != 1 && choice != 2)
                {
                    Invalid();
                    Console.WriteLine("Please select from the list.");
                    choice = -1;
                }
            } while (choice == -1);

            //If the winning number is 0 or 00 then player automatically loses
            if (winningNumber == 0 || winningNumber == 37)
            {
                return false;
            }

            //if winning criteria is met, player wins
            if( (winningNumber < 19 && choice == 1) || (winningNumber > 18 && choice == 2))
            {
                return true;
            }

            //all other cases cause player to lose
            return false;
        }

        public static bool Dozens()
        {
            int winRatio = 2;
            player.PlayerWinnings += (winRatio * player.PlayerChipBet);
            int choice;
            Console.Clear();
            Console.WriteLine("\t\tDOZENS BET");
            Console.WriteLine();
            table.DisplayColorTable();
            Console.WriteLine("\n1)\t1st Dozen (1-12)");
            Console.WriteLine("2)\t2nd Dozen (13-24)");
            Console.WriteLine("3)\t3rd Dozen (25-36)");

            do
            {
                Console.Write("\nWhich set of Dozens do you want to bet on? [1-3]: ");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    choice = -1;
                }

                if (choice != 1 && choice != 2 && choice != 3)
                {
                    Invalid();
                    Console.WriteLine("Please select from the list.");
                    choice = -1;
                }
            } while (choice == -1);

            //If the winning number is 0 or 00 then player automatically loses
            if (winningNumber == 0 || winningNumber == 37)
            {
                return false;
            }

            //if winning criteria is met for 1st dozen or 3rd dozen, player wins
            if ((winningNumber < 13 && choice == 1) || (winningNumber > 24 && choice == 3))
            {
                return true;
            }

            //if winning criteria is met for 2nd dozen, player wins
            if (winningNumber > 12 && winningNumber < 25 && choice == 2)
            {
                return true;
            }

            //all other cases cause player to loose bet
            return false;
        }

        public static bool Columns()
        {
            int winRatio = 2;
            player.PlayerWinnings += (winRatio * player.PlayerChipBet);
            int choice;
            Console.Clear();
            Console.WriteLine("\t\tCOLUMNS BET");
            Console.WriteLine();
            table.DisplayColorTable();
            Console.WriteLine("\n1)\t1st Column (1,4,7,10,13,16,19,22,25,28,31,34)");
            Console.WriteLine("2)\t2nd Column (2,5,8,11,14,17,20,23,26,29,32,35)");
            Console.WriteLine("3)\t3rd Column (3,6,9,12,15,18,21,24,27,30,33,36)");

            do
            {
                Console.Write("\nWhich Column do you want to bet on? [1-3]: ");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    choice = -1;
                }

                if (choice != 1 && choice != 2 && choice != 3)
                {
                    Invalid();
                    Console.WriteLine("Please select from the list.");
                    choice = -1;
                }
            } while (choice == -1);

            //If the winning number is 0 or 00 then player automatically loses
            if (winningNumber == 0 || winningNumber == 37)
            {
                return false;
            }

            //puts in player col and checks if winning number is in that column
            for (int i = choice; i < 37; i += 3)
            {
                if (winningNumber == i)
                {
                    return true;
                }
            }

            //all other cases casue player to loose bet
            return false;
        }

        public static bool Street()
        {
            int winRatio = 11;
            player.PlayerWinnings += (winRatio * player.PlayerChipBet);
            int choice;
            Console.Clear();
            Console.WriteLine("\t\tSTREET BET");
            Console.WriteLine();
            table.DisplayColorTable();
            Console.WriteLine("\n1)\t1st Street (1,2,3)");
            Console.WriteLine("2)\t2nd Street (4,5,6)");
            Console.WriteLine("3)\t3rd Street (7,8,9)");
            Console.WriteLine("4)\t4th Street (10,11,12)");
            Console.WriteLine("5)\t5th Street (13,14,15)");
            Console.WriteLine("6)\t6th Street (16,17,18)");
            Console.WriteLine("7)\t7th Street (19,20,21)");
            Console.WriteLine("8)\t8th Street (22,23,24)");
            Console.WriteLine("9)\t9th Street (25,26,27)");
            Console.WriteLine("10)\t10th Street (28,29,30)");
            Console.WriteLine("11)\t11th Street (31,32,33)");
            Console.WriteLine("12)\t12th Street (34,35,36)");

            do
            {
                Console.Write("\nWhich Street do you want to bet on? [1-12]: ");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    choice = -1;
                }

                if (choice < 1 || choice > 12)
                {
                    Invalid();
                    Console.WriteLine("Please select from the list.");
                    choice = -1;
                }
            } while (choice == -1);

            //If the winning number is 0 or 00 then player automatically loses
            if (winningNumber == 0 || winningNumber == 37)
            {
                return false;
            }

            //generates the starting number of the street player selected
            int startingNumber = (choice - 1) * 3 + 1;

            //checks the 3 numbers in that street against winning Number
            for (int i = startingNumber; i < startingNumber + 3; i++)
            {
                if (winningNumber == i)
                {
                    return true;
                }
            }

            //all other cases casue player to loose bet
            return false;
        }

        public static bool LineBet()
        {
            int winRatio = 5;
            player.PlayerWinnings += (winRatio * player.PlayerChipBet);
            int choice;
            Console.Clear();
            Console.WriteLine("\t\t6 NUMBER BET");
            Console.WriteLine();
            table.DisplayColorTable();
            Console.WriteLine("\n1)\t 1st Set of 6 Numbers (1,2,3,4,5,6)");
            Console.WriteLine("2)\t 2nd Set of 6 Numbers (4,5,6,7,8,9)");
            Console.WriteLine("3)\t 3rd Set of 6 Numbers (7,8,9,10,11,12)");
            Console.WriteLine("4)\t 4th Set of 6 Numbers (10,11,12,13,14,15)");
            Console.WriteLine("5)\t 5th Set of 6 Numbers (13,14,15,16,17,18)");
            Console.WriteLine("6)\t 6th Set of 6 Numbers (16,17,18,19,20,21)");
            Console.WriteLine("7)\t 7th Set of 6 Numbers (19,20,21,22,23,24)");
            Console.WriteLine("8)\t 8th Set of 6 Numbers (22,23,24,25,26,27)");
            Console.WriteLine("9)\t 9th Set of 6 Numbers (25,26,27,28,29,30)");
            Console.WriteLine("10)\t10th Set of 6 Numbers (28,29,30,31,32,33)");
            Console.WriteLine("11)\t11th Set of 6 Numbers (31,32,33,34,35,36)");

            do
            {
                Console.Write("\nWhich set of 6 numbers do you want to bet on? [1-11]: ");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    choice = -1;
                }

                if (choice < 1 || choice > 11)
                {
                    Invalid();
                    Console.WriteLine("Please select from the list.");
                    choice = -1;
                }
            } while (choice == -1);

            //If the winning number is 0 or 00 then player automatically loses
            if (winningNumber == 0 || winningNumber == 37)
            {
                return false;
            }

            //generates the starting number of the street player selected
            int startingNumber = (choice - 1) * 3 + 1;

            //checks the 6 numbers in that street against winning Number
            for (int i = startingNumber; i < startingNumber + 6; i++)
            {
                if (winningNumber == i)
                {
                    return true;
                }
            }

            //all other cases casue player to loose bet
            return false;
        }

        public static bool Split()
        {
            int winRatio = 17;
            player.PlayerWinnings += (winRatio * player.PlayerChipBet);
            //Holds first number player intends to split with
            string strPlayerNumber;
            int intPlayerNumber;

            //identifies location in tableLayout array of users first number
            int playerRow = 0;
            int playerCol = 0;

            //will hold all 4 possible values player can split with according to their first number
            //if possible number is not on the board, this array will hold a -1
            int[] possibleSplits = new int[4];

            //will hold users 2nd number they intend to split with
            int splitBet;

            Console.Clear();
            Console.WriteLine("\t\tSPLIT BET");
            Console.WriteLine();
            table.DisplayColorTable();

            //Asks and stores users first number
            do
            {
                Console.Write("\nWhat is the first number you like to put your bet on? [0,00, or 1-36]: ");
                strPlayerNumber = Console.ReadLine();
                switch (strPlayerNumber)
                {
                    case "0":
                        intPlayerNumber = 0;
                        break;
                    case "00":
                        intPlayerNumber = 37;
                        break;
                    default:
                        try
                        {
                            intPlayerNumber = Convert.ToInt32(strPlayerNumber);
                        }
                        catch (Exception)
                        {
                            intPlayerNumber = -1;
                        }
                        if (intPlayerNumber < 0 || intPlayerNumber > 36)
                        {
                            Invalid();
                            Console.WriteLine("Must enter a number of 0, 00, or 1-36");
                            intPlayerNumber = -1;
                        }
                        break;
                }
            } while (intPlayerNumber == -1);

            //Splits can only be made with 1 of 4 adjacent numbers around a chosen number
            //This block identifies user number on board
            for (int i = 0; i < Table.tableLayout.GetLength(0); i++)
            {
                for (int j = 0; j < Table.tableLayout.GetLength(1); j++)
                {
                    if(Table.tableLayout[i, j] == intPlayerNumber)
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                }
            }

            //These try cathes gather the 4 possible split numbers and stores it in an array
            //if the number is not on the board the split number is assigned a -1
            //number above
            try { possibleSplits[0] = Table.tableLayout[playerRow - 1, playerCol]; }
            catch (Exception) { possibleSplits[0] = -1; }

            //number to the left
            try { possibleSplits[1] = Table.tableLayout[playerRow, playerCol - 1]; }
            catch (Exception) { possibleSplits[3] = -1; }

            //number to the right
            try { possibleSplits[2] = Table.tableLayout[playerRow, playerCol + 1]; }
            catch (Exception) { possibleSplits[2] = -1; }

            //number below
            try { possibleSplits[3] = Table.tableLayout[playerRow + 1, playerCol]; }
            catch (Exception) { possibleSplits[1] = -1; }

            //This section displays valid split options to the user only if it is not a -1
            do
            {
                //if user selects 0, can only split with 00
                if (intPlayerNumber == 0)
                {
                    Console.WriteLine("You can only split your 0 bet with 00, Good luck!");
                    splitBet = 37;
                }
                //if user selects 00, can only split with 0
                else if (intPlayerNumber == 37)
                {
                    Console.WriteLine("You can only split your 00 bet with 0, Good luck!");
                    splitBet = 0;
                }
                //Displays the possible split numbers according to the first number they selected
                else
                {
                    Console.Write("\nYou can split your bet with ");
                    for(int i = 0; i < possibleSplits.Length; i++)
                    {
                        if (possibleSplits[i] > 0 && possibleSplits[i] < 37)
                        {
                            Console.Write($"{possibleSplits[i]}  ");
                        }
                    }
                    //Asks user what number to split with, verifies its a number and it is on the board
                    Console.Write($"\n\nWhat would you like to split you bet of {intPlayerNumber} with? ");
                    try
                    {
                        splitBet = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        splitBet = -1;
                    }
                    if (splitBet < 1 || splitBet > 36)
                    {
                        splitBet = -1;
                    }

                    //checks to see if split bet chosen is actually one the possible numbers to split with
                    bool isValid = false;
                    for (int i = 0; i < possibleSplits.Length; i++)
                    {
                        if(splitBet == possibleSplits[i])
                        {
                            isValid = true;
                        }
                    }

                    //if the chosen number is not one of the possible valid bets, split bet set to -1 to re-ask user
                    if (isValid == false)
                    {
                        splitBet = -1;
                    }
                    if (splitBet == -1)
                    {
                        Invalid();
                        Console.WriteLine("Please enter a valid split number");
                    }
                }
            } while (splitBet == -1);

            //Checks to see if either of the split bet numbers match the winning number
            if (intPlayerNumber == winningNumber || splitBet == winningNumber)
            {
                return true;
            }

            //all other cases cause the player to loose their bet
            return false;
        }

        public static bool Corner()
        {
            int winRatio = 8;
            player.PlayerWinnings += (winRatio * player.PlayerChipBet);

            //for getting initial player number and storing location
            string strPlayerNumber;
            int intPlayerNumber;
            int playerRow = 0;
            int playerCol = 0;

            //Corner bets are a collection of 4 numbers
            //Determining a corner bet from a single number leads to 4 possible corner bets
            //This array contains 4 rows, each a possible corner bet
            //each row contains the other 3 values in a possible corner bet besides the user selected number
            int[,] possibleCorners = new int[4, 3];

            //Each column in this array will be used for identifing which row in the possibleCorners array is valid
            //In each column, The top row will increase by one for each valid row for when displaying to user
            //In each column, the bottom row says this index in the possibleCorners array is valid or not (1 or 0) set to 1 initially
            int[,] validCornerRow = { {0, 0, 0, 0} , { 1, 1, 1, 1 } };

            //stores user selected row of the possibleCorners Array
            int winningCorner = 0;


            Console.Clear();
            Console.WriteLine("\t\tCORNER BET");
            Console.WriteLine();
            table.DisplayColorTable();

            //asks the user what thier initial number in the corner bet is
            do
            {
                //Asks user for the number they want in ther corner bet
                Console.Write("\nWhat is the first number you like to put your bet on? [0,00, or 1-36]: ");
                strPlayerNumber = Console.ReadLine();
                switch (strPlayerNumber)
                {
                    case "0":
                        Invalid();
                        Console.WriteLine("Corner bets using number 0 are not possible.");
                        Console.WriteLine("Please choose a valid number 1-36");
                        intPlayerNumber = -1;
                        break;
                    case "00":
                        Invalid();
                        Console.WriteLine("Corner bets using number 00 are not possible.");
                        Console.WriteLine("Please choose a valid number 1-36");
                        intPlayerNumber = -1;
                        break;
                    //determines if it is on the board
                    default:
                        try
                        {
                            intPlayerNumber = Convert.ToInt32(strPlayerNumber);
                        }
                        catch (Exception)
                        {
                            intPlayerNumber = -1;
                        }
                        if (intPlayerNumber < 0 || intPlayerNumber > 36)
                        {
                            Invalid();
                            Console.WriteLine("Must enter a number 1-36");
                            intPlayerNumber = -1;
                        }
                        break;
                }
            } while (intPlayerNumber == -1);

            //Determines location of user number in the table
            for (int i = 0; i < Table.tableLayout.GetLength(0); i++)
            {
                for (int j = 0; j < Table.tableLayout.GetLength(1); j++)
                {
                    if (Table.tableLayout[i, j] == intPlayerNumber)
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                }
            }

            //This section fills in the array conatining all 4 possible corner bets
            //A -1 means that the value was not on the board

            //***************For when user number is bottom left number in square
            //number above
            try { possibleCorners[0,0] = Table.tableLayout[playerRow - 1, playerCol];}
            catch (Exception) { possibleCorners[0,0] = -1; }
            
            //number above to the right
            try { possibleCorners[0,1] = Table.tableLayout[playerRow - 1, playerCol + 1]; }
            catch (Exception) { possibleCorners[0,1] = -1; }
            
            //number to the right
            try { possibleCorners[0,2] = Table.tableLayout[playerRow, playerCol + 1]; }
            catch (Exception) { possibleCorners[0,2] = -1; }
            //***************End of when user number is bottom left number in square


            //***************For user number is bottom right number in square
            //number above to the left
            try { possibleCorners[1, 0] = Table.tableLayout[playerRow - 1, playerCol - 1]; }
            catch (Exception) { possibleCorners[1, 1] = -1; }

            //number above
            try { possibleCorners[1,1] = Table.tableLayout[playerRow - 1, playerCol]; }
            catch (Exception) { possibleCorners[1,0] = -1; }
            
            //number to the left
            try { possibleCorners[1,2] = Table.tableLayout[playerRow, playerCol - 1]; }
            catch (Exception) { possibleCorners[1,2] = -1; }
            //***************End of when user number is bottom right number in square


            //***************For user number is top left number in square
            //number to the right
            try { possibleCorners[2, 0] = Table.tableLayout[playerRow, playerCol + 1]; }
            catch (Exception) { possibleCorners[2, 2] = -1; }

            //number below
            try { possibleCorners[2,1] = Table.tableLayout[playerRow + 1, playerCol]; }
            catch (Exception) { possibleCorners[2,0] = -1; }
            
            //number below to the right
            try { possibleCorners[2,2] = Table.tableLayout[playerRow + 1, playerCol + 1]; }
            catch (Exception) { possibleCorners[2,1] = -1; }
            //***************End of when user number is top left number in square


            //***************For user number is top right number in square
            //number to the left
            try { possibleCorners[3, 0] = Table.tableLayout[playerRow, playerCol - 1]; }
            catch (Exception) { possibleCorners[3, 2] = -1; }

            //number below to the left
            try { possibleCorners[3, 1] = Table.tableLayout[playerRow + 1, playerCol - 1]; }
            catch (Exception) { possibleCorners[3, 1] = -1; }

            //number below
            try { possibleCorners[3,2] = Table.tableLayout[playerRow + 1, playerCol]; }
            catch (Exception) { possibleCorners[3,0] = -1; }
            //***************End of when user number is top right number in square


            //This displays the valid corners and ask user to select
            Console.Write($"\nYou can Corner bet with your number {intPlayerNumber} and these other combinations:");
            Console.WriteLine();
            bool isValid;
            int validRowNum = 1;

            //Determines which rows in the corner bet array are valid (all numbers in corner bet are on the board)
            //Iterates through each of the four possible corner bets
            for (int i = 0; i < possibleCorners.GetLength(0); i++)
            {
                isValid = true;
                //goes through the 3 possible other values in that corner bet row
                for (int j = 0; j < possibleCorners.GetLength(1); j++)
                {
                    if (possibleCorners[i, j] < 1 || possibleCorners[i, j] > 36)
                    {
                        isValid = false;
                    }
                }
                if (isValid == false)
                {
                    //sets the corner bet tracking array to 0 (false) for that row
                    validCornerRow[1, i] = 0;
                    //sets the identifier for that row to -1
                    validCornerRow[0, i] = -1;
                    validRowNum--;
                }
                //if the row is valid, row number stored for user identifier later
                else
                {
                    //sets the identifier
                    validCornerRow[0, i] = validRowNum;
                }
                validRowNum++;
            }//End for loop corner bet checker

            //Displays only Valid corner bet options to user
            for (int i = 0; i < validCornerRow.GetLength(1); i++)
            {
                if (validCornerRow[1, i] == 1)
                {
                    Console.Write($"{validCornerRow[0, i]})\t");
                    for (int j = 0; j < possibleCorners.GetLength(1); j++)
                    {
                        Console.Write($"{possibleCorners[i, j]} ");
                    }
                    Console.WriteLine();
                }
            }

            //Has user select one of the Valid corner bets
            int choice;
            do
            {
                Console.Write($"\nPlease select from the list the Corner you intend to bet on that included your number {intPlayerNumber}? ");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    choice = -1;
                }

                //checks to see if user choice is in the valid corner array
                if (choice > 0 && choice < 5)
                {
                    bool choiceValid = false;
                    for (int i = 0; i < validCornerRow.GetLength(1); i++)
                    {
                        if (choice == validCornerRow[0, i])
                        {
                            choiceValid = true;
                            winningCorner = i;
                        }
                    }
                    if(!choiceValid)
                    {
                        choice = -1;
                    }
                }
                else
                {
                    choice = -1;
                }
                if (choice == -1)
                {
                    Invalid();
                    Console.WriteLine("Please enter a valid corner selection number");
                }
            } while (choice == -1);

            //checks to see if user number of selected corner bet numbers match the winning Number
            for (int i = 0; i < possibleCorners.GetLength(1); i++)
            {
                if (winningNumber == intPlayerNumber || winningNumber == possibleCorners[winningCorner, i])
                {
                    return true;
                }
            }
            return false;
        }

        //Used to suspend program until user acknowledges
        public static void Continue()
        {
            Console.WriteLine("\n\tPress any key to continue...");
            Console.ReadKey();
        }

        //Used to Display [INVALID] in Red
        public static void Invalid()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("[INVALID] ");
            Console.ResetColor();
        }

    }//End Roulette Game class
}
