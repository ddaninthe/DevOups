using System;

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

    public class ArabToRomanConverter
    {
        public static String Convert(int number)
        {
            String output = "";
            while (number > 999)
            {
                output += "M";
                number -= 1000;
            }
            if (number > 899)
            {
                output += "CM";
                number -= 900;
            }
            if (number > 499)
            {
                output += "D";
                number -= 500;
            }
            if (number > 399)
            {
                output += "CD";
                number -= 400;
            }
            while (number > 99)
            {
                output += "C";
                number -= 100;
            }
            if (number > 89)
            {
                output += "XC";
                number -= 90;
            }
            if (number > 49)
            {
                output += "L";
                number -= 50;
            }
            if (number > 39)
            {
                output += "XL";
                number -= 40;
            }
            while (number > 9)
            {
                output += "X";
                number -= 10;
            }
            if (number == 9) return output + "IX";
            if (number > 4)
            {
                output += "V";
                number -= 5;
            }
            if (number == 4) return output + "IV";
            while (number > 0) 
            {
                output += "I";
                number--;
            }
            return output;
        }
    }
}
