using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Lab_4C_SpaceGame
{
    public class Ship
    {
        //Ship attributes
        public string name;
        public int fuel;
        public int shipX;
        public int shipY;
        public int level;
        public int capacity;

        //Default Constructor with ship starting at earth coordinates
        public Ship()
        {
            name = "No-Name";
            fuel = 10;
            shipX = 3;
            shipY = 1;
            level = 1;
            capacity = 40;
        }//End Ship Constructor

        //Returns a string with the planet that user is currently on
        public string CheckLocation()
        {
            string onPlanet = "";
            if (this.shipX == SpaceGame.earth.planetX && this.shipY == SpaceGame.earth.planetY)
            {
                onPlanet = SpaceGame.earth.name;
            }
            if (this.shipX == SpaceGame.jupiter.planetX && this.shipY == SpaceGame.jupiter.planetY)
            {
                onPlanet = SpaceGame.jupiter.name;
            }
            if (this.shipX == SpaceGame.alpha.planetX && this.shipY == SpaceGame.alpha.planetY)
            {
                onPlanet = SpaceGame.alpha.name;
            }
            if (this.shipX == SpaceGame.unknown.planetX && this.shipY == SpaceGame.unknown.planetY)
            {
                onPlanet = SpaceGame.unknown.name;
            }
            if (this.shipX == SpaceGame.tatooine.planetX && this.shipY == SpaceGame.tatooine.planetY)
            {
                onPlanet = SpaceGame.tatooine.name;
            }
            return onPlanet;
        }//End CheckLocation()

        //Displays a rocket depending on Ship Level when traveling
        public void TravelTo(Planet planet)
        {
            string rocket1 = @"
                                  /\
                                 (  )
                                 (  )
                                /|/\|\
                               /_||||_\";
            string rocket2 = @"        
                                    |
                                   / \
                                  / _ \
                                 |.o '.|
                                 |'._.'|
                                 |     |
                               ,'|  |  |`.
                              /  |  |  |  \
                              |,-'--|--'-.|";
            string rocket3 = @"
                                   !
                                   !
                                   ^
                                  / \
                                 /___\
                                |=   =|
                                |     |
                                |     |
                                |     |
                                |     |
                                |     |
                                |     |
                                |     |
                                |     |
                                |     |
                               /|##!##|\
                              / |##!##| \
                             /  |##!##|  \
                            |  / ^ | ^ \  |
                            | /  ( | )  \ |
                            |/   ( | )   \|
                                ((   ))
                               ((  :  ))
                               ((  :  ))
                                ((   ))
                                 (( ))
                                  ( )
                                   .
                                   .
                                   .";

            Console.Clear();
            for (int i = 0; i < 40; i++)
            {
                Console.WriteLine("");
            }
            switch (this.level)
            {
                case 1:
                    Console.WriteLine(rocket1);
                    break;
                case 2:
                    Console.WriteLine(rocket2);
                    break;
                case 3:
                    Console.WriteLine(rocket3);
                    break;
            }
            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine("");
                Thread.Sleep(120);
            }

            //Sets the ship location to the traveled to planet location
            this.shipX = planet.planetX;
            this.shipY = planet.planetY;
            Console.WriteLine($"You are now on Planet {CheckLocation()}!");
            SpaceGame.Continue();
        }//End TravelTo()

        public void CheckDistanceTo(Planet planet)
        {
            //Determines X and Y between ship and planet
            int x = planet.planetX - this.shipX;
            int y = planet.planetY - this.shipY;

            //Calculates Distance round to 2 decimal places
            double distanceToPlanet = Math.Round(Math.Sqrt(x * x + y * y), 2);

            //Calculates Traveltime to 2 decimal places using ship level and predetermined travel ratio
            double travelTime = Math.Round(distanceToPlanet * SpaceGame.travelRatio / this.level, 2);

            Console.WriteLine($"\t{planet.name} is {distanceToPlanet} TNG Warp Factors away.");
            Console.Write("It would take ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{travelTime}");
            Console.ResetColor();
            Console.WriteLine(" years to get based on your ship level.");

            Console.Write("\n\tDo you want to go there? [Y/N]: ");
            string choice = Convert.ToString(Console.ReadLine().ToUpper());
            switch (choice)
            {
                case "Y":
                    SpaceGame.gameTime += travelTime;
                    break;
                case "N":
                    Console.WriteLine("\nOk, no problem...");
                    SpaceGame.Choices();
                    break;
                default:
                    Console.WriteLine("\nNot sure what you meant by that?\n");
                    CheckDistanceTo(planet);
                    break;
            }


        }//End CheckDistanceTo

        //Check to see if we have the fuel
        public void CheckFuel(double travelTime)
        {
            Console.WriteLine("//TODO: Write check fuel method");
            if (fuel < travelTime)
            {
  
            }
        }//End CheckFuel

    }//End Ship Class
}
