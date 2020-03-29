using System;

namespace ISTA_421_EX_1E_BaseNumberConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\tISTA_421_EX_1E_BaseNumberConversion_Program.Main()");

            //****** Main code from HW assignment *******************
            Console.Write("Please enter the integer to convert: ");
            string n1 = Console.ReadLine();
            int number = int.Parse(n1);
            
            Console.Write("Please enter the base to convert from [2 | 8 | 10]: ");
            string n2 = Console.ReadLine();
            int from = int.Parse(n2);

            Console.WriteLine($"Number: {number}, base: {from}");
            //changing result from int to string. largest int that can be converted is 1023 
            //when 1023 decimal converted to binary ends up 1111111111
            //1024 decimal to binary is 10000000000 and is too large for int type to hold--> exception is thrown
            //int result = 0;

            //trying to input 2147483648 base 10 results in stack overflow.
            //can now convert numbers all the way to:
            //Max decimal value = int MaxValue: 2147483647
            //Max binary value  = 1111111111111111111111111111111
            //Max Octal value   = 17777777777
            string result = "";

            if (from == 10)
            {
                result = Util.dec2bin(number);
                Console.WriteLine($"binary conversion is {result}");
                result = Util.dec2oct(number);
                Console.WriteLine($"octal conversion is {result}");
            }
            else if (from == 2)
            {
                result = Util.bin2dec(number);
                Console.WriteLine($"decimal conversion is {result}");
                result = Util.bin2oct(number);
                Console.WriteLine($"octal conversion is {result}");
            }
            else if (from == 8)
            {
                result = Util.oct2bin(number);
                Console.WriteLine($"binary conversion is {result}");
                result = Util.oct2dec(number);
                Console.WriteLine($"decimal conversion is {result}");
            }
            else
            {
                Console.WriteLine("Error in bse to convert from");
            }
            //******** End of Main Code from HW assignment **************
        }

        public class Util
        {
            //Converts Decimal to Binary
            public static string dec2bin(int number)
            {
                return dec2base(number, 2);
            }
            //Converts Decimal to Octal
            public static string dec2oct(int number)
            {
                return dec2base(number, 8);
            }

            //Converts Decimal number to any given base
            public static string dec2base(int number, int toBase)
            {
                string reverseResult = "";
                while (number > 0)
                {
                    reverseResult += (number % toBase);
                    number /= toBase;
                }
                return ReverseString(reverseResult);
            }

            //Converts Binary to Decial
            public static string bin2dec(int number)
            {
                return base2dec(number, 2);
            }

            //Converts Binary to Octal (binary to decimal and then the decimal to octal)
            public static string bin2oct(int number)
            {
                return dec2oct(Convert.ToInt32(bin2dec(number)));
            }

            //Converts Octal to Deciaml
            public static string oct2dec(int number)
            {
                return base2dec(number, 8);
            }

            //Converts Octal to Binary (octal to decimal and then the decimal to binary)
            public static string oct2bin(int number)
            {
                return dec2bin(Convert.ToInt32(oct2dec(number)));
            }

            //Converts a given base number to Decimal value
            public static string base2dec(int number, int fromBase)
            {
                string input = Convert.ToString(number);
                int result = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    result += Convert.ToInt32(input[input.Length - 1 - i].ToString()) * (int)Math.Pow(fromBase, i);
                }
                return result.ToString();
            }

            //Reverses a given string value
            public static string ReverseString(string input)
            {
                string result = "";
                for (int i = input.Length - 1; i >= 0; i--)
                {
                    result += input[i];
                }
                //return Convert.ToInt32(result);
                return result;
            }
        }
    }
}
