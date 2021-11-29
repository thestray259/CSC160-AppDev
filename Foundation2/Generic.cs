using System;
using System.Collections.Generic;
using System.Text;

namespace Foundation
{
    class Generic
    {
        public static void Engage()
        {
            int intFirst = 20;
            int intSecond = 50;

            Swap<int>(ref intFirst, ref intSecond);

            Console.WriteLine("first: " + intFirst + " second: " + intSecond); 
        }

        static void Swap<T>(ref T tFirst, ref T tSecond)
        {
            T temp = tFirst;
            tFirst = tSecond;
            tSecond = temp; 
        }
    }
}
