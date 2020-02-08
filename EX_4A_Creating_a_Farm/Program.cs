using System;
using System.Collections.Generic;

namespace EX_4A_Creating_a_Farm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tEX_4A_Creating_A_Farm.Program.Main()\n");
            Farm.Welcome();
            Farm.Farewell();
        }
    }

    public class Farm
    {
        static int farmMoney = 500;
        static int costOfHorse = 80;
        static int costOfCow = 120;
        static int costOfChicken = 30;
        static int costOfPig = 60;
        static string animalsOnFarm = "";

        public static void Welcome()
        {
            Console.WriteLine("\tWelcome to Caleb's Farm!");
            Console.WriteLine("\nLooks like there are no animals here yet.....");
            Console.Write("\nWould you like to help get some animals? [Y/N]: ");
            string willHelp = Convert.ToString(Console.ReadLine().ToUpper());
            switch (willHelp)
            {
                case "Y":
                    PickAnimal();
                    break;
                case "N":
                    Console.WriteLine("\nOk, no problem...");
                    break;
                default:
                    Console.WriteLine("\nNot sure what you meant by that, I'll take it as a YES!");
                    Continue();
                    PickAnimal();
                    break;
            }
        }

        //common lines used in simple method
        public static void Continue()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        //ending method
        public static void Farewell()
        {
            Console.WriteLine("\nLooks like it's time for supper...");
            Console.WriteLine("Thanks for stopping by Caleb's Farm!");
            Continue();
            System.Environment.Exit(1);
        }

        //The buying and tracking of animals
        public static void PickAnimal()
        {
            Console.Clear();
            int animalChoice;
            Console.Write($"\nGreat! We have ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"${farmMoney}");
            Console.ResetColor();
            Console.WriteLine(" to spend on animals");
            if (farmMoney < costOfChicken)
                NotEnoughMoney();
            Console.WriteLine("\nHere is a list of the Animals and their cost:");
            Console.WriteLine("\n#\tAnimal\t\tCost");
            Console.WriteLine("---------------------------");
            Console.WriteLine($"1)\tHorse\t\t{costOfHorse}");
            Console.WriteLine($"2)\tCow\t\t{costOfCow}");
            Console.WriteLine($"3)\tChicken\t\t{costOfChicken}");
            Console.WriteLine($"4)\tPig\t\t{costOfPig}");
            Console.WriteLine("5)\tPlay with the animals");

            Console.WriteLine("\nHere is your current Farm:\n");
            Console.WriteLine("Animal\t\t# on Farm");
            Console.WriteLine("---------------------------");
            Console.WriteLine($"Horse\t\t{Horse.numOfHorses}");
            Console.WriteLine($"Cow\t\t{Cow.numOfCows}");
            Console.WriteLine($"Chicken\t\t{Chicken.numOfChickens}");
            Console.WriteLine($"Pig\t\t{Pig.numOfPigs}");
            Console.Write("\nWhat animal should we add to the farm? [1-5]: ");
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
                        if ((farmMoney - costOfHorse) < 0)
                        {
                            NotEnoughMoney();
                        }
                        farmMoney -= costOfHorse;
                        Horse mrEd = new Horse();
                        animalsOnFarm += "1";
                        //BuyOrPlay();
                        break;
                    }
                case 2: //Cow
                    {
                        if ((farmMoney - costOfCow) < 0)
                        {
                            NotEnoughMoney();
                        }
                        farmMoney -= costOfCow;
                        Cow hershey = new Cow();
                        animalsOnFarm += "2";
                       // BuyOrPlay();
                        break;
                    }
                case 3: //Chicken
                    {
                        if ((farmMoney - costOfChicken) < 0)
                        {
                            NotEnoughMoney();
                        }
                        farmMoney -= costOfChicken;
                        Chicken rooster = new Chicken(); 
                        animalsOnFarm += "3";
                        //BuyOrPlay();
                        break;
                    }
                case 4: //Pig
                    {
                        if ((farmMoney - costOfPig) < 0)
                        {
                            NotEnoughMoney();
                        }
                        farmMoney -= costOfPig;
                        Pig porkey = new Pig();
                        animalsOnFarm += "4";
                        //BuyOrPlay();

                        break;
                    }
                case 5: //Makes sure there is at least 1 animal bought
                    {
                        if (Horse.numOfHorses + Cow.numOfCows + Pig.numOfPigs + Chicken.numOfChickens ==0)
                        {
                            Console.WriteLine("\nYou need to buy at least one animal first!");
                            Continue();
                            PickAnimal();
                        }
                        TimeToPlay();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("\nThat type of animal is not for sale yet");
                        Continue();
                        //PickAnimal();
                        break;
                    }
            }
            PickAnimal();
        }

        //checks to see if there is money to buy more animals or not
        public static void NotEnoughMoney()
        {
            if (farmMoney < costOfChicken)
            {
                Console.WriteLine("We don't have enough money to buy any more animals!");
                Console.WriteLine("Time to play with animals on Caleb's Farm");
                Continue();
                TimeToPlay();
            }
            else
            {
                Console.WriteLine($"${farmMoney} is not enough to buy that animal, let's pick another.");
                Continue();
                PickAnimal();
            }
        }

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
            switch (10*animalNum + actionNum)
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
    }

    //Horse class and methods
    public class Horse
    {
        public static int numOfHorses = 0;
        string name;
        int age;

        public Horse()
        {
            name = "No-Name-Horse";
            age = 0;
            numOfHorses++;
        }

        public Horse(string name)
        {
            this.name = name;
        }

        public void Speak()
        {
            Console.WriteLine($"Horses make a neigh noise! {this.name} says Hello!");
        }

        public void walk()
        {
            Console.WriteLine($"Yeah, 'bout time you took {this.name} for a walk");
        }

        public void eat()
        {
            Console.WriteLine($"{this.name} says thanks for the grub!");
        }

        public void sleep()
        {
            Console.WriteLine($"ZzZzZzz...shhhhh, {this.name} is sleeping now");
        }
    }

    //Pig Class and methods
    public class Pig
    {
        public static int numOfPigs = 0;
        string name;
        int age;

        public Pig()
        {
            name = "No-Named-Pig";
            age = 0;
            numOfPigs++;
        }

        public Pig(string name)
        {
            this.name = name;
        }

        public void Speak()
        {
            Console.WriteLine($"Your pig {this.name} said Oink-oink.");
        }

        public void walk()
        {
            Console.WriteLine($"{this.name} doesn't go very fast.");
        }

        public void eat()
        {
            Console.WriteLine($"{this.name} will eat anything!");
        }

        public void sleep()
        {
            Console.WriteLine($"{this.name} snorts while they sleep.");
        }

        public void Bacon()
        {
            Console.WriteLine($"{this.name} is not happy about this, but understands the temptation.");
        }
    }

    //Chicken Class and methods
    public class Chicken
    {
        public static int numOfChickens = 0;
        string name;
        int age;

        public Chicken()
        {
            name = "No-Name-Chicken";
            age = 0;
            numOfChickens++;
        }

        public Chicken(string name)
        {
            this.name = name;
        }

        public void Speak()
        {
            Console.WriteLine($"{this.name} clucks rather early in the day.");
        }

        public void walk()
        {
            Console.WriteLine($"{this.name} likes to fly to get around more than walk.");
        }

        public void eat()
        {
            Console.WriteLine($"{this.name} says thanks for the chicken seed!");
        }

        public void sleep()
        {
            Console.WriteLine($"Night night {this.name}");
        }
    }

    //Cow Class and methods
    public class Cow
    {
        public static int numOfCows = 0;
        string name;
        int age;

        public Cow()
        {
            name = "No-Name-Cow";
            age = 0;
            numOfCows++;
        }

        public Cow(string name)
        {
            this.name = name;
        }

        public void Speak()
        {
            Console.WriteLine($"{this.name} says moo");
        }

        public void walk()
        {
            Console.WriteLine($"{this.name} says moo more walking!");
        }

        public void eat()
        {
            Console.WriteLine($"{this.name} says moo food!");
        }

        public void sleep()
        {
            Console.WriteLine($"{this.name} jumped over the moooon!");
        }
    }
}

