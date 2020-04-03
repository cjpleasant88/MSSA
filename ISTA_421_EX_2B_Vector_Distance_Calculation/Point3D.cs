using System;

namespace ISTA_421_EX_2B_Vector_Distance_Calculation
{
    public struct Point3D
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Point3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }

        public double Distance3DPoints(Point3D point2)
        {
            int xDistance = X - point2.X;
            int yDistance = Y - point2.Y;
            int zDistance = Z - point2.Z;
            double distance = Math.Sqrt(xDistance * xDistance + yDistance * yDistance + zDistance * zDistance);
            return distance;
        }
    }
}
