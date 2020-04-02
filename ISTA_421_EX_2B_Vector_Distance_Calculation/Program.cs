using System;

namespace ISTA_421_EX_2B_Vector_Distance_Calculation
{
    class Program
    {
        //Can adjust number of points here
        public static int arraySize2D = 100;
        public static int arraySize3D = 1000;

        //Can set the Max value possible in a vector
        public static int maxPoint2D = 100;
        public static int maxPoint3D = 1000;

        static void Main(string[] args)
        {
            Console.WriteLine("\n\tISTA_421_EX_2B_Vector_Distance_Calculation.Program.Main()\n");

            //Creates an array to store 2D points
            Point2D[] Collection2DPoints = new Point2D[arraySize2D];

            //Storage variables for 2 closest points and distance between them
            int point1Index2D = -1;
            int point2Index2D = -1;
            double smallest2DDistance = int.MaxValue;

            //populates 2D array with random points
            for (int i = 0; i < Collection2DPoints.Length; i++)
            {
                Collection2DPoints[i] = new Point2D();
            }
            Console.WriteLine($"\t********** Finding the closest 2-Dimensional Vectors among {arraySize2D} vectors ***********\n");
            //Searches 2D array for smallest distance and reports as a smaller distance is found
            for (int i = 0; i < Collection2DPoints.Length; i++)
            {
                for (int j = i+1; j < Collection2DPoints.Length; j++)
                {
                    double distance = Collection2DPoints[i].Distance2DPoints(Collection2DPoints[j]);
                    if (distance < smallest2DDistance)
                    {
                        point1Index2D = i;
                        point2Index2D = j;
                        smallest2DDistance = distance;
                        Console.Write($"The closest points are array element {i} -- {Collection2DPoints[point1Index2D].ToString()}, ");
                        Console.Write($"array element {j} -- {Collection2DPoints[point2Index2D].ToString()} ");
                        Console.WriteLine($"having a distance of {smallest2DDistance} ");
                    }
                }
            }

            //Break between 2D and 3D sections
            Console.WriteLine();
            Console.WriteLine($"\t********** Finding the closest 3-Dimensional Vectors among {arraySize3D} vectors ***********\n");

            //Creates an array to store 3D points 
            Point3D[] Collection3DPoints = new Point3D[arraySize3D];

            //Storage variables for 2 closest points and distance between them
            int point1Index3D = -1;
            int point2Index3D = -1;
            double smallest3DDistance = int.MaxValue;

            //populates 3D array with random points
            for (int i = 0; i < Collection3DPoints.Length; i++)
            {
                Collection3DPoints[i] = new Point3D();
            }

            //Searches 3D array for smallest distance and reports as a smaller distance is found
            for (int i = 0; i < Collection3DPoints.Length; i++)
            {
                for (int j = i + 1; j < Collection3DPoints.Length; j++)
                {
                    double distance = Collection3DPoints[i].Distance3DPoints(Collection3DPoints[j]);
                    if (distance < smallest3DDistance)
                    {
                        point1Index3D = i;
                        point2Index3D = j;
                        smallest3DDistance = distance;
                        Console.Write($"The closest points are array element {i} -- {Collection3DPoints[point1Index3D].ToString()}, ");
                        Console.Write($"array element {j} -- {Collection3DPoints[point2Index3D].ToString()} ");
                        Console.WriteLine($"having a distance of {smallest3DDistance} ");
                    }
                }
            }
            Console.WriteLine($"\n\t********** Reporting of the Findings  ***********");

            //Reports the final 2 points that have the smallest distance from the 2D array
            Console.WriteLine($"\nThe closest 2 points in the {arraySize2D} point 2D Array are");
            Console.WriteLine($"array element {point1Index2D} --> {Collection2DPoints[point1Index2D].ToString()} and");
            Console.WriteLine($"array element {point2Index2D} --> {Collection2DPoints[point2Index2D].ToString()}");
            Console.WriteLine($"Having a distance of {smallest2DDistance} units.");

            //Reports the final 2 points that have the smallest distance from the 3D array
            Console.WriteLine($"\nThe closest 2 points in the {arraySize3D} point 3D Array are");
            Console.WriteLine($"array element {point1Index3D} --> {Collection3DPoints[point1Index3D].ToString()} and");
            Console.WriteLine($"array element {point2Index3D} --> {Collection3DPoints[point2Index3D].ToString()}");
            Console.WriteLine($"Having a distance of {smallest3DDistance} units.");

            Console.WriteLine($"\n\t********** End of the Findings  ***********");
        }
    }
}
