using System;
using Xunit;

namespace ModelTest
{
    public class HtmlParserTest
    {
        public static void Execute()
        {

        }

        [Theory]
        [InlineData("123\n321")]
        [InlineData("123 321")]
        public void CheckIfInputIsNullOrEmpty_ShouldPass(string input)
        {
        }
    }
}
