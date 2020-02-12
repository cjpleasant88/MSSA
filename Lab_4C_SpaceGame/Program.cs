using System;
using System.Threading;

namespace Lab_4C_SpaceGame
{
    class Program
    {
        static void Main(string[] args)
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
            SpaceGame.Continue();
            Console.Clear();

            //Game Starts and to ask user for help
            SpaceGame.Welcome();

            //If User says no or timer runs out, game ends with FareWell()
            SpaceGame.Farewell();
        }
    }

    //Space Game class
    public class SpaceGame
    {
        //Gamer Variables
        static double timer = 100.00; //Maybe add difficulty level and decrease time to make harder?
        static double scavengeTime = .25;

        //player created
        static Player hero = new Player();

        //5 Planets created for game Planet(Name, X, Y, TradeConversion)
        static Planet earth = new Planet("Earth", 3, 1, 1);
        static Planet jupiter = new Planet("Jupiter", 1, 4, 1);
        static Planet alpha = new Planet("Alpha Cantauri B", 12, 2, 1);
        static Planet unknown = new Planet("Unknown", 11, 4, 1);
        static Planet tatooine = new Planet("Tatooine", 3, 15, 1);

        //User Ship created
        static Ship ship = new Ship();
        static Random random = new Random();
        static double travelTime = 1.0; //maybe decrease time when ship is upgraded?

        //Asks User if they want to play the game
        public static void Welcome()
        {
            ship.level = 1;
            Console.WriteLine("*****************************************************************************************");
            Console.WriteLine("*\t\t\tHURRY! Wake up! We need your help.....                          *");
            Console.WriteLine("*                                                                                       *");
            Console.WriteLine("*\tEarth has been invaded by aliens who have planted a Quantum Nuclear Bomb!       *");
            Console.WriteLine("*****************************************************************************************");
            Console.Write("\nCan you help us stop it!? [Y/N]: ");
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
        }

        //Commonly used code put into a method
        public static void Continue()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        //Bad Ending if  user says no to play or timer runs out
        public static void Farewell()
        {
            Console.WriteLine("\n100 Days have passed.");
            Console.WriteLine("The Quantum Nuclear Bomb destoyed earth and all human life on it....Thanks");
            Continue();
            System.Environment.Exit(1);
        }

        //StoryLine for Space Game
        public static void StoryLine()
        {
            Console.Clear();
            Console.WriteLine("\nGreat! So as you know, the Earth is in pending doom.");
            Console.Write("\nWe have ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("100");
            Console.ResetColor();
            Console.WriteLine(" days to stop the end of the world!");
            Console.Write("Professor W. White says that he can stop it if only he had some ...");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("UnObtanium");
            Console.ResetColor();
            Console.WriteLine("!");
            Continue();
            Console.WriteLine("\nLucky for you, he know that there is some UnObtanium on the Planet of Aplha Centauri B.");
            Console.WriteLine("Please go there and get 10 units of UnObtanium for the professor!");
            Continue();
            Console.WriteLine("\nHe gave you 50 credits and says you can take his ship, but it might need to be refueled....");
            Console.WriteLine("He came back from Tatooine late last night and did not stop for gas.");
            hero.credits += 50;
            Continue();
            Choices();
        }

        //The Generic Action Choices Method for any planet
        public static void Choices()
        {
            double scavengeCost = 0.25;
            int fuelCost = 12;
            
            Console.Clear();
            int choice;
            Console.WriteLine("\nWhat would you like to do?");
            Console.Write($"\nWe have ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{hero.credits}");
            Console.ResetColor();
            Console.Write(" credits to spend on supplies on ");

            //Checks which planet you are on and displays it for the above Console.WriteLine
            Console.WriteLine(CheckLocation());

            //Displays List of Actions
            Console.WriteLine("\nHere is a list of actions to take:");
            Console.WriteLine("\n#\tAction\t\t\tCost");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"1)\tScavenge\t\t{scavengeCost} days");
            Console.WriteLine($"2)\tBuy Fuel\t\t{fuelCost} credits");
            Console.WriteLine($"3)\tTravel\t\t\tFuel");
            Console.WriteLine($"4)\tUpgrade Ship\t\tvaries");
            Console.WriteLine("5)\tView Map\t\t0");
            Console.WriteLine("6)\tView Ship Contents\t0");

            //Gets User input for selection and makes sure it is an integer
            Console.Write("\nWhat action would you like to take? [1-6]: ");
            Console.WriteLine("");
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                choice = -1;
            }

            //Switch case for a particular action
            switch (choice)
            {
                case 1: //Scavenge
                    {
                        if (ship.shipX == earth.planetX && ship.shipY == earth.planetY)
                        {
                            ScavengeEarth();
                        }
                        if (ship.shipX == jupiter.planetX && ship.shipY == jupiter.planetY)
                        {
                            ScavengeJupiter();
                        }
                        if (ship.shipX == alpha.planetX && ship.shipY == alpha.planetY)
                        {
                            //ScavengeAlpha();
                            Console.WriteLine("// TODO: Write a ScavengeAlpha Method");
                        }
                        if (ship.shipX == unknown.planetX && ship.shipY == unknown.planetY)
                        {
                            //ScavengeUnknown();
                            Console.WriteLine("// TODO: Write a ScavengeUnknown Method");
                        }
                        if (ship.shipX == tatooine.planetX && ship.shipY == tatooine.planetY)
                        {
                            //ScavengeTatooine();
                            Console.WriteLine("// TODO: Write a ScavengeTatooine Method");
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
                        Console.WriteLine("// TODO: Write a View Map Method");
                        Continue();
                        break;
                    }
                case 6: //View Ship Contents
                    {
                        ShowInventory();
                        Continue();
                        break;
                    }
                case 99: //Easter Egg to give 100 credits to player
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
        }

        //Method that shows Ship level and available upgrades
        public static void Upgrade()
        {
            int choice;
            Console.Clear();
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
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                choice = -1;
            }
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
        }

        //Displays a rocket depending on Ship Level when traveling
        public static void Travel()
        {
            string rocket1 = @"
                                  /\
                                 (  )
                                 (  )
                                /|/\|\
                               /_||||_\";
            string rocket2 = @"        
                                    |
                                   / \
                                  / _ \
                                 |.o '.|
                                 |'._.'|
                                 |     |
                               ,'|  |  |`.
                              /  |  |  |  \
                              |,-'--|--'-.|";
            string rocket3 = @"
                                   !
                                   !
                                   ^
                                  / \
                                 /___\
                                |=   =|
                                |     |
                                |     |
                                |     |
                                |     |
                                |     |
                                |     |
                                |     |
                                |     |
                                |     |
                               /|##!##|\
                              / |##!##| \
                             /  |##!##|  \
                            |  / ^ | ^ \  |
                            | /  ( | )  \ |
                            |/   ( | )   \|
                                ((   ))
                               ((  :  ))
                               ((  :  ))
                                ((   ))
                                 (( ))
                                  ( )
                                   .
                                   .
                                   .";

            Console.Clear();
            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine("");
            }
            switch(ship.level)
            {
                case 1:
                    Console.WriteLine(rocket1);
                    break;
                case 2:
                    Console.WriteLine(rocket2);
                    break;
                case 3:
                    Console.WriteLine(rocket3);
                    break;
            }
            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine("");
                Thread.Sleep(120);
            }
            Console.WriteLine("The End");
            Continue();
        }

        //Display when buying and credits are not enough
        public static void NotEnoughCredits()
        {
                Console.WriteLine($"\n{hero.credits} is not enough to buy that, what now?.");
                Continue();
                Choices();
        }

        //Randomly gain items Earth Specific
        public static void ScavengeEarth()
        {
            Console.Clear();
            Console.WriteLine("\tYou went out for a few hours and....");
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
            timer -= scavengeTime;
            Continue();
            Choices();
        }

        //Randomly gain items Jupiter Specific
        public static void ScavengeJupiter()
        {
            Console.Clear();
            Console.WriteLine("\tYou went out for a few hours and....");
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
            timer -= scavengeTime;
            Continue();
            Choices();
        }

        //When travel action is selected, user gets asked which planet to travel to
        public static void WhichPlanet()
        {
            int choice;
            Console.Clear();

            //Determines which planet they are on
            Console.Write("\tYou are on Planet ");
            Console.WriteLine(CheckLocation());
            //if (ship.shipX == earth.planetX && ship.shipY == earth.planetY)
            //{
            //    Console.WriteLine($"{earth.name}!");
            //}
            //if (ship.shipX == jupiter.planetX && ship.shipY == jupiter.planetY)
            //{
            //    Console.WriteLine($"{jupiter.name}!");
            //}
            //if (ship.shipX == alpha.planetX && ship.shipY == alpha.planetY)
            //{
            //    Console.WriteLine($"{alpha.name}!");
            //}
            //if (ship.shipX == unknown.planetX && ship.shipY == unknown.planetY)
            //{
            //    Console.WriteLine($"{unknown.name}!");
            //}
            //if (ship.shipX == tatooine.planetX && ship.shipY == tatooine.planetY)
            //{
            //    Console.WriteLine($"{tatooine.name}!");
            //}

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
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                choice = -1;
            }

            //Makes sure user is not already on that planet and then changes location of ship
            switch (choice)
            {

                case 1: //Earth
                    {
                        if (earth.name == CheckLocation())
                        {
                            goto case -2;
                        }
                        ship.shipX = earth.planetX;
                        ship.shipY = earth.planetY;
                        Travel();
                        break;
                    }
                case 2: //Jupiter
                    {
                        if (jupiter.name == CheckLocation())
                        {
                            goto case -2;
                        }
                        ship.shipX = jupiter.planetX;
                        ship.shipY = jupiter.planetY;
                        Travel();
                        break;
                    }
                case 3: //Alpha
                    {
                        if (alpha.name == CheckLocation())
                        {
                            goto case -2;
                        }
                        ship.shipX = alpha.planetX;
                        ship.shipY = alpha.planetY;
                        Travel();
                        break;
                    }
                case 4: //Unknown
                    {
                        if (unknown.name == CheckLocation())
                        {
                            goto case -2;
                        }
                        ship.shipX = unknown.planetX;
                        ship.shipY = unknown.planetY;
                        Travel();
                        break;
                    }
                case 5: //Tatooine
                    {
                        if (tatooine.name == CheckLocation())
                        {
                            goto case -2;
                        }
                        ship.shipX = tatooine.planetX;
                        ship.shipY = tatooine.planetY;
                        Travel();
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
                default:
                    {
                        Console.WriteLine("\nThat planet has not been doscovered yet...");
                        Continue();
                        WhichPlanet();
                        break;
                    }
            }
        }

        //Returns a string with the planet that user is currently on
        public static string CheckLocation()
        {
            string onPlanet = "";
            if (ship.shipX == earth.planetX && ship.shipY == earth.planetY)
            {
            onPlanet += earth.name;
            }
            if (ship.shipX == jupiter.planetX && ship.shipY == jupiter.planetY)
            {
            onPlanet += jupiter.name;
            }
            if (ship.shipX == alpha.planetX && ship.shipY == alpha.planetY)
            {
            onPlanet += alpha.name;
            }
            if (ship.shipX == unknown.planetX && ship.shipY == unknown.planetY)
            {
            onPlanet += unknown.name;
            }
            if (ship.shipX == tatooine.planetX && ship.shipY == tatooine.planetY)
            {
            onPlanet += tatooine.name;
            }
            return onPlanet;
        }

        //Displays all contents the user has as well as ship information
        public static void ShowInventory()
        {
            Console.Clear();
            int itemSum = hero.salt + hero.iron + hero.seeds + hero.hydrogen + hero.rareMetals + hero.darkMatter + hero.unobtanium;
            Console.WriteLine($"\n\tYou are on Planet {CheckLocation()}");
            Console.WriteLine("\nHere is what you currently have in your possession:");
            Console.WriteLine($"\nCredits: {hero.credits}");
            Console.WriteLine($"Salt: {hero.salt}");
            Console.WriteLine($"Iron: {hero.iron}");
            Console.WriteLine($"Seeds: {hero.seeds}");
            Console.WriteLine($"Hydrogen: {hero.hydrogen}");
            Console.WriteLine($"Rare Metals: {hero.rareMetals}");
            Console.WriteLine($"Dark Matter: {hero.darkMatter}");
            Console.WriteLine($"UnObtanium: {hero.unobtanium}");
            Console.WriteLine("\nShip Statistics:");
            Console.WriteLine($"Your ship level is Level {ship.level}");
            Console.WriteLine($"Your ship has {ship.fuel} units of fuel remaining");
            Console.WriteLine($"Your ship's capacity is currently {itemSum} / {ship.capacity}");
            Continue();
            Choices();
        }
    }//End SpaceGame Class


        /*
    //Choosing of which animal to play with
    public static void TimeToPlay()
    {
        int animalChoice;
        Console.Clear();
        Console.WriteLine("\nRemember, Here is your current Farm:");
        Console.WriteLine("Animal\t\t# on Farm");
        Console.WriteLine("---------------------------");
        Console.WriteLine($"1) Horse\t{Horse.numOfHorses}");
        Console.WriteLine($"2) Cow\t\t{Cow.numOfCows}");
        Console.WriteLine($"3) Chicken\t{Chicken.numOfChickens}");
        Console.WriteLine($"4) Pig\t\t{Pig.numOfPigs}");
        Console.WriteLine("5) Buy more anmials");
        Console.Write("\nWhich animal would like to play with? [1-5]: ");
        try
        {
            animalChoice = Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception)
        {
            animalChoice = -1;
        }
        switch (animalChoice)
        {
            case 1: //Horse
                {
                    if (Horse.numOfHorses == 0)
                    {
                        Console.WriteLine("\nYou don't have any horses!");
                        Continue();
                        TimeToPlay();
                    }
                    Activity(1);
                    break;
                }
            case 2: //Cow
                {
                    if (Cow.numOfCows == 0)
                    {
                        Console.WriteLine("\nYou don't have any cows!");
                        Continue();
                        TimeToPlay();
                    }
                    Activity(2);
                    break;
                }
            case 3: //Chicken
                {
                    if (Chicken.numOfChickens == 0)
                    {
                        Console.WriteLine("\nYou don't have any chickens!");
                        Continue();
                        TimeToPlay();
                    }
                    Activity(3);
                    break;
                }
            case 4: //Pig
                {
                    if (Pig.numOfPigs == 0)
                    {
                        Console.WriteLine("\nYou don't have any pigs!");
                        Continue();
                        TimeToPlay();
                    }
                    Activity(4);
                    break;
                }
            case 5:
                PickAnimal();
                break;
            default:
                {
                    Console.WriteLine("\nWe don't have that kind of animal on this Farm??");
                    Continue();
                    TimeToPlay();
                    break;
                }
        }
        Console.WriteLine("That was Fun");
    }

    //Action selection for the animal chosen
    public static void Activity(int animalNum)
    {
        Horse mrEd = new Horse("Mr. Ed");
        Pig porky = new Pig("Porky");
        Chicken rooster = new Chicken("Mr. Clucks");
        Cow hershey = new Cow("Hershey");
        Console.Clear();
        int actionNum = 0;
        Console.WriteLine("\n#\tAction");
        Console.WriteLine("---------------");
        Console.WriteLine("1)\tSpeak");
        Console.WriteLine("2)\tWalk");
        Console.WriteLine("3)\tEat");
        Console.WriteLine("4)\tSleep");
        Console.WriteLine("5)\tBacon");
        Console.WriteLine("6)\tPick a different animal");
        Console.WriteLine("7)\tLeave the Farm");
        Console.Write("\nWhat would you like to do with your ");
        switch (animalNum)
        {
            case 1:
                Console.Write("Horse?");
                break;
            case 2:
                Console.Write("Cow?");
                break;
            case 3:
                Console.Write("Chicken?");
                break;
            case 4:
                Console.Write("Pig?");
                break;
            default:
                Console.WriteLine("That is not something the animals know how to do!?");
                Console.WriteLine("Lets make sure we have the right animal.");
                Continue();
                TimeToPlay();
                break;
        }
        Console.Write(" [1-7]: ");
        try
        {
            actionNum = Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception)
        {
            Console.WriteLine("\nThat is not something the animals know how to do!?");
            Console.WriteLine("Lets make sure we have the right animal.");
            Continue();
            TimeToPlay();
        }
        Console.WriteLine("");
        switch (10 * animalNum + actionNum)
        {
            //Horse cases
            case 11:
                mrEd.Speak();
                break;
            case 12:
                mrEd.walk();
                break;
            case 13:
                mrEd.eat();
                break;
            case 14:
                mrEd.sleep();
                break;
            case 15:
            case 25:
            case 35:
                Console.WriteLine("\nThis action is only for pigs...");
                break;
            //Cow Cases
            case 21:
                hershey.Speak();
                break;
            case 22:
                hershey.walk();
                break;
            case 23:
                hershey.eat();
                break;
            case 24:
                hershey.sleep();
                break;
            //Chicken cases
            case 31:
                rooster.Speak();
                break;
            case 32:
                rooster.walk();
                break;
            case 33:
                rooster.eat();
                break;
            case 34:
                rooster.sleep();
                break;
            //Pig Cases
            case 41:
                porky.Speak();
                break;
            case 42:
                porky.walk();
                break;
            case 43:
                porky.eat();
                break;
            case 44:
                porky.sleep();
                break;
            case 45:
                porky.Bacon();
                break;
            //Pick a different animal cases
            case 16:
            case 26:
            case 36:
            case 46:
                TimeToPlay();
                break;
            //Leave the Famr cases
            case 17:
            case 27:
            case 37:
            case 47:
                Farewell();
                break;
        }
        Continue();
        TimeToPlay();
    }
    */
    
    

    //Human Player Class
    public class Player
    {
        //Player attributes
        public int credits = 0;
        public string name = "No-Name";
        public int iron = 0;
        public int salt = 0;
        public int darkMatter = 0;
        public int rareMetals;
        public int unobtanium = 0;
        public int seeds = 0;
        public int hydrogen = 0;

        //Default Constructor
        public Player()
        {

        }
    }//End Player class

    public class Ship
    {
        //Ship attributes
        public string name = "No-Name";
        public int fuel = 10;
        public int shipX = 3;
        public int shipY = 1;
        public int level = 1;
        public int capacity = 40;

        //Default Constructor
        public Ship()
        {

        }
    }//End Ship Class

    public class Planet
    {
        //Planet attributes
        public string name;
        public double conversionRate;
        public int planetX;
        public int planetY;

        //Planet constructor
        public Planet(string name, int x, int y, double rate)
        {
            this.name =name;
            this.planetX = x;
            this.planetY = y;
            this.conversionRate = rate;
        }
    }//End Planet Class
}//End NameSpace

