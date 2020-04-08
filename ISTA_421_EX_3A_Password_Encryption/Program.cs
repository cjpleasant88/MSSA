using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ISTA_421_EX_3A_Password_Encryption
{
    class Program
    {
        //Creates a dictionary to store usernames and ensrypted passwords
        public static Dictionary<string, string> accounts = new Dictionary<string, string>();
        public static int numOfAccounts = 0;


        static void Main(string[] args)
        {

            Console.WriteLine("\n\tISTA_421_EX_3A_Password_Encryption.Program.Main()");

            int choice;
            do
            {
                Welcome();
                //Keeps asking until a valid input is received
                do
                {
                    Console.Write("\n\tEnter Selection: ");

                    //Gets user input on which choice they selected and validates it
                    choice = CheckChoice(3);
                } while (choice == -1);

                switch (choice)
                {
                    case 1:
                        EstablishAccount();
                        break;
                    case 2:
                        if(AuthenticateUser())
                        {
                            Console.WriteLine("You're in!");
                        }
                        else
                        {
                            Console.WriteLine("[ACCESS DENIED] Invalid Credentials");
                        }
                        Continue();
                        break;
                    case 3:
                        break;
                }
            } while (choice != 3);

            SystemExit();
        }

        public static void SystemExit()
        {
            Console.WriteLine();
            Console.WriteLine("EXITING SYSTEM and DUMPING DATA");

            //Displays all information stored in the system
            Console.WriteLine("\nDatabase DID contain:");
            Console.WriteLine("USERNAME\tENCRYPTED-PASSWORD");
            Console.WriteLine("-------------------------------");
            foreach (var element in accounts)
            {
                Console.WriteLine($"{element.Key}\t{element.Value}");
            }

            //Clears the store usernames and encrypted passwords
            accounts.Clear();

            //Gives user confirmation of System data dump
            Console.WriteLine("\n**All accounts in the system have been removed**");

            //Displays all information stored in the system
            Console.WriteLine();
            Console.WriteLine("Database Now contains:");
            Console.WriteLine("USERNAME\tENCRYPTED-PASSWORD");
            Console.WriteLine("-------------------------------");
            foreach (var element in accounts)
            {
                Console.WriteLine($"{element.Key}\t{element.Value}");
            }

            //Exits the system
            Console.WriteLine("\nSYSTEM SHUTDOWN");
            System.Environment.Exit(1);
        }

        public static void EstablishAccount()
        {
            Console.Clear();
            string username;
            string password;

                do
                {
                    Console.Write("Please enter the User Name you would like to use: ");

                    username = Console.ReadLine();
                    if (String.IsNullOrEmpty(username))
                    {
                        Console.WriteLine("[INVALID] Username must not be empty");
                        username = "";
                    }
                    foreach (KeyValuePair<string, string> account in accounts)
                    {
                        if (account.Key == username)
                        {
                            Console.WriteLine("[INVALID] Username already exist, please use a different one.");
                        username = "";
                        }
                    }

                } while (username.Equals(""));

                do
                {
                    Console.Write("Please enter the password you would like to use: ");

                    password = Console.ReadLine();
                    if (String.IsNullOrEmpty(password))
                    {
                        Console.WriteLine("[INVALID] password must not be empty");
                        password = "";
                    }
                } while (password.Equals(""));

            accounts[username] = Encrypt(password);
            numOfAccounts++;
            Console.WriteLine("Welcome to the Club!");
            Continue();
        }

        public static void Continue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public static bool AuthenticateUser()
        {
            string username;
            string password;
            Console.Clear();
            do
            {
                Console.Write("Please enter the User Name of your account: ");

                username = Console.ReadLine();
                if (String.IsNullOrEmpty(username))
                {
                    Console.WriteLine("[INVALID] Username must not be empty");
                    username = "";
                }

            } while (username.Equals(""));

            Console.Write("Please enter the password of your account: ");
            password = Console.ReadLine();

            //checks to make sure username exists and encrypted passwords match
            foreach (KeyValuePair<string, string> account in accounts)
            {
                if (account.Key == username)
                {
                    if (account.Value.Equals(Encrypt(password)))
                    {
                        //If username and encrpted passwords are equal
                        return true;
                    }
                }
            }
            return false;
        }

        //Displays the operations the system can do
        public static void Welcome()
        {
            if (numOfAccounts > 0)
            {
                Console.Clear();
            }
            Console.WriteLine("--------------------------------------------------------------------\n");
            Console.WriteLine("\tPASSWORD AUTHENTICATION SYSTEM\n");
            Console.WriteLine("\tPlease select one option:");
            Console.WriteLine("\t1. Establish an account");
            Console.WriteLine("\t2. Authenticate a user");
            Console.WriteLine("\t3. Exit the System\n");
            Console.WriteLine("\n--------------------------------------------------------------------");

            Console.WriteLine($"\nCurrent Accounts in System: {numOfAccounts}");
        }

        //Encrypting Method -> Not all Hashes are the same length and are Decimal Hashes
        //This is not used by the Program
        public static string Encrypt2(string input)
        {
            byte[] inputEncrypted;
            string result = "";

            using (MD5 algo = MD5.Create())
            {
                UnicodeEncoding convert = new UnicodeEncoding();
                byte[] inputBytes = convert.GetBytes(input);
                inputEncrypted = algo.ComputeHash(inputBytes);
            }
            foreach(var element in inputEncrypted)
            {
                result += element;
            }
            return result;
        }

        //This is the Encrypting Method used by the Program
        // from https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.md5?view=netframework-4.8
        //Computes a hexadecimal Hash using MD5
        public static string Encrypt(string input)
        {
            StringBuilder sBuilder = new StringBuilder();
            using (MD5 algo = MD5.Create())
            {
                byte[] data = algo.ComputeHash(Encoding.UTF8.GetBytes(input));
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
            }
                return sBuilder.ToString();
        }

        //Retrieves and validates user input for requested number of integer choices
        public static int CheckChoice(int choices)
        {
            int choice = -1;
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                choice = -1;
            }
            if (choice < 1 || choice > choices)
            {
                choice = -1;
                Console.WriteLine("[INVALID] That is not one of the choices");
            }
            return choice;
        }
    }
}
