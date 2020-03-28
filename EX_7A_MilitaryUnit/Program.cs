using System;

namespace EX_7A_MilitaryUnit
{
    class Program
    {
        //Creates instance of a MilitaryUnit
        static MilitaryUnit unit = new MilitaryUnit();

        //Initiates variables to keep track of personnel to create
        private static int officerNumber;
        private static int enlistedNumber;
        private static int recruitNumber;

        public static void Main(string[] args)
        {
            //Assigns all values in the usedNames array all to -1
            for (int i = 0; i < unit.nameCount; i++)
            {
                unit.usedNames[i] = -1;
            }

            Console.WriteLine("\n\tEX_7A_MilitaryUnit.Program.Main()\n");

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

        //Used to assign Disctinct Names for anything from the Person class
        public static string GetName()
        {
            bool notUsed;
            string name;
            int enumName;

            //Gets a name from the enum list
            //if (int)name is in the usedNames array, randomly gets another name fro enum list
            do
            {
                notUsed = true;
                enumName = unit.random.Next(unit.nameCount);
                name = ((Names)(enumName)).ToString();
                for (int i = 0; i < unit.namePlace; i++)
                {
                    if (unit.usedNames[i] == enumName)
                    {
                        notUsed = false;
                    }
                }
            } while (notUsed == false);

            //adds the new name to the used Names array
            unit.usedNames[unit.namePlace] = enumName;

            //increases the namePlace to track the next index to store a name
            unit.namePlace++;

            //returns the name
            return name;
        }
    }//End Program Class
}
