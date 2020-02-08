using System;

namespace Test
{
    public class Program

    {
         static void Main(string[] args)
        {
            string test = "The sunset sets at twelve o' clock.";
            test = AlphabetPosition(test);
            Console.WriteLine($"{test}");
        }
        public static string AlphabetPosition(string text)
        {
            string output = text;
            text = "";
            for (int i = 0; i < output.Length; i++)
            {
                char a = output[i];
                switch (a)
                {
                    case 'a':
                    case 'A': text += "1 "; break;
                    case 'b':
                    case 'B': text += "2 "; break;
                    case 'c':
                    case 'C': text += "3 "; break;
                    case 'd':
                    case 'D': text += "4 "; break;
                    case 'e':
                    case 'E': text += "5 "; break;
                    case 'f':
                    case 'F': text += "6 "; break;
                    case 'g':
                    case 'G': text += "7 "; break;
                    case 'h':
                    case 'H': text += "8 "; break;
                    case 'i':
                    case 'I': text += "9 "; break;
                    case 'j':
                    case 'J': text += "10 "; break;
                    case 'k':
                    case 'K': text += "11 "; break;
                    case 'l':
                    case 'L': text += "12 "; break;
                    case 'm':
                    case 'M': text += "13 "; break;
                    case 'n':
                    case 'N': text += "14 "; break;
                    case 'o':
                    case 'O': text += "15 "; break;
                    case 'p':
                    case 'P': text += "16 "; break;
                    case 'q':
                    case 'Q': text += "17 "; break;
                    case 'r':
                    case 'R': text += "18 "; break;
                    case 's':
                    case 'S': text += "19 "; break;
                    case 't':
                    case 'T': text += "20 "; break;
                    case 'u':
                    case 'U': text += "21 "; break;
                    case 'v':
                    case 'V': text += "22 "; break;
                    case 'w':
                    case 'W': text += "23 "; break;
                    case 'x':
                    case 'X': text += "24 "; break;
                    case 'y':
                    case 'Y': text += "25 "; break;
                    case 'z':
                    case 'Z': text += "26 "; break;
                    default: break;
                }
            }
            text = text.Substring(0, text.Length - 1);
            return text;
        }
    }
}
