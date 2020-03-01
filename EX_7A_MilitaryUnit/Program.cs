using System;

namespace EX_7A_MilitaryUnit
{
    class Program
    {
        //initiates random variable
        public static Random random = new Random();

        //calculates the total number of names in the enumeration for future random number calculations
        public static int nameCount = Enum.GetNames(typeof(Names)).Length;

        //Declares an array of the same length as the Names enumeration
        public static int[] usedNames = new int[nameCount];

        //keeps track of how many names have been given out
        public static int namePlace = 0;

        public static void Main(string[] args)
        {
            //Assigns all values in the usedNames array all to -1
            for (int i = 0; i < nameCount; i++)
            {
                usedNames[i] = -1;
            }

            Console.WriteLine("\n\tEX_7A_MilitaryUnit.Program.Main()\n");

            //Initiates variables to keep track of personnel to create
            int officerNumber;
            int enlistedNumber;
            int recruitNumber;


            Console.WriteLine("\nWelcome to Camp MSSA");
            Console.WriteLine("\nOur mission is to go from Point A to Point B in whatever mode of \ntransportation you have and fight a band of enemy resistance.");
            Console.WriteLine("We will need Officers, Enlisted members, Recruits.");

            //Ask user for # of Officers
            Console.Write("\nHow many Officers do we need? [1-6]: ");
            try
            {
                officerNumber = int.Parse(Console.ReadLine());
                if (officerNumber <= 0)
                {
                    Console.WriteLine("We need at least 1");
                    officerNumber = 1;
                }
                if (officerNumber > 6)
                {
                    Console.WriteLine("That seems high, let's use 2");
                    officerNumber = 2;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("That is not a valid number, lets use 2...(We don't need too many Officers)");
                officerNumber = 2;
            }

            //Ask user for # of Enlisted members
            Console.Write("\nHow many Enlisted do we need? [1-6]: ");
            try
            {
                enlistedNumber = int.Parse(Console.ReadLine());
                if (enlistedNumber <= 0)
                {
                    Console.WriteLine("We need at least 1");
                    enlistedNumber = 1;
                }
                if (enlistedNumber > 6)
                {
                    Console.WriteLine("That seems high, let's use 4");
                    enlistedNumber = 4;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("That is not a valid number, lets use 5...(Just enough to make it interesting)");
                enlistedNumber = 5;
            }

            //Ask user for # of Recruits
            Console.Write("\nHow many Recruits do we need? [1-6]: ");
            try
            {
                recruitNumber = int.Parse(Console.ReadLine());
                if (recruitNumber <= 0)
                {
                    Console.WriteLine("We need at least 1");
                    recruitNumber = 1;
                }
                if (recruitNumber > 6)
                {
                    Console.WriteLine("That seems high, let's use 3");
                    recruitNumber = 3;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("That is not a valid number, lets use 3...");
                recruitNumber = 3;
            }

            //Creates arrays of the same number of objects the user requested
            Officer[] officers = new Officer[officerNumber];
            Enlisted[] enlisted = new Enlisted[enlistedNumber];
            Person[] recruits = new Person[recruitNumber];

            //Creates Officer Objects (Derived) and stores them in an array
            for (int i = 0; i < officerNumber; i++)
            {
                officers[i] = new Officer();
                officers[i].name = GetName();
            }

            //Creates Enlisted Objects (Derived) and stores them in an array
            for (int i = 0; i < enlistedNumber; i++)
            {
                enlisted[i] = new Enlisted();
                enlisted[i].name = GetName();
                //name++;
            }

            //Creates Recruit Objects (Base) and stores them in an array
            for (int i = 0; i < recruitNumber; i++)
            {
                recruits[i] = new Person();
                recruits[i].name = GetName();
                //name++;
            }

            Console.WriteLine("");
            Console.WriteLine("Let's Go!");
            Console.WriteLine("");
            Continue();
            Console.Clear();
            Console.WriteLine("Here is how the unit traveled to Point B:");

            Console.WriteLine("");

            for (int i = 0; i < officerNumber; i++)
            {
                officers[i].Travel();
            }

            Console.WriteLine($"Yes the Officers travel by {officers[0].myVehicle.name}!");

            Console.WriteLine("");
            for (int i = 0; i < enlistedNumber; i++)
            {
                enlisted[i].Travel();
            }

            Console.WriteLine($"The enlisted move by {enlisted[0].myVehicle.name}!");

            Console.WriteLine("");
            for (int i = 0; i < recruitNumber; i++)
            {
                recruits[i].Travel();
            }

            Console.WriteLine($"And of course the recruits bring up the rear in the {recruits[0].myVehicle.name}");

            Continue();
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("\tThe Unit arrived at Point B and these are the weapons that were brought:");
            Console.WriteLine($"\nOfficers brought {officerNumber} {officers[0].myWeapon.name}'s");
            Console.WriteLine($"Enlisted brought {enlistedNumber} {enlisted[0].myWeapon.name}'s");
            Console.WriteLine($"Recruits brought {recruitNumber} {recruits[0].myWeapon.name}");
            Continue();
            Console.WriteLine("\nWith all of this Firepower, you overwhelmed the enemy and took control of Point B.");
            Continue();
            Console.WriteLine("\nYou are celebrated for you victory upon your arrival back home!");

        }//End Main

        public static void Continue()
        {
            Console.WriteLine("\nPress any key to continue....");
            Console.ReadKey();
        }

        public static string GetName()
        {
            bool notUsed;
            string name;
            int enumName;
            do
            {
                notUsed = true;
                enumName = random.Next(nameCount);
                name = ((Names)(enumName)).ToString();
                for (int i = 0; i < namePlace; i++)
                {
                    if (usedNames[i] == enumName)
                    {
                        notUsed = false;
                    }
                }
            } while (notUsed == false);
            usedNames[namePlace] = enumName;
            namePlace++;
            return name;
        }
    }//End Program Class

    public enum Names { Danny, Anthony, Caleb, Chris_O, Jeremy, Brandon, Oscar, Sheufella, Richard, Rodrigo, Jonesy, Josh, Wei, Chris_S, Cameron, Phillip, Zach, Elijah, Marco, Lien }

    //Vehicle Related Classes
    public class Vehicle
    {
        public int fuel;
        public int travelCost;
        public string name;

        //*************Vehicle Related Classes*****************

        //Default Constructor for Base class Vehicle
        public Vehicle()
        {
            name = "Safety-Vic";
            fuel = 100;
            travelCost = 3;
        }

        public void DisplayFuel()
        {
            Console.WriteLine($"\tYou have {this.fuel} units of fuel remaining.");
        }
    }

    //Tank Class derived from Vehicle Class
    public class Tank : Vehicle
    {
        public Tank() : base()
        {
            name = "AAV";
            travelCost = 10;
        }
    }

    //Helicopter Class from Base Class Vehicle
    public class Helicopter : Vehicle
    {
        public Helicopter() : base()
        {
            name = "Osprey";
            travelCost = 15;
        }
    }

    //*************Weapon Related Classes*****************

    //Weapon Base Class
    public class Weapon
    {
        public string name;

        public Weapon()
        {
            this.name = "Knife Hands";
        }
    
        public virtual void Reload()
        {
            Console.WriteLine("You reloaded the weapon");
        }
    }

    //Sword class derived from Weapon Class
    public class Sword : Weapon
    {
        public Sword() : base()
        {
            this.name = "Mameluke Sword";
        }
    }

    //KnifeHands Calss derived from Weapon Class
    public class KnifeHands : Weapon
    {
        public KnifeHands() : base()
        {
            this.name = "Rifle";
        }
    }

    //*************Person Related Classes*****************

    //Base Class Person
    public class Person
    {
        public string name;
        public Vehicle myVehicle;
        public Weapon myWeapon;

        //Generic Person
        public Person()
        {
            this.name = "Recruit";
            this.myVehicle = new Vehicle();
            this.myWeapon = new Weapon();
        }

        public virtual void Travel()
        {
            Console.WriteLine($"Recruit {this.name} traveled from A to B slowly.");
            this.myVehicle.fuel -= this.myVehicle.travelCost;
            //this.myVehicle.DisplayFuel();
        }
    }

    //Officer from Base Class Person
    public class Officer : Person
    {
        public Officer() : base()
        {
            this.name = "Sir";
            this.myVehicle = new Helicopter();
            this.myWeapon = new Sword();
        }

        public override void Travel()
        {
            Console.WriteLine($"Officer {this.name} flew from A to B.");
            this.myVehicle.fuel -= this.myVehicle.travelCost;
            //this.myVehicle.DisplayFuel();
        }
    }

    //Enlisted from Base Class Person
    public class Enlisted : Person
    {
        public Enlisted() : base()
        {
            this.name = "Grunt";
            this.myVehicle = new Tank();
            this.myWeapon = new KnifeHands();
        }

        public override void Travel()
        {
            Console.WriteLine($"Enlisted member {this.name} rolled in a tank from A to B, destroying 3 cars in their path.");
            this.myVehicle.fuel -= this.myVehicle.travelCost;
            //this.myVehicle.DisplayFuel();
        }
    }
}
