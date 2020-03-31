using System;
using System.Collections.Generic;
using System.Text;

namespace ISTA_421_EX_2B_Vector_Distance_Calculation
{
    public class Point3D
    {
        public static Random random = new Random();
        public static int lowPointRange = 0;
        public static int highPointRange = Program.maxPoint3D;

        public int X { get; set; }

        public int Y { get; set; }

        public int Z { get; set; }

        public Point3D()
        {
            X = random.Next(lowPointRange, highPointRange + 1);
            Y = random.Next(lowPointRange, highPointRange + 1);
            Z = random.Next(lowPointRange, highPointRange + 1);
        }

        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }

        public double Distance3DPoints(Point3D point2)
        {
            int xDistance = this.X - point2.X;
            int yDistance = this.Y - point2.Y;
            int zDistance = this.Z - point2.Z;
            double distance = Math.Sqrt(xDistance * xDistance + yDistance * yDistance + zDistance * zDistance);
            return distance;
        }
    }
}
