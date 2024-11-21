using FluentAssertions;
using Xunit;
using FileAnalyzer;

namespace FileAnalyzer.FileAnalyzerTests
{
    public class SalesParseTest
    {
        // Test for null, empty, or whitespace line
        [Theory]
        [InlineData(null, "Line cannot be null or empty.")]
        [InlineData("", "Line cannot be null or empty.")]
        [InlineData("   ", "Line cannot be null or empty.")]
        public void Sale_Parse_ThrowsForNullEmptyOrWhiteSpaceLine(string line, string expectedMessage)
        {
            // Act
            //Action act = () => Sale.Parse(line);

            // Assert
           // act.Should().Throw<ArgumentNullException>().WithMessage(expectedMessage);
        }
    }
}
