using System;
using System.Collections.Generic;
using System.Text;

namespace Foundation
{
    class Inheritance
    {
        public static void Execute()
        {
            //Animal animal = new Animal();// { Name = "Garfield" }; 
            Animal clsAnimal = new Animal("Garfield", 16);
            Animal clsDog = new Mammal("Odie", 14, true, true, false);
            ((Mammal)clsDog).LivesOnLand = true; 
        }

        public class Animal
        {
            private int lifeSpan; 

            public string Name { get; set; }

            public bool IsNocturnal { get; set; }

            public Animal() { }

            public Animal(string name, int lifespan, bool IsNocturnal = false)
            {
                Name = name;
                this.lifeSpan = lifespan;
                this.IsNocturnal = IsNocturnal; 
            }

            public virtual void Speak()
            {
                Console.WriteLine(Name + "Speak (Animal) "); 
            }

        }
        class Mammal : Animal
        {
            public bool IsCarnivore { get; set; }

            public bool LivesOnLand { get; set; } 

            public Mammal(String name, int lifespan, bool isCarnivore, bool livesOnLand, bool isNocturnal = false) : base(name, lifespan, isNocturnal)
            {
                this.IsCarnivore = isCarnivore;
                this.LivesOnLand = livesOnLand; 
            }

            public override void Speak()
            {
                Console.WriteLine(Name + " Speak (Animal) "); 
            }
        }
    }
}
