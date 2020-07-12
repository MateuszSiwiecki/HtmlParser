using Xunit;
using Model.HtmlScratchDataModel;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace Model.HtmlScratchDataModel.Tests
{
    public class MarkupsReplacerTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public MarkupsReplacerTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Theory()]
        [InlineData("qwe ewq << >>", "<<", ">>", "/qwe", "/ewq")]
        [InlineData("eee<<<<qqq >>>>", "<<", ">>", "_", "-")]
        [InlineData("<<quote>>", "<<", ">>", "/qwe", "/ewq")]
        public void TwoPatternsReplacerTest_ShouldPass(string input,
            string leftPattern,
            string rightPattern,
            string leftMarkup,
            string rightMarkup)
        {
            var output =
                input.TwoPatternsReplacer(leftPattern, rightPattern, leftMarkup,
                    rightMarkup);
            _testOutputHelper.WriteLine(output);
            Assert.Contains(leftMarkup, output);
            Assert.Contains(rightMarkup, output);
        }

        [Theory()]
        [InlineData("qwe ewq << >", "<<", ">>", "/qwe", "/ewq")]
        [InlineData("eee<<<<qqq >>>", "<<", ">>", "_", "-")]
        [InlineData("**quote||", "**", "|", "/qwe", "/ewq")]
        public void TwoPatternsReplacerTest_ShouldFail_WithWrongMarkupException(string input,
            string leftPattern,
            string rightPattern,
            string leftMarkup,
            string rightMarkup)
        {
            Assert.Throws<WrongMarkupException>(() =>
                input.TwoPatternsReplacer(leftPattern, rightPattern, leftMarkup,
                    rightMarkup));
        }

        [Theory()]
        [InlineData("  ", " ", " ", "L", "R")]
        [InlineData("  ", " ", "L", "L", "R")]
        public void TwoPatternsReplacerTest_ShouldFail_WithErrorResult(string input,
            string leftPattern,
            string rightPattern,
            string leftMarkup,
            string rightMarkup)
        {
            Assert.Throws<ArgumentException>(() =>
                input.TwoPatternsReplacer(leftPattern, rightPattern, leftMarkup,
                    rightMarkup));
        }

        [Theory()]
        [InlineData("qeq", "q", "R", "L")]
        public void SamePatternReplacementTest_ShouldPass(string input, string pattern, string markupLeft,
            string markupRight)
        {
            var output = input.SamePatternReplacement(pattern, markupLeft, markupRight);
        }
        [Theory()]
        [InlineData("qeq", "q", "R", "L")]
        public void SamePatternReplacementTest_ShouldFail_WithWrongMarkupException(string input, string pattern, string markupLeft,
            string markupRight)
        {

        }

        [Theory()]
        [InlineData("{qeq|asd}zxc")]
        [InlineData("{Typ|Tytuł}Tekst")]
        public void WholeLineMarkupTest_ShouldPass(string input)
        {
            var output = input.WholeLineMarkup();
            _testOutputHelper.WriteLine(output);
            Assert.Contains("header", output);
            Assert.Contains("</aside>", output);
        }

        private static int _headerIndex = 1;
        [Theory]
        [InlineData("#QWE")]
        [InlineData("#Tekst")]
        [InlineData("#llllllllllllllAAAAAAAAAAAA")]
        public void HashMarkupTest_ShouldPass(string input)
        {
            var output = input.HashMarkup();
            _testOutputHelper.WriteLine(output);
            _testOutputHelper.WriteLine($"Index: {_headerIndex}");
            Assert.Contains($"<h{_headerIndex++} id=", output);
            Assert.DoesNotContain($"#", output);
        }
    }
}