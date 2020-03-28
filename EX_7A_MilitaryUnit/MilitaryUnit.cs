using System;
using System.Collections.Generic;
using System.Text;

namespace EX_7A_MilitaryUnit
{
    class MilitaryUnit
    {
        //random variable
        public Random random { get; }           //*****************My Read Only Property

        //calculates the total number of names in the enumeration for future random number calculations
        //public static int nameCount = Enum.GetNames(typeof(Names)).Length;
        public int nameCount { get; set; }

        //Declares an array of the same length as the Names enumeration
        //public static int[] usedNames = new int[nameCount];
        public int[] usedNames { get; set; }

        //keeps track of how many names have been given out
        //public static int namePlace = 0;
        public int namePlace { get; set; }

        public MilitaryUnit()
        {
            //seeds random to be used for getting names
            random = new Random();
            //Counts the number of names in the enum List
            nameCount = Enum.GetNames(typeof(Names)).Length;
            //creates an array to store used names based on number of enum names
            usedNames = new int[nameCount];
            //tracks the index to store the next used name
            namePlace = 0;
        }
    
    }
}
