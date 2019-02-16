using System;
using Romans;

namespace AppConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int number;
            if (Int32.TryParse(args[0], out number)) 
            {
                System.Console.WriteLine(ArabToRomanConverter.Convert(number));
            } 
            else 
            {
                System.Console.WriteLine(args[0] + "is not a number");
            }   
        }
    }
}
