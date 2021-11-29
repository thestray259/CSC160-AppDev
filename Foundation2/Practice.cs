using System;
using System.Collections.Generic;
using System.Text;

namespace Foundation
{
    class Practice
    {
        void DoIt()
        {
            Inheritance.Animal fish = new Fish(); 
            
            if (fish is Fish swimmingFish)
            {
                swimmingFish.Swim(); 
            }
        }
    }

    class Fish : Inheritance.Animal
    {
        public void Swim()
        {
            Console.WriteLine("I'm swimming!"); 
        }
    }

    interface ISwim
    {
        public void Swim();
    }

    abstract class Cat : Inheritance.Animal
    {
        abstract public void Walk();
    }

    interface IWalk
    {
        public void Walk(); 
    }
}
