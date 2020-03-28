using System;
using System.Collections.Generic;
using System.Text;

namespace EX_7A_MilitaryUnit
{
    public class Vehicle
    {
        public int fuel { get; set; }
        public int travelCost { get; set; }
        public string name { get; set; }

        public Vehicle()
        {
            name = "Safety-Vic";
            fuel = 100;
            travelCost = 3;
        }

        public void DisplayFuel()
        {
            Console.WriteLine($"\tYou have {this.fuel} units of fuel remaining.");
        }
    }


    //Tank Class derived from Vehicle Class
    public class Tank : Vehicle
    {
        public Tank() : base()
        {
            name = "AAV";
            travelCost = 10;
        }
    }

    //Helicopter Class from Base Class Vehicle
    public class Helicopter : Vehicle
    {
        public Helicopter() : base()
        {
            name = "Osprey";
            travelCost = 15;
        }
    }
}
