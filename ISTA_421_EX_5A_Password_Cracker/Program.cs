using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ISTA_421_EX_5A_Password_Cracker
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\n\tISTA_421_EX_5A_Password_Cracker.Program.Main()");

            ////Un-Comment this block to print ASCII Table of printable characters
            //Console.WriteLine("Printable characters:");
            //Console.WriteLine("INT\tCHARACTER");
            //for (int i = 32; i < 127; i++)
            //{
            //    Console.WriteLine($"{i}\t{(char)i}");
            //}

            //Get User Password to Crack
            string userPassword = GetUserPassword();
            Console.WriteLine("\nThanks, I'll get to cracking this and I'll let you know how long it takes.");

            //Creates a stop watch instance
            var watch = new System.Diagnostics.Stopwatch();

            //Starts timer, executes cracking of password and stops timer
            watch.Start();
            string foundPassword = CrackUserPassword(userPassword);
            watch.Stop();

            //displays the time it took to crack the password to the user
            Console.WriteLine($"\nExecution time for cracking: {watch.ElapsedMilliseconds} ms");
            Console.Write("\n\tYour password was ---->[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{foundPassword}");
            Console.ResetColor();
            Console.WriteLine("]<----");





            StringBuilder asyncAnswer = new StringBuilder("          ");


            //Task task0 = new Task(() =>{asyncAnswer[0] = (char)MatchIndex(0, userPassword);});
            //task0.Start();
            //Task task1 = new Task(() => { asyncAnswer[1] = (char)MatchIndex(1, userPassword); });
            //task1.Start();
            //Task task2 = new Task(() => { asyncAnswer[2] = (char)MatchIndex(2, userPassword); });
            //task1.Start();
            //Task task3 = new Task(() => { asyncAnswer[3] = (char)MatchIndex(3, userPassword); });
            //task1.Start();
            //Task task4 = new Task(() => { asyncAnswer[4] = (char)MatchIndex(4, userPassword); });
            //task1.Start();
            //Task task5 = new Task(() => { asyncAnswer[5] = (char)MatchIndex(5, userPassword); });
            //task1.Start();
            //Task task6 = new Task(() => { asyncAnswer[6] = (char)MatchIndex(6, userPassword); });
            //task1.Start();
            //Task task7 = new Task(() => { asyncAnswer[7] = (char)MatchIndex(7, userPassword); });
            //task1.Start();
            //Task task8 = new Task(() => { asyncAnswer[8] = (char)MatchIndex(8, userPassword); });
            //task1.Start();
            //Task task9 = new Task(() => { asyncAnswer[9] = (char)MatchIndex(9, userPassword); });
            //task1.Start();


            //watch.Start();
            //Thread thread0 = new Thread(() => { asyncAnswer[0] = (char)MatchIndex(0, userPassword); });
            //Thread thread1 = new Thread(() => { asyncAnswer[1] = (char)MatchIndex(1, userPassword); });
            //Thread thread2 = new Thread(() => { asyncAnswer[2] = (char)MatchIndex(2, userPassword); });
            //Thread thread3 = new Thread(() => { asyncAnswer[3] = (char)MatchIndex(3, userPassword); });
            //Thread thread4 = new Thread(() => { asyncAnswer[4] = (char)MatchIndex(4, userPassword); });
            //Thread thread5 = new Thread(() => { asyncAnswer[5] = (char)MatchIndex(5, userPassword); });
            //Thread thread6 = new Thread(() => { asyncAnswer[6] = (char)MatchIndex(6, userPassword); });
            //Thread thread7 = new Thread(() => { asyncAnswer[7] = (char)MatchIndex(7, userPassword); });
            //Thread thread8 = new Thread(() => { asyncAnswer[8] = (char)MatchIndex(8, userPassword); });
            //Thread thread9 = new Thread(() => { asyncAnswer[9] = (char)MatchIndex(9, userPassword); });
            //thread0.Start();
            //thread1.Start();
            //thread2.Start();
            //thread3.Start();
            //thread4.Start();
            //thread5.Start();
            //thread6.Start();
            //thread7.Start();
            //thread8.Start();
            //thread9.Start();
            //thread0.Join();
            //thread1.Join();
            //thread2.Join();
            //thread3.Join();
            //thread4.Join();
            //thread5.Join();
            //thread6.Join();
            //thread7.Join();
            //thread8.Join();
            //thread9.Join();
            //watch.Stop();
            //Console.WriteLine($"\nExecution time for cracking: {watch.ElapsedMilliseconds} ms");


            //watch.Start();
            //for (int i = 0; i<userPassword.Length; i++)
            //{
            //    asyncAnswer[i] = (char)MatchIndex(i, userPassword);
            //}
            //watch.Stop();
            //Console.WriteLine($"\nExecution time for cracking: {watch.ElapsedMilliseconds} ms");

            //Console.WriteLine(asyncAnswer.ToString());

            
            //string found1="";
            //Thread PasswordCracker1 = new Thread(() => { found1 = CrackUserPassword(userPassword, 1); });
            //PasswordCracker1.Start();
  
            //Testing of how StringBuilder works
            //string test = string.Empty;
            //StringBuilder sb = new StringBuilder("", 10);
            //sb.Append(" ");
            //Console.Write(sb.ToString());
            //Console.WriteLine(test);
            //bool equals;
            //if (test == sb.ToString())
            //{
            //    equals = true;
            //}
            //else
            //{
            //    equals = false;
            //}
            //Console.WriteLine(equals);
            //Console.WriteLine($"sb = -->{sb.ToString()}<--");

            //Console.WriteLine(sb[0]);
        }

        public static string GetUserPassword()
        {
            Console.Write("\nPlease enter a password you would like me to crack: ");
            string userPassword = Console.ReadLine();
            return userPassword;
        }

        //public static string CrackUserPassword(string userPassword, StringBuilder crackedPassword)
        public static string CrackUserPassword(string userPassword)
        {
            //Creates an empty Stringbuilder as a starting point to store the cracked password that is up to 10 characters
            //Strings are readonly and this algorithm requires the ability to constantly write a new character at a specific index
            StringBuilder crackedPassword = new StringBuilder("", 10);

            //Will store the final found password
            string actualPassword;

            //If the password is empty, returns immediately
            if (crackedPassword.ToString() == userPassword)
            {
                return crackedPassword.ToString();
            }

            //Loops through passwords at different lengths initially starting at 1
            for (int pwLength = 1; ; pwLength++)
            {
                //add one more character possibility to the password
                    crackedPassword.Append(" ");

                //Passes the password to match, the cracked password progress so far, current length of password to try and find, and the starting index of 0
                actualPassword = Cracker(userPassword, crackedPassword, pwLength, 0);

                //if password was found in the current iteration, break out out of the loop
                if (actualPassword == userPassword)
                {
                    break;
                }
            }

            return actualPassword;
        }

        public static string Cracker(string userPassword, StringBuilder sb, int pwLength, int index)
        {
            //32-126 is the integer ASCII values for printable characters from http://www.asciitable.com/
            //32 = 'Space' and 126 = '~' 
            for (int i = ' '; i <= '~'; i++)
            {
                //Assigns the starting index the current ASCII character
                sb[index] = (char)i;
                if (pwLength > 1)
                {
                    //Recusively calls itself causing an increased number of nested loops proportionate to the number of characters in the password

                        Cracker(userPassword, sb, pwLength - 1, index + 1);
                }
                
                //returns the password if found
                if (userPassword == sb.ToString())
                {
                    return sb.ToString();
                }
            }
            //if not found with current character number, returns empty string so the character number can be increased in the loop of the CrackUserPassword Method
            return "";
        }

        public static int MatchIndex(int index, string pw)
        {
            for (int i = ' '; i <= '~'; i++)
            {
                if (i == pw[index])
                {
                    return i;
                }
            }
            return (int)' ';
        }
    }
}
