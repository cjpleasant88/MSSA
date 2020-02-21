using System;
using System.Threading;

namespace Lab_4C_SpaceGame
{
    class Program
    {
        static void Main(string[] args)
        {
            SpaceGame.SpaceGameIntro();
        }//End Main()
    }//End Program Class

    //Space Game class

    public class SpaceGame
    {
        //Gamer Variables
        static double timer = 60.00;                // Maybe add difficulty level and decrease time to make harder?
        public static double gameTime = 0;          // keeps track of total scavenege and travel time
        public static double scavengeTime = .25;
        public static double travelRatio = 1.7;     // Used to adjust travel time to sensible numbers 
        public static int fuelCost = 12;


        //player created
        static Player hero = new Player();


        //5 Planets created for game Planet(Name, X, Y)
        public static Planet earth = new Planet("Earth", 3, 1);
        public static Planet jupiter = new Planet("Jupiter", 1, 3);
        public static Planet alpha = new Planet("Alpha Centauri B", 12, 2);
        public static Planet unknown = new Planet("Unknown", 11, 4);
        public static Planet tatooine = new Planet("Tatooine", 3, 14);

        //User Ship created
        public static Ship ship = new Ship();
        static Random random = new Random();

        //Trade Prices for Items
        public static int priceSalt = 2;
        public static int priceIron = 4;
        public static int priceSeeds = 50;
        public static int priceHydrogen = 10;
        public static int priceRareMetals = 20;
        public static int priceDarkMatter;
        public static int priceUnobtanium;

        //Start of the game (Title)
        public static void SpaceGameIntro()
        {
            // Game Intro Grpahic
            Console.WriteLine("\tLab_4C_SpaceGame.Program.Main()\n");
            string gameTitle = @"
     ________  ________  ________  ________  _______           ________  ________  _____ ______   _______      
    |\   ____\|\   __  \|\   __  \|\   ____\|\  ___ \         |\   ____\|\   __  \|\   _ \  _   \|\  ___ \     
    \ \  \___|\ \  \|\  \ \  \|\  \ \  \___|\ \   __/|        \ \  \___|\ \  \|\  \ \  \\\__\ \  \ \   __/|    
     \ \_____  \ \   ____\ \   __  \ \  \    \ \  \_|/__       \ \  \  __\ \   __  \ \  \\|__| \  \ \  \_|/__  
      \|____|\  \ \  \___|\ \  \ \  \ \  \____\ \  \_|\ \       \ \  \|\  \ \  \ \  \ \  \    \ \  \ \  \_|\ \ 
        ____\_\  \ \__\    \ \__\ \__\ \_______\ \_______\       \ \_______\ \__\ \__\ \__\    \ \__\ \_______\
       |\_________\|__|     \|__|\|__|\|_______|\|_______|        \|_______|\|__|\|__|\|__|     \|__|\|_______|
       \|_________|                                                               
                                                                               
                                                                                                               
                            ___       ________  ________          ___   ___  ________      
                           |\  \     |\   __  \|\   __  \        |\  \ |\  \|\   ____\                   
                           \ \  \    \ \  \|\  \ \  \|\ /_       \ \  \\_\  \ \  \___|              
                            \ \  \    \ \   __  \ \   __  \       \ \______  \ \  \            
                             \ \  \____\ \  \ \  \ \  \|\  \       \|_____|\  \ \  \____        
                              \ \_______\ \__\ \__\ \_______\             \ \__\ \_______\    
                               \|_______|\|__|\|__|\|_______|              \|__|\|_______|
                                                           
                                                Brought to You By:
                            Brandon Brookins, Caleb Pleasant, Josh Gaston, & Zacahary Silvis";

            Console.WriteLine(gameTitle);
            Continue();
            Console.Clear();

            //Game Starts and to ask user for help
            Welcome();

            //If User says no or timer runs out, game ends with FareWell()
            Farewell();
        }//End SpaceGameIntro()

        //Asks User if they want to play the game
        public static void Welcome()
        {
            ship.level = 1;
            Console.WriteLine("*****************************************************************************************");
            Console.WriteLine("*\t\t\tHURRY! Wake up! We need your help.....                          *");
            Console.WriteLine("*                                                                                       *");
            Console.WriteLine("*\tEarth has been invaded by aliens who have planted a Quantum Nuclear Bomb!       *");
            Console.WriteLine("*****************************************************************************************");
            Console.Write("\n\t\tCan you help us stop it!? [Y/N]: ");
            string willHelp = Convert.ToString(Console.ReadLine().ToUpper());
            switch (willHelp)
            {
                case "Y":
                    StoryLine();
                    break;
                case "N":
                    Console.WriteLine("\nOk, no problem...");
                    break;
                default:
                    Console.WriteLine("\nNot sure what you meant by that, I'll take it as a YES!");
                    Continue();
                    StoryLine();
                    break;
            }
        }// End Welcome()

        //Commonly used code put into a method
        public static void Continue()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }// End Continue()

        //Bad Ending if  user says no to play or timer runs out
        public static void Farewell()
        {
            Console.WriteLine($"\n{timer} Years have passed.");
            Console.WriteLine("The Quantum Nuclear Bomb destoyed earth and all human life on it....Thanks");
            Continue();
            System.Environment.Exit(1);
        }//End Farewell()

        //If you Win the Game
        public static void GoodEnding()
        {
            Console.WriteLine($"You saved us all {hero.name}! The End!");
            Continue();
            System.Environment.Exit(1);
        }//End GoodEnding

        //StoryLine for Space Game
        public static void StoryLine()
        {
            Console.Clear();
            Timer();
            Console.WriteLine("\nGreat! So as you know, the Earth is pending doom.");
            Console.Write("\nWe have ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{timer}");
            Console.ResetColor();
            Console.WriteLine(" years to stop the end of the world!.....plenty of time.");
            Console.Write("Professor W. White says that he can stop it if only he had some ...");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("UnObtanium");
            Console.ResetColor();
            Console.WriteLine("!");
            Continue();
            Console.Write("\nLucky for you, he knows that there is some UnObtanium on the Planet of ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{alpha.name}");
            Console.ResetColor();
            Console.WriteLine("Please go there and get 10 units of UnObtanium for the professor!");
            Continue();
            Console.WriteLine("\nHe gave you 50 credits and says you can take his ship, but it might need to be refueled....");
            Console.WriteLine("He came back from Tatooine late last night and did not stop for gas.");
            hero.credits += 50;
            Continue();
            Console.WriteLine("\nBy the way, the professor would love to know who is about to save humanity (maybe)...");
            Console.Write("\n\t\t\tWhat is your name: ");
            hero.name = Convert.ToString(Console.ReadLine());
            Console.WriteLine($"\nThanks {hero.name}, let's not waste time...");
            Continue();
            Choices();
        }//End StoryLine()

        //Check if Gametime has run out
        public static void CheckTime()
        {
            if (timer - gameTime < 0)
            {
                Farewell();
            }
        }//End CheckTime()

        //Method to Display Time Left until end
        public static void Timer()
        {
            Console.Write("                                               TIME LEFT: ");
            if (timer - gameTime < 20) Console.ForegroundColor = ConsoleColor.Yellow;
            if (timer - gameTime < 10) Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{Math.Round(timer - gameTime, 2)}");
            Console.ResetColor();
            Console.WriteLine(" Years!");

        }//End Timer()

        //The Generic Action Choices Method for any planet
        public static void Choices()
        {
            //Makes sure Time left has not reached 0
            CheckTime();
            Console.Clear();
            Timer();
            Console.Write("GOAL: Get 10 units of UnObtanium from Alpha Centauri B back to Earth Trade Shop\n");
            int choice;
            Console.WriteLine("\nWhat would you like to do?");
            Console.Write($"\nWe have ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{hero.credits}");
            Console.ResetColor();
            Console.Write(" credits to spend on supplies on ");

            //Checks which planet you are on and displays it for the above Console.WriteLine
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(ship.CheckLocation());
            Console.ResetColor();

            //Displays List of Actions
            Console.WriteLine("\nHere is a list of actions to take:");
            Console.WriteLine("\n#\tAction\t\t\tCost");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"1)\tScavenge\t\t{scavengeTime} days");
            Console.WriteLine($"2)\tBuy Fuel\t\t{fuelCost} credits");
            Console.WriteLine($"3)\tTravel\t\t\tFuel");
            Console.WriteLine($"4)\tUpgrade Ship\t\tvaries");
            Console.WriteLine("5)\tView Map\t\t0");
            Console.WriteLine("6)\tView Ship Contents\t0");
            Console.WriteLine("7)\tTrade Shop\t\tVaries");

            //Gets User input for selection and makes sure it is an integer
            Console.Write("\nWhat action would you like to take? [1-7]: ");
            Console.WriteLine("");
            try
            {
                choice = Console.ReadKey().KeyChar - 48;
                //choice = Convert.ToInt32(Console.ReadKey());
            }
            catch (Exception)
            {
                choice = -1;
            }
            Console.WriteLine("");
            Console.WriteLine("");
            //Switch case for a particular action
            switch (choice)
            {
                case 1: //Scavenge
                    {
                        if (ship.CheckLocation() == earth.name)
                        {
                            ScavengeEarth();
                        }
                        if (ship.CheckLocation() == jupiter.name)
                        {
                            ScavengeJupiter();
                        }
                        if (ship.CheckLocation() == alpha.name)
                        {
                            ScavengeAlpha();
                        }
                        if (ship.CheckLocation() == unknown.name)
                        {
                            ScavengeUnknown();
                        }
                        if (ship.CheckLocation() == tatooine.name)
                        {
                            ScavengeTatooine();
                        }
                        Continue();
                        break;
                    }
                case 2: //Buy Fuel
                    {
                        Console.WriteLine("// TODO: Write a BuyFuel Method");
                        Continue();
                        break;
                    }
                case 3: //Travel
                    {
                        WhichPlanet();
                        break;
                    }
                case 4: //Upgrade Ship
                    {
                        Upgrade();
                        break;
                    }
                case 5: //View Map
                    {
                        ViewMap();
                        Continue();
                        break;
                    }
                case 6: //View Ship Contents
                    {
                        ShowInventory();
                        Continue();
                        break;
                    }
                case 7: //Trade Items
                    {
                        Trade();
                        Continue();
                        break;
                    }
                case 9: //Easter Egg to give 100 credits to player
                    hero.credits += 100;
                    break;
                default:
                    {
                        Console.WriteLine("\nThat action is unknown...");
                        Continue();
                        Choices();
                        break;
                    }
            }
            Choices();
        }//End Choices()

        //Method to trade/purchase items with credits
        public static void Trade()
        {
            Console.Clear();
            Timer();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Your Credits: {hero.credits}");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine($"\t\nWelcome to {ship.CheckLocation()}'s Trade Shop!");
            Console.WriteLine("\n\n\tHere are our current prices:");
            Console.WriteLine("ITEM\t\tTRADE PRICE\tYOU HAVE");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"1) Salt\t\t\t{priceSalt}\t{hero.salt}");
            Console.WriteLine($"2) Iron\t\t\t{priceIron}\t{hero.iron}");
            Console.WriteLine($"3) Seeds\t\t{priceSeeds}\t{hero.seeds}");
            Console.WriteLine($"4) Hydrogen\t\t{priceHydrogen}\t{hero.hydrogen}");
            Console.WriteLine($"5) Rare Metals\t\t{priceRareMetals}\t{hero.rareMetals}");
            Console.WriteLine($"6) Dark Matter\t\t{priceDarkMatter}\t{hero.darkMatter}");
            Console.WriteLine($"7) UnObtanium\t\t{priceUnobtanium}\t{hero.unobtanium}");
            Console.WriteLine("8) Back To Choices");
            int choice;
            Console.WriteLine("\nSelect an item you would like to sell in exchange for credits.");
            Console.WriteLine("Dark Matter and UnObtanium can only be purchased on certain Planets.");
            Console.Write("\n\tWhat item would you like to buy/sell [1-8]: ");
            try
            {
                choice = Console.ReadKey().KeyChar - 48;
            }
            catch (Exception)
            {
                choice = -1;
            }
            Console.WriteLine("");
            Console.WriteLine("");
            switch (choice)
            {
                case 1:
                    if (hero.salt == 0)
                    {
                        Console.WriteLine("You don't have any to sell.");
                        Continue();
                        break;
                    }
                    hero.credits += priceSalt;
                    hero.salt--;
                    break;
                case 2:
                    if (hero.iron == 0)
                    {
                        Console.WriteLine("You don't have any to sell.");
                        Continue();
                        break;
                    }
                    hero.credits += priceIron;
                    hero.iron--;
                    break;
                case 3:
                    if (hero.seeds == 0)
                    {
                        Console.WriteLine("You don't have any to sell.");
                        Continue();
                        break;
                    }
                    if (ship.CheckLocation() == "Tatooine")
                    {
                        Console.WriteLine("You just gave this planet the ability to grow vegetation!!!");
                        Console.WriteLine("The tradesman decided to show his appreciation by letting you in on a secret....");
                        Console.WriteLine("Enter 9 at choice menu for Extra Credit..pretty sure we could you use that in class too");
                        Continue();
                    }
                    hero.credits += priceSeeds;
                    hero.seeds--;
                    break;
                case 4:
                    if (hero.hydrogen == 0)
                    {
                        Console.WriteLine("You don't have any to sell.");
                        Continue();
                        break;
                    }
                    hero.credits += priceHydrogen;
                    hero.hydrogen--;
                    break;
                case 5:
                    if (hero.rareMetals == 0)
                    {
                        Console.WriteLine("You don't have any to sell.");
                        if (ship.CheckLocation() == unknown.name)
                        {
                            Console.WriteLine($"The planet {jupiter.name} has heaps of rare Metals!");
                        }
                        Continue();
                        break;
                    }
                    if (ship.CheckLocation() == unknown.name)
                    {
                        Console.WriteLine("Much appreciated for the Rare Metals!");
                        Console.WriteLine("Here is some Dark Matter, I hope you know what to do with it!");
                        hero.darkMatter++;
                        Continue();
                    }
                    hero.credits += priceRareMetals;
                    hero.rareMetals--;
                    break;
                case 6:
                    if (hero.darkMatter == 0)
                    {
                        Console.WriteLine("You don't have any to sell.");
                        Continue();
                        break;
                    }
                    if (ship.CheckLocation() == alpha.name)
                    {
                        Console.WriteLine("Wow, I can't believe you found Dark Matter!");
                        Console.WriteLine("Here is some UnObtanium for your trouble.");
                        hero.unobtanium++;
                        hero.darkMatter--;
                        Continue();
                    }
                    break;
                case 7:
                    if (ship.CheckLocation() == "Alpha Centauri B")
                    {
                        Console.WriteLine("Nope not yere, that is illegal to have.");
                        Console.WriteLine("...psst, Dark Matter from the unknown planet might bring what you desire");
                        Continue();
                    }
                    if (hero.unobtanium == 0)
                    {
                        Console.WriteLine("You don't have any to sell.");
                        Continue();
                        break;
                    }
                    if (ship.CheckLocation() == "Earth")
                    {
                        if (hero.unobtanium < 10)
                        {
                            Console.WriteLine("You did all of that and didn't bring 10 units, I hope you have time to get more!");
                            Continue();
                            break;
                        }
                        GoodEnding();
                    }
                    break;
                case 8:
                    Choices();
                    break;
                default:
                    Console.WriteLine("That item has not been discovered yet...");
                    Continue();
                    Trade();
                    break;
            }
            Trade();
        }//End Trade

        //Method that shows Ship level and available upgrades
        public static void Upgrade()
        {
            int choice;
            Console.Clear();
            Timer();
            Console.WriteLine($"Your ship is currently Level {ship.level}\n");

            //Switch case to determine what the user sees available depending on their ship level
            switch (ship.level)
            {
                case 1:
                    Console.WriteLine("For 100 credits, Ship Level 2 will allow you to carry 1000 items");
                    goto case 2;
                case 2:
                    Console.WriteLine("For 150 more credits, Ship Level 3 will give you WARP drive based on based on Star Trek TNG Warp Factor!!!\n");
                    break;
                case 3:
                    Console.WriteLine("\nYou have the greatest ship in the galaxy, there are no more upgrades for you!");
                    Continue();
                    Choices();
                    break;
            }

            //List the options the user can choose from
            Console.WriteLine("1)\tNevermind");
            Console.WriteLine("2)\tLevel 2 Upgrade");
            Console.WriteLine("3)\tLevel 3 Upgrade");
            Console.Write("\nWhich upgrade would like: ");

            //Gets the user option and makes sure it is valid
            try
            {
                choice = Console.ReadKey().KeyChar - 48;
            }
            catch (Exception)
            {
                choice = -1;
            }
            Console.WriteLine("");
            Console.WriteLine("");
            switch (choice)
            {
                case 1:
                    Choices();
                    break;
                case 2:
                    if (hero.credits < 100)
                    {
                        NotEnoughCredits();
                    }
                    ship.level = 2;
                    hero.credits -= 100;
                    ship.capacity = 1000;
                    Console.WriteLine("\nYou can now hold more cargo and the weight of larger items.....like a WARP engine!");
                    break;
                case 3:
                    if (ship.level == 1)
                    {
                        Console.WriteLine("\nYou need to upgrade to level 2 before your ship can handle the WARP engine.");
                        Continue();
                        Choices();
                    }
                    if (hero.credits < 150)
                    {
                        NotEnoughCredits();
                    }
                    ship.level = 3;
                    hero.credits -= 150;
                    Console.WriteLine("\nNothing is stopping you from obtaining UnObtanium now...Go get it!");
                    break;
                default:
                    Console.WriteLine("\nWe don't have theat kind of upgrade yet....please choose one of these.");
                    Continue();
                    Upgrade();
                    break;
            }
            Continue();
            Choices();
        }//End Upgrade()

        //Display when buying and credits are not enough
        public static void NotEnoughCredits()
        {
            Console.WriteLine($"\n\n{hero.credits} is not enough to buy that, what now?.");
            Console.WriteLine("\nTry scavenging planets and selling what you find at the Trade Shop for credits!");
            Continue();
            Choices();
        }//End NotEnoughCredits()

        //Randomly gain items Earth Specific
        public static void ScavengeEarth()
        {
            Console.Clear();
            Console.WriteLine("\tYou went out for a few weeks and....");
            Console.WriteLine("");
            int chance = (int)(random.NextDouble() * 101);
            int numOfItems = (int)(random.NextDouble() * 11);
            if (chance >= 0 && chance < 51)
            {
                Console.WriteLine($"You found {numOfItems} units of salt");
                hero.salt += numOfItems;
            }
            else if (chance > 50 && chance < 91)
            {
                Console.WriteLine($"You found {numOfItems} units of iron");
                hero.iron += numOfItems;
            }
            else if (chance > 90 && chance < 96)
            {
                Console.WriteLine($"You found {numOfItems} units of seeds!");
                hero.seeds += numOfItems;
            }
            else
            {
                Console.WriteLine("What a waste, you did not find a thing..");
            }
            gameTime += scavengeTime;
            Continue();
            Choices();
        }//End ScavengeEarth()

        //Randomly gain items Jupiter Specific
        public static void ScavengeJupiter()
        {
            Console.Clear();
            Console.WriteLine("\tYou went out for a few weeks and....");
            Console.WriteLine("");
            int chance = (int)(random.NextDouble() * 101);
            int numOfItems = (int)(random.NextDouble() * 11);
            if (chance >= 0 && chance < 31)
            {
                Console.WriteLine($"You found {numOfItems} units of hydrogen");
                hero.hydrogen += numOfItems;
            }
            else if (chance > 30 && chance < 71)
            {
                Console.WriteLine($"You found {numOfItems} units of Rare Metals!");
                hero.rareMetals += numOfItems;
            }
            else
            {
                Console.WriteLine("What a waste, you did not find a thing..");
            }
            gameTime += scavengeTime;
            Continue();
            Choices();
        }//End ScavengeJupiter()

        //Tell user that bring Rare Metals
        public static void ScavengeUnknown()
        {
            Console.Clear();
            Console.WriteLine("\tYou went out for a few weeks and discovered....");
            Console.WriteLine("\tThere is nothing to Scavenge on this planet!");
            Continue();
            Console.WriteLine("\nAn unknown being stopped you and requested some Rare Metals in exchange for Dark Matter at the Trade Shop.");
            gameTime += scavengeTime;
            Continue();
            Choices();
        }//End ScavengeUnknown()

        //Tell uses to look at the Trade Shop when on Alpha
        public static void ScavengeAlpha()
        {
            Console.Clear();
            Console.WriteLine("\tYou went out for a few weeks and discovered....");
            Console.WriteLine("\tThere is nothing to Scavenge on this planet!");
            Continue();
            Console.WriteLine("\nYou did run into a native that said the Tradesman sells that which you can not obtain!?");
            gameTime += scavengeTime;
            Continue();
            Choices();
        }//End ScavengeAlpha()

        //Tells the user that Tatooine is Barren
        public static void ScavengeTatooine()
        {
            Console.Clear();
            Console.WriteLine("\tYou went out for a few hours and discovered....");
            Console.WriteLine("\tThere is nothing to Scavenge on this planet!");
            Continue();
            Console.WriteLine("\nYou ran into Dan! He said the seeds he plants here will grow into abundance...");
            gameTime += scavengeTime;
            Continue();
            Choices();
        }//End ScavengeTatooine()

        //When travel action is selected, user gets asked which planet to travel to
        public static void WhichPlanet()
        {
            int choice;
            Console.Clear();
            Timer();

            //Determines which planet they are on
            Console.Write("\tYou are on Planet ");
            Console.WriteLine(ship.CheckLocation());

            //Displays planet options to travel to
            Console.WriteLine("\nHere are the planets in our system:");
            Console.WriteLine($"1)\t{earth.name}");
            Console.WriteLine($"2)\t{jupiter.name}");
            Console.WriteLine($"3)\t{alpha.name}");
            Console.WriteLine($"4)\t{unknown.name}");
            Console.WriteLine($"5)\t{tatooine.name}");
            Console.WriteLine($"6)\tBack to Choices");

            //Asks user for selection and validates it is an integer
            Console.WriteLine("\nWhere would you like to go");
            try
            {
                choice = Console.ReadKey().KeyChar - 48;
            }
            catch (Exception)
            {
                choice = -1;
            }
            Console.WriteLine("");
            Console.WriteLine("");
            //Makes sure user is not already on that planet and then changes location of ship
            switch (choice)
            {

                case 1: //Earth
                    {
                        if (earth.name == ship.CheckLocation())
                        {
                            goto case -2;
                        }
                        ship.CheckDistanceTo(earth);
                        ship.TravelTo(earth);
                        break;
                    }
                case 2: //Jupiter
                    {
                        if (jupiter.name == ship.CheckLocation())
                        {
                            goto case -2;
                        }
                        ship.CheckDistanceTo(jupiter);
                        ship.TravelTo(jupiter);
                        break;
                    }
                case 3: //Alpha
                    {
                        if (ship.level != 3)
                        {
                            goto case -3;
                        }
                        if (alpha.name == ship.CheckLocation())
                        {
                            goto case -2;
                        }
                        ship.CheckDistanceTo(alpha);
                        ship.TravelTo(alpha);
                        break;
                    }
                case 4: //Unknown
                    {
                        if (ship.level != 3)
                        {
                            goto case -3;
                        }
                        if (unknown.name == ship.CheckLocation())
                        {
                            goto case -2;
                        }
                        ship.CheckDistanceTo(unknown);
                        ship.TravelTo(unknown);
                        break;
                    }
                case 5: //Tatooine
                    {
                        if (tatooine.name == ship.CheckLocation())
                        {
                            goto case -2;
                        }
                        ship.CheckDistanceTo(tatooine);
                        ship.TravelTo(tatooine);
                        break;
                    }
                case 6: //Back to Choices
                    {
                        Choices();
                        break;
                    }
                case -2:
                    {
                        Console.WriteLine("\nYou are already on that Planet!!!");
                        Continue();
                        WhichPlanet();
                        break;
                    }
                case -3:
                    Console.WriteLine("You need a Warp Drive to go that far, upgrade ship to level 3!");
                    Continue();
                    break;
                default:
                    {
                        Console.WriteLine("\nThat planet has not been doscovered yet...");
                        Continue();
                        WhichPlanet();
                        break;
                    }
            }
        }//End WhichPlanet()

        //Displays all contents the user has as well as ship information
        public static void ShowInventory()

        {
            Console.Clear();
            Timer();
            int itemSum = hero.salt + hero.iron + hero.seeds + hero.hydrogen + hero.rareMetals + hero.darkMatter + hero.unobtanium;
            Console.WriteLine($"\n\tYou are on Planet {ship.CheckLocation()}");
            Console.WriteLine($"Your Age: {hero.age + gameTime} years old"); 
            Console.WriteLine($"\nItems that are in {hero.name}'s possession:");
            Console.WriteLine($"\nCredits: {hero.credits}");
            Console.WriteLine($"Salt:\t\t{hero.salt}");
            Console.WriteLine($"Iron:\t\t{hero.iron}");
            Console.WriteLine($"Seeds:\t\t{hero.seeds}");
            Console.WriteLine($"Hydrogen:\t{hero.hydrogen}");
            Console.WriteLine($"Rare Metals:\t{hero.rareMetals}");
            Console.WriteLine($"Dark Matter:\t{hero.darkMatter}");
            Console.WriteLine($"UnObtanium:\t{hero.unobtanium}");
            Console.WriteLine("\nShip Statistics:");
            Console.WriteLine($"Your ship level is Level {ship.level}");
            Console.WriteLine($"Your ship has {ship.fuel} units of fuel remaining");
            Console.WriteLine($"Your ship's capacity is currently {itemSum} / {ship.capacity}");
            Continue();
            Choices();
        }//End Show Inventory

        //Displays the Map
        public static void ViewMap()
        {
            Console.Clear();
            string[,] space = new string[15, 15];

            //Creates Array of the Galaxy with no Planets
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j ++)
                {
                    space[i, j] = ".";
                }
            }

            //Puts a Planet in Galaxy at planet location
            space[earth.planetX, earth.planetY] =       "0-" + earth.name;
            space[jupiter.planetX, jupiter.planetY] =   "0-" + jupiter.name;
            space[alpha.planetX, alpha.planetY] =       "0-" + alpha.name;
            space[unknown.planetX, unknown.planetY] =   "0-" + unknown.name;
            space[tatooine.planetX, tatooine.planetY] = "0-" + tatooine.name;

            Console.WriteLine("\n\t\tMAP of the MSSA Galaxy: \n\n");

            //Prints Galaxy to screen with proper spacing and Vertical Grid #'s
            Console.WriteLine("------------------------------------------------------------------");
            for (int i = 14; i >= 0; i--)
            {
                string mapLine = $"{i}".PadRight(2, ' ') + "|";
                for (int j = 0; j < 15; j++)
                {
                    mapLine += space[j, i] + "..";
                }
                Console.Write(mapLine.PadRight(65, '.'));
                Console.WriteLine("|");
   
            }

            //Prints Horizontal Grid
            Console.WriteLine("  |0 |1 |2 |3 |4 |5 |6 |7 |8 |9 |10|11|12|13|14|15|16|17|18|19|20|");
            Console.WriteLine("------------------------------------------------------------------");
            Console.Write("\t\tLEGEND: ");
            Console.WriteLine("SYMBOL '0' is the Planet Location");
            Console.Write("\nYou are currently on planet ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{ship.CheckLocation()}");
            Console.ResetColor();
            Continue();
            Choices();
        }
    }//End SpaceGame Class
}//End NameSpace

