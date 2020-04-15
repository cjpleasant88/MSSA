using System;

namespace ISTA_421_EX_4A_Encrypting_Decrypting_Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\tISTA_421_EX_4A_Encrypting_Decrypting_Messages.Program.Main()\n");

            string plaintext = Util.GetPlainText();
            string singlekey = Util.GetSingleKey();
            string multikey = Util.GetMultiKey();
            Console.WriteLine();

            Console.WriteLine($"You entered[{plaintext}] as plaintext");
            Console.WriteLine($"You entered [{singlekey}] as your singlekey");
            Console.WriteLine($"You entered [{multikey}] as your multikey");
            Console.WriteLine();

            int[] cleantext = Util.Clean(plaintext);
            int[] cleanskey = Util.Clean(singlekey);
            int[] cleanmkey = Util.Clean(multikey);

            string encsingle = Util.SingleEnc(cleantext, cleanskey);
            string encmulti = Util.MultiEnc(cleantext, cleanmkey);
            string encconti = Util.ContiEnc(cleantext, cleanmkey);

            Console.WriteLine($"Encrypted message with singlekey is [{encsingle}]");
            Console.WriteLine($"Encrypted message with multikey is [{encmulti}]");
            Console.WriteLine($"Encrypted message with continuous key is [{encconti}]");
            Console.WriteLine();

            string decsingle = Util.SingleDec(encsingle, cleanskey);
            string decmulti = Util.MultiDec(encmulti, cleanmkey);
            string decconti = Util.ContiDec(encconti, cleanmkey);

            Console.WriteLine($"Decrypted message with singlekey is [{decsingle}]");
            Console.WriteLine($"Decrypted message with multikey is [{decmulti}]");
            Console.WriteLine($"Decrypted message with continuous key is [{decconti}]");
            Console.WriteLine();
        }
    }

    public class Util
    {
        //returns the int value of the character in the Alphabet [A-Z] => [1-26]
        public static int GetPosition(int character) => character - 'A' + 1;

        //Loops through the alphabet if character is out of range of ASCII alpha characters
        public static void GetInRange(ref int character)
        {
            while (character < 'A')
            {
                character += 26;
            }
            while (character > 'Z')
            {
                character -= 26;
            }
        }

        //Retrieves the message to send from the user
        public static string GetPlainText()
        {
            Console.Write("Enter plain text: ");
            string input = Console.ReadLine();
            return input;
        }

        //Retrieves single key from user and verifies that it is a single alpha character
        public static string GetSingleKey()
        {
            string userInput;
            do
            {
                Console.Write("Enter your single key as an alpha character: ");
                userInput = Console.ReadLine();
                string input = userInput.ToUpper();
                if (input[0] < 'A' || input[0] > 'Z' || input.Length > 1)
                {
                    Console.WriteLine("[INVALID] Please enter a single alpha character [A-Z]");
                    userInput = "-1";
                }
            } while (userInput.Equals("-1"));
            return userInput;
        }

        //Retrieves multikey from user
        public static string GetMultiKey()
        {
            Console.Write("Enter your multi key as alpha characters: ");
            string input = Console.ReadLine();
            return input;
        }

        //Method takes all non alpha characters out, converts to uppercase, and
        //converts to the ASCII value stored in an array to match key types in Main Method
        public static int[] Clean(string input)
        {
            input = input.ToUpper();
            string cleanedString = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] >= 'A' && input[i] <= 'Z')
                {
                    cleanedString += input[i];
                }
            }
            int[] result = new int[cleanedString.Length];

            for (int i = 0; i < cleanedString.Length; i++)
            {
                result[i] = cleanedString[i];
            }
            return result;
        }

        //************ENCRYPTION METHODS*********************

        public static string SingleEnc(int[] text, int[] singlekey)
        {
            int character;                      //Used for individual character storage and manipulation
            int textLength = text.Length;       //Holds the encrpted message length as it is used several times
            string result = "";                 //Stores the final unecrypted message

            for ( int i = 0; i < textLength; i++)
            {
                character = text[i] + GetPosition(singlekey[0]);
                GetInRange(ref character);
                result += (char)character;
            }
            return result;
        }
        public static string MultiEnc(int[] text, int[] multikey)
        {
            int character;                      //Used for individual character storage and manipulation
            int keyLength = multikey.Length;    //Holds the multikey length as it is used several times
            int textLength = text.Length;       //Holds the encrpted message length as it is used several times
            string result = "";                 //Stores the final unecrypted message

            for (int i = 0; i < textLength; i++)
            {
                //Using the multikey over and over to encrypt the message
                character = text[i] + GetPosition(multikey[i % keyLength]);
                GetInRange(ref character);
                result += (char)character;
            }
            return result;
        }
        public static string ContiEnc(int[] text, int[] multikey)
        {
            int character;                      //Used for individual character storage and manipulation
            int keyLength = multikey.Length;    //Holds the multikey length as it is used several times
            int textLength = text.Length;       //Holds the encrpted message length as it is used several times
            string result = "";                 //Stores the final unecrypted message

            for (int i = 0; i < textLength; i ++)
            {
                if (i < keyLength)
                {
                    character = text[i] + GetPosition(multikey[i]);
                }
                else
                {
                    character = text[i] + GetPosition(text[i - keyLength]);
                }
                GetInRange(ref character);
                result += (char)(character);
            }
            return result;
        }//************END OF ENCRYPTION METHODS*********************

        //************DECRYPTION METHODS*********************
        public static string SingleDec(string text, int[] singlekey)
        {
            int character;                      //Used for individual character storage and manipulation
            int textLength = text.Length;       //Holds the encrpted message length as it is used several times
            string result = "";                 //Stores the final unecrypted message

            for (int i = 0; i < textLength; i++)
            {
                character = text[i] + GetPosition(singlekey[0]) * -1;
                GetInRange(ref character);
                result += (char)(character);
            }
            return result;
        }
        public static string MultiDec(string text, int[] multikey)
        {
            int character;                      //Used for individual character storage and manipulation
            int keyLength = multikey.Length;    //Holds the multikey length as it is used several times
            int textLength = text.Length;       //Holds the encrpted message length as it is used several times
            string result = "";                 //Stores the final unecrypted message

            for (int i = 0; i < textLength; i++)
            {
                //Using the multikey over and over to decrypt the message
                character = text[i] + GetPosition(multikey[i % keyLength]) * -1;
                GetInRange(ref character);
                result += (char)(character);
            }
            return result;
        }
        public static string ContiDec(string text, int[] multikey)
        {
            int character;                      //Used for individual character storage and manipulation
            int keyLength = multikey.Length;    //Holds the multikey length as it is used several times
            int textLength = text.Length;       //Holds the encrpted message length as it is used several times
            string result = "";                 //Stores the final unecrypted message

            //Loops through each character in the encrypted message
            for (int i = 0; i < textLength; i++)
            {
                //The first section of the message is decrypted using the multikey
                if (i < keyLength)
                {
                    character = text[i] + GetPosition(multikey[i]) * -1;
                }
                //This second section section of the message is decrypted using the partially decrypted message already found in the first section
                else
                {
                    character = text[i] + GetPosition(result[i - keyLength]) * -1;
                }
                GetInRange(ref character);
                result += (char)character;
            }
            return result;
        }//************END OF DECRYPTION METHODS*********************
    } //End Class
} //End Namespace
