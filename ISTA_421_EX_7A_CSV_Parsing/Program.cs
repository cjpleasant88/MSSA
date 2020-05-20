
using System;
using System.Collections.Generic;

namespace ISTA_421_EX_7A_CSV_Parsing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\tISTA_421_EX_7A_CSV_Parsing.Program.Main()");

            /*************************
            * read CSV with embedded commas
            * parse CSV into separate fields and
            * ignore commas within quoted string
            * ***********************/

            Console.WriteLine("Reading CSV with embedded commas");
            List<string> myList = new List<string>();
            string input1 = "\"a,b\",c";
            myList.Add(input1);
            string input2 = "\"Obama, Barack\",\"August 4, 1961\",\"Washington, D.C.\"";
            myList.Add(input2);
            string input3 = "\"Ft. Benning, Georgia\",32.3632N,84.9493W," +
            "\"Ft. Stewart, Georgia\",31.8691N,81.6090W," +
            "\"Ft. Gordon, Georgia\",33.4302N,82.1267W";
            myList.Add(input3);
            foreach (string s in myList)
            {
                Console.WriteLine($"Current input is {s}");
                List<string> output = getCSV(s);
                int len = output.Count;
                Console.WriteLine($"This line has {len} fields. They are:");
                foreach (string s1 in output)
                    Console.WriteLine(s1);
            }
            Console.WriteLine("Press any key to continue . . .");
            Console.ReadKey();
        }

        public static List<string> getCSV(string s)
        {
            List<string> output = new List<string>();   //Creates a new List to Store CSV's
            string newCsv = "";                         //Creates a holder for a new CSV

            for (int i = 0; i < s.Length; i++)          //Loops through the entire input string
            {
                //if > " < is found, it is the beginning of a CSV that should ignore > , < until the ending > " < is found
                if (s[i] == '"')
                {
                    //keeps increasing i by 1 until ending > " < is found, saving the string characters as it loops
                    while (s[++i] != '"')
                    {
                        newCsv += s[i];
                    }
                }
                //if No > " < present, copy the current index value to the CSV holder until a > , < is found
                else
                {
                    while (s[i] != ',')
                    {
                        newCsv += s[i];

                        //When the end of the loop is hit, break out of the loop
                        if (i < s.Length - 1)
                        {
                            i++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                //for each newCSV found, as long as it is not empty, it will be added the the output list
                if (!string.IsNullOrEmpty(newCsv))
                {
                    output.Add(newCsv);
                }
                //resets the CSV to an empty holder for next new CSV
                newCsv = "";
            }
            return output;
        }
    }
}