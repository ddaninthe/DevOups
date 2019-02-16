using System;
using Xunit;
using AppConsole;

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
}
