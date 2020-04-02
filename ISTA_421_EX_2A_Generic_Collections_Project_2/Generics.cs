using System;
using System.Collections.Generic;

namespace ISTA_421_EX_2A_Generic_Collections_Project_2
{
    public class Generics
    {
        public static void ShowList()
        {
            Console.WriteLine("\n***** Printing from a LIST Data Structure: *****");
            List<string> list = new List<string>();
            list.Add($"Adding");
            list.Add($"Things");
            list.Add($"To");
            list.Add($"A");
            list.Add($"List");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"List Item {i + 1}: {list[i]}");
            }
        }
        public static void ShowLinkedList()
        {
            Console.WriteLine("\n***** Printing from a LINKED LIST Data Structure: *****");
            LinkedList<string> linkList = new LinkedList<string>();
            linkList.AddFirst("dots");
            linkList.AddBefore(linkList.Find("dots"), "the");
            linkList.AddAfter(linkList.Find("dots"), "in");
            linkList.AddLast("a Linked List!");
            linkList.AddFirst("Connecting");
            int i = 1;
            for (LinkedListNode<string> node = linkList.First; node != null; node = node.Next)
            {
                string word = node.Value;
                Console.WriteLine($"Link List Item {i}: {word}");
                i++;
            }
        }
        public static void ShowQueue()
        {
            Console.WriteLine("\n***** Printing from a QUEUE Data Structure: *****");
            Queue<string> queue = new Queue<string>();
            foreach (string student in new string[] { "Student 14", "Student 27", "Student 34", "Student 41", "Student 59" })
            {
                queue.Enqueue(student);
                Console.WriteLine($"{student} needs help with homework");
            }
            Console.WriteLine("-----Dan clicked screen share-----");
            while (queue.Count > 0)
            {
                string student = queue.Dequeue();
                Console.WriteLine($"Dan helped {student} and they passed the class!");
            }
        }
        public static void ShowStack()
        {
            Console.WriteLine("\n***** Printing from a STACK Data Structure: *****");
            Stack<int> stack = new Stack<int>();
            foreach (int weight in new int[] { 45, 35, 25, 10, 5 })
            {
                stack.Push(weight);
                Console.WriteLine($"Jonesy put a {weight}lb weight on the bar");
            }
            Console.WriteLine("-----Jonesy couldn't lift the bar-----");
            while (stack.Count > 0)
            {
                int weight = stack.Pop();
                Console.WriteLine($"Jonsey took off a {weight}lb weight from the bar");
            }
        }
        public static void ShowDictionary()
        {
            Console.WriteLine("\n***** Printing from a DICTIONARY Data Structure: *****");
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("Boomer", "Typically someone born between 1946-1964");
            dictionary["afk"] = "Away From Keyboard";
            dictionary.Add("Skrrt", "To leave quickly");
            dictionary["Bae"] = "Before Anyone Else";
            dictionary.Add("Woke", "You are aware of what's going on in the world");
            foreach (KeyValuePair<string, string> element in dictionary)
            {
                string slang = element.Key;
                string meaning = element.Value;
                Console.WriteLine($"The term \"{slang}\" means \"{meaning}\"");
            }
        }
        public static void ShowSortedList()
        {
            Console.WriteLine("\n***** Printing from a SORTED LIST Data Structure: *****");
            SortedList<int, string> sortedList = new SortedList<int, string>();
            sortedList.Add(65000, "Customer Support Role");
            sortedList.Add(80000, "Software Developer");
            sortedList[120000] = "Database Administrator";
            sortedList.Add(74000, "new hire at your Uncle's Tech Company");
            sortedList[92000] = "Software Engineer";
            foreach (KeyValuePair<int, string> job in sortedList)
            {
                int salary = job.Key;
                string position = job.Value;
                Console.WriteLine($"For ${salary}, you can get a job as a {position}");
            }
        }
        public static void ShowHashSet()
        {
            Console.WriteLine("\n***** Printing from a HASH SET Data Structure: *****");
            HashSet<string> hashSet = new HashSet<string>(new string[] { "Hello", "world", "from" });
            hashSet.Add("a");
            HashSet<string> hashSet2 = new HashSet<string>();
            hashSet2.Add("from");
            hashSet2.Add("a");
            hashSet2.Add("Hash Set");
            hashSet.UnionWith(hashSet2);
            foreach (string element in hashSet)
            {
                Console.WriteLine(element);
            }
        }
    }
}
