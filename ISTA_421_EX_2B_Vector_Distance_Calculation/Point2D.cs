using System;
using System.Collections.Generic;
using System.Text;

namespace ISTA_421_EX_2B_Vector_Distance_Calculation
{
    public class Point2D
    {
        public static Random random = new Random();
        public static int lowPointRange = 0;
        public static int highPointRange = Program.maxPoint2D;

        public int X { get; set; }

        public int Y { get; set; }

        public Point2D()
        {
            X = random.Next(lowPointRange, highPointRange + 1);
            Y = random.Next(lowPointRange, highPointRange + 1);
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        public double Distance2DPoints(Point2D point2)
        {
            int xDistance = this.X - point2.X;
            int yDistance = this.Y - point2.Y;
            double distance = Math.Sqrt(xDistance * xDistance + yDistance * yDistance);
            return distance;
        }
    }
}
