using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_4C_SpaceGame
{
    //Human Player Class
    public class Player
    {
        //Player attributes
        public int credits;
        public string name;
        public int iron;
        public int salt;
        public int darkMatter;
        public int rareMetals;
        public int unobtanium;
        public int seeds;
        public int hydrogen;
        public double age;

        //Default Constructor
        public Player()
        {
            name        = "No-Name";
            credits     = 0;
            iron        = 0;
            salt        = 0;
            darkMatter  = 0;
            rareMetals  = 0;
            unobtanium  = 0;
            seeds       = 0;
            hydrogen    = 0;
            age         = 18.0;
    }//End Player Constructor
    }//End Player class
}
