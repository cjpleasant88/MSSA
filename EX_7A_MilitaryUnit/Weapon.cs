using System;
using System.Collections.Generic;
using System.Text;

namespace EX_7A_MilitaryUnit
{
    public class Weapon
    {
        public string name { get; set; }

        public Weapon()
        {
            this.name = "Knife Hands";
        }

        public virtual void Reload()
        {
            Console.WriteLine("You reloaded the weapon");
        }
    }

    //Sword class derived from Weapon Class
    public class Sword : Weapon
    {
        public Sword() : base()
        {
            this.name = "Mameluke Sword";
        }
    }

    //KnifeHands Calss derived from Weapon Class
    public class KnifeHands : Weapon
    {
        public KnifeHands() : base()
        {
            this.name = "Rifle";
        }
    }
}
