using System;
using Xunit;
using AppConsole;

namespace TestsExam
{
    public class UnitTest1
    {
        // Test Exception is thrown
        /*[TestInvalidFile()]
        [ExpectedException(typeof(AppConsole.InvalidFileException))]
        public void TestInvalidFile()
        {
            Program.Check(new string[]{"check", "fjaiofhaeofhoahefafuaieff"});
        }*/
        
        [Fact]
        public void TestValidCheck()
        {
            bool result = Program.Check(new string[] {"check", "../../../../AppConsole/yoda.yml"});
            Assert.True(result);
        }

        []
        public void TestValidFill()
        {
            string result = Program.Fill(new string[] { "fill", "../../../../AppConsole/yoda.yml",
                                                        "../../../../AppConsole.template.md"});
            Assert.True(result.Length > 0);
        }
    }
}
