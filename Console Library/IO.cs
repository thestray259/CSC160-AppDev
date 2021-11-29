using System;

namespace Console_Library
{
    public class IO
    {

        public static void Print(string stringToPrint)
        {
            Console.WriteLine(stringToPrint); 
        }

        public static int GetConsoleInt(string message, int min, int max)
        {
            bool success = false;
            int typedValue;

            do
            {
                Console.Write(message);

                success = int.TryParse(Console.ReadLine(), out typedValue);
                success = success && (typedValue >= min) && (typedValue <= max);

                if (!success)
                {
                    Print($"You entered an invalid value. Must be between {min} and {max} and a valid interger. ");
                }
            }
            while (!success); 

            return typedValue; 
        }

        public static float GetConsoleFloat(string message, float min, float max)
        {
            bool success = false;
            float typedValue;

            do
            {
                Console.Write(message);

                success = float.TryParse(Console.ReadLine(), out typedValue);
                success = success && (typedValue >= min) && (typedValue <= max);

                if (!success)
                {
                    Print($"You entered an invalid value. Must be between {min} and {max} and a valid float. ");
                }
            }
            while (!success); 

            return typedValue; 
        }

        public static bool GetConsoleBool(string message)
        {
            bool success = false; 
            bool answer;

            do
            {
                Console.Write(message);

                success = bool.TryParse(Console.ReadLine(), out answer);
                success = (success && true) || (success && false); 

                if (!success)
                {
                    Print("You entered an invalid value. Must be true or false."); 
                }
            }
            while (!success); 

            return answer; 
        }

        public static char GetConsoleChar(string message)
        {
            bool success = false;
            char typedValue;

            do
            {
                Console.Write(message);

                success = char.TryParse(Console.ReadLine(), out typedValue);
                success = success && (typedValue >= 32) && (typedValue <= 126); 

                if (!success)
                {
                    Print("You enter an invalid value. Must be a char."); 
                }
            }
            while (!success); 

            return typedValue; 
        }

        public static string GetConsoleString(string message)
        {
            Console.Write(message);

            string typedValue = Console.ReadLine(); 

            return typedValue; 
        }

        public static int GetConsoleMenu(string[] items)
        {
            bool success = false; 
            int typedValue;

            do
            {
                for (int i = 0; i < items.Length; i++)
                {
                    Print((i + 1) + " - " + items[i]);
                }

                success = int.TryParse(Console.ReadLine(), out typedValue);
                success = success && (typedValue >= 1) && (typedValue <= (items.Length + 1)); 

                if (!success)
                {
                    Print("You entered an invalid value. Please try again between 1 and " + items.Length); 
                }
            }
            while (!success); 

            return typedValue; 
        }

/*        public static void GetConsoleGenericNumber<T>(string message, double min, double max)
        {
            bool success = false;
            double typedValue;

            do
            {
                Console.Write(message);

                success = double.TryParse(Console.ReadLine(), out typedValue); 
                success = success && (typedValue >= min) && (typedValue <= max);

                if (!success)
                {
                    Print($"You entered an invalid value. Must be between {min} and {max} and a valid input. ");
                }
            }
            while (!success);

            return typedValue; //(T)Convert.ChangeType(typedValue, typeof(T));
        }*/

    }
}
