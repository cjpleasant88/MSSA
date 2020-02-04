using System;

namespace EX_4A_Creating_a_Farm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tEX_4A_Creating_A_Farm.Program.Main()\n");

            //Creates all the animales (2 horses, 1 pig, 1 chicken, and 1 cow)
            var mrEd = new Horse("Mr.Ed");
            var newHorse = new Horse();
            var porky = new Pig("Porky");
            var rooster = new Chicken("Mr. Clucks");
            var hersey = new Cow("Hersey");

            //The first horse and methods spcific to it
            mrEd.Speak();
            mrEd.walk();
            mrEd.eat();
            mrEd.sleep();
            Console.WriteLine("\n");

            //Actions for the pig to do
            porky.Speak();
            porky.walk();
            porky.eat();
            porky.sleep();
            porky.Bacon();
            Console.WriteLine("\n");

            //Actions for the Chicken to do
            rooster.Speak();
            rooster.walk();
            rooster.eat();
            rooster.sleep();
            Console.WriteLine("\n");

            //Actions for the Cow to do
            hersey.Speak();
            hersey.walk();
            hersey.eat();
            hersey.sleep();

            //Final comment about the farm animals
            Console.WriteLine("\n\tIts starting to look like a real farm over here.");
        }
    }

    //Horse class and methods
    class Horse
    {
        string name;
        int age;

        public Horse()
        {
            name = "No-Name-Horse";
            age = 0;
        }

        public Horse(string name)
        {
            this.name = name;
        }

        public void Speak()
        {
            Console.WriteLine($"Horses make a neigh noise! {this.name} says Hello!");
        }

        public void walk()
        {
            Console.WriteLine($"Yeah, 'bout time you took {this.name} for a walk");
        }

        public void eat()
        {
            Console.WriteLine($"{this.name} says thanks for the grub!");
        }

        public void sleep()
        {
            Console.WriteLine($"ZzZzZzz...shhhhh, {this.name} is sleeping now");
        }
    }

    //Pig Class and methods
    class Pig
    {
        string name;
        int age;

        public Pig()
        {
            name = "No-Named-Pig";
            age = 0;
        }

        public Pig(string name)
        {
            this.name = name;
        }

        public void Speak()
        {
            Console.WriteLine($"Your pig {this.name} said Oink-oink.");
        }

        public void walk()
        {
            Console.WriteLine($"{this.name} doesn't go very fast.");
        }

        public void eat()
        {
            Console.WriteLine($"{this.name} will eat anything!");
        }

        public void sleep()
        {
            Console.WriteLine($"{this.name} snorts while they sleep.");
        }

        public void Bacon()
        {
            Console.WriteLine($"{this.name} is not happy about this, but understands the temptation.");
        }
    }

    //Chicken Class and methods
    class Chicken
    {
        string name;
        int age;

        public Chicken()
        {
            name = "No-Name-Chicken";
            age = 0;
        }

        public Chicken(string name)
        {
            this.name = name;
        }

        public void Speak()
        {
            Console.WriteLine($"{this.name} clucks rather early in the day.");
        }

        public void walk()
        {
            Console.WriteLine($"{this.name} likes to fly to get around more than walk.");
        }

        public void eat()
        {
            Console.WriteLine($"{this.name} says thanks for the chicken seed!");
        }

        public void sleep()
        {
            Console.WriteLine($"Night night {this.name}");
        }
    }

    //Cow Class and methods
    class Cow
    {
        string name;
        int age;

        public Cow()
        {
            name = "No-Name-Cow";
            age = 0;
        }

        public Cow(string name)
        {
            this.name = name;
        }

        public void Speak()
        {
            Console.WriteLine($"{this.name} says moo");
        }

        public void walk()
        {
            Console.WriteLine($"{this.name} says moo more walking!");
        }

        public void eat()
        {
            Console.WriteLine($"{this.name} says moo food!");
        }

        public void sleep()
        {
            Console.WriteLine($"{this.name} jumped over the moooon!");
        }
    }
}
