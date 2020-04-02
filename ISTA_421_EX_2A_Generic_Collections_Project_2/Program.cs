using System;
using System.Collections.Generic;

namespace ISTA_421_EX_2A_Generic_Collections_Project_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\tISTA_421_EX_2A_Generic_Collections_Project_2.Program.Main()");

            Generics.ShowList();
            Generics.ShowLinkedList();
            Generics.ShowQueue();
            Generics.ShowStack();
            Generics.ShowDictionary();
            Generics.ShowSortedList();
            Generics.ShowHashSet();

            Console.WriteLine("\n*********************** END *****************************");
        }
    }
}