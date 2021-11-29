using System;
using System.Collections.Generic;
using System.Text;

namespace Foundation
{
    public static  class Interface
    {
        public static void DoIt()
        {
            Inheritance.Animal bird = new Bird(); 

            if (bird is Bird flyingBird)
            {
                flyingBird.Fly();
                //bird.Fly(); 
            }
        }
    }

    class Bird : Inheritance.Animal, IFly
    {
        public void Fly()
        {
            Console.WriteLine("I'm flying!"); 
        }
    }
    interface IFly
    {
        public void Fly(); 
    }
}
