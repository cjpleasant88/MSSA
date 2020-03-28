 using System;

namespace EX_6A_Manipulating_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tLab_6A_Manipulating_Arrays.Program.Main()\n");

            //Creation of the 3 Arrays
            int[] arrayA = new int[6] { 0, 2, 4, 6, 8, 10 };
            int[] arrayB = { 1, 3, 5, 7, 9 };
            int[] arrayC = new int[12] { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5, 9 };

            Console.WriteLine("\tGiven that :");
            Console.Write($"\nArray A is: ");
            DisplayArray(arrayA);
            Console.Write($"Array B is: ");
            DisplayArray(arrayB);
            Console.Write($"Array C is: ");
            DisplayArray(arrayC);

            Console.WriteLine("\n*******COUNTING, SUMMING, COMPUTING THE MEAN***********");
            Console.Write("\nThe average for Array A is: ");
            Console.WriteLine(Mean(arrayA));
            Console.Write("The average for Array B is: ");
            Console.WriteLine(Mean(arrayB));
            Console.Write("The average for Array C is: ");
            Console.WriteLine(Mean(arrayC));

            Console.WriteLine("\n*******************REVERSING ARRAYS*********************");
            Console.Write("\nThe reverse of Array A is: ");
            ReverseArray(arrayA);
            Console.Write("The reverse of Array B is: ");
            ReverseArray(arrayB);
            Console.Write("The reverse of Array C is: ");
            ReverseArray(arrayC);

            Console.WriteLine("\n******************ROTATING ARRAYS**********************");
            Console.Write("\nRotating Array A to Left 2 places gives: ");
            RotateArray("Left", 2, arrayA);
            Console.Write("Rotating Array B to Right 2 places gives: ");
            RotateArray("Right", 2, arrayB);
            Console.Write("Rotating Array C to Left 4 places gives: ");
            RotateArray("Left", 4, arrayC);

            Console.WriteLine("\n*********************SORTING ARRAYS*********************");
            Console.Write("\nSorting Array A gives: ");
            SortArray(arrayA);
            Console.Write("Sorting Array B gives: ");
            SortArray(arrayB);
            Console.Write("Sorting Array C gives: ");
            SortArray(arrayC);

            Console.WriteLine("\n***************************END***************************");
        }

        //Output a given Array
        public static void DisplayArray(int[] array)
        {
            Console.Write("[");
            for (int i = 0; i < array.Length - 1; i++)
            {
                Console.Write($"{array[i]}, ");
            }
            Console.WriteLine($"{array[array.Length - 1]}]");
        }

        //Return the Average of a given Array
        public static double Mean(int[] array)
        {
            int sum = 0;
            foreach (int indexValue in array)
            {
                sum += indexValue;
            }
            double average = (double)sum / array.Length;

            return average;
        }

        //Reverse a Given Array
        public static void ReverseArray(int[] array)
        {
            //Displays the reverse
            Console.Write("[");
            for (int i = array.Length-1; i > 0; i--)
            {
                Console.Write($"{array[i]}, ");
            }
            Console.WriteLine($"{array[0]}]");
        }

        //Rotating A Given Array
        public static void RotateArray(string direction, int places, int[] array)
        {
            int length = array.Length;
            int[] temp = new int[length];
            switch (direction)
            {
                case "Right":
                case "right":
                    if ( places < 0)
                    {
                        places = Math.Abs(places);
                        goto case "Left";
                    }
                    for (int i = 0; i < array.Length; i++)
                    {
                        temp[(i + places) % length] = array[i];
                    }

                    DisplayArray(temp);
                    break;
                case "Left":
                case "left":
                    if (places < 0)
                    {
                        places = Math.Abs(places);
                        goto case "Right";
                    }
                    for (int i = 0; i < array.Length; i++)
                    {
                        temp[(i + length - (places % length)) % length] = array[i];
                    }
                    DisplayArray(temp);
                    break;
            }
        }

        //Sort a Given Array
        public static void SortArray(int[] array)
        {
            int temp;
            for (int i = 0; i < array.Length-1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
            DisplayArray(array);
        }
    }
}
