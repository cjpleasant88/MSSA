using System;
using System.Collections.Generic;
using System.Text;

namespace EX_7A_MilitaryUnit
{
    public class Person
    {
        public string name { get; set; }
        public Vehicle myVehicle { get; set; }
        public Weapon myWeapon { get; set; }

        //Generic Person
        public Person()
        {
            this.name = "Recruit";
            this.myVehicle = new Vehicle();
            this.myWeapon = new Weapon();
        }

        public virtual void Travel()
        {
            Console.WriteLine($"Recruit {this.name} traveled from A to B slowly.");
            this.myVehicle.fuel -= this.myVehicle.travelCost;
            //this.myVehicle.DisplayFuel();
        }
    }

    //Officer from Base Class Person
    public class Officer : Person
    {
        public Officer() : base()
        {
            this.name = "Sir";
            this.myVehicle = new Helicopter();
            this.myWeapon = new Sword();
        }

        public override void Travel()
        {
            Console.WriteLine($"Officer {this.name} flew from A to B.");
            this.myVehicle.fuel -= this.myVehicle.travelCost;
            //this.myVehicle.DisplayFuel();
        }
    }

    //Enlisted from Base Class Person
    public class Enlisted : Person
    {
        public Enlisted() : base()
        {
            this.name = "Grunt";
            this.myVehicle = new Tank();
            this.myWeapon = new KnifeHands();
        }

        public override void Travel()
        {
            Console.WriteLine($"Enlisted member {this.name} rolled in a tank from A to B, destroying 3 cars in their path.");
            this.myVehicle.fuel -= this.myVehicle.travelCost;
            //this.myVehicle.DisplayFuel();
        }
    }
}
