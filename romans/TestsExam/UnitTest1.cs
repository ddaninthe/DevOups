using System;
using Xunit;

namespace Romans
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1, "I")]
        [InlineData(2, "II")]
        [InlineData(3, "III")]
        [InlineData(4, "IV")]
        [InlineData(5, "V")]
        [InlineData(7, "VII")]  
        [InlineData(9, "IX")]
        [InlineData(10, "X")]
        [InlineData(12, "XII")]
        [InlineData(13, "XIII")]        
        [InlineData(14, "XIV")]  
        [InlineData(15, "XV")]
        [InlineData(17, "XVII")]
        [InlineData(19, "XIX")]
        [InlineData(24, "XXIV")]
        [InlineData(30, "XXX")]
        [InlineData(36, "XXXVI")]
        [InlineData(40, "XL")]
        [InlineData(46, "XLVI")]
        [InlineData(49, "XLIX")]
        [InlineData(50, "L")]
        [InlineData(69, "LXIX")]
        [InlineData(84, "LXXXIV")]
        [InlineData(90, "XC")]
        [InlineData(95, "XCV")]
        [InlineData(99, "XCIX")] 
        [InlineData(100, "C")]
        [InlineData(221, "CCXXI")]
        [InlineData(399, "CCCXCIX")]
        [InlineData(400, "CD")]
        [InlineData(490, "CDXC")]
        [InlineData(644, "DCXLIV")]
        [InlineData(895, "DCCCXCV")]
        [InlineData(900, "CM")]
        [InlineData(1490, "MCDXC")]
        [InlineData(2644, "MMDCXLIV")]
        [InlineData(3895, "MMMDCCCXCV")]
        public void ReturnRomanStringForArabValue(int value, string expected)
        {
            var result = ArabToRomanConverter.Convert(value);
            Assert.Equal(expected, result);
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
