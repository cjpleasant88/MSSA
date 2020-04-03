using System;

namespace ISTA_421_EX_2B_Vector_Distance_Calculation
{
    public struct Point2D
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        public double Distance2DPoints(Point2D point2)
        {
            int xDistance = X - point2.X;
            int yDistance = Y - point2.Y;
            double distance = Math.Sqrt(xDistance * xDistance + yDistance * yDistance);
            return distance;
        }
    }
}
