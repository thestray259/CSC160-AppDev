using System;
using System.Collections.Generic;
using System.Text;

namespace Foundation
{
    class ExtensionMethods
    {
        public static void Engage()
        {
            string strMsg = new string("Havarti Cheese");
            //Console.WriteLine("Size of {0} is {1}", strMsg, strMesg.Length); 
            //Console.WriteLine("Is '{0}' first letter capizapized? {1} ", strMsg, strMsg.IsFirstCap()); 
            Console.WriteLine("Is '{0}' first letter lowercase? {1} ", strMsg, strMsg.IsFirstLower()); 
            //Console.WriteLine(strMsg.AppendToEnd(" is the best cheese in the world. ")); 
        }
    }

    public static class StringHelper
    {
        public static bool IsFirstCap(this string strIncoming)
        {
            return char.IsUpper(strIncoming[0]); 
        }

        public static bool IsFirstLower(this string strIncoming)
        {
            return char.IsLower(strIncoming[0]);
        }

        public static string AppendToEnd(this string incoming, string append)
        {
            return incoming + append; 
        }
    }
}
