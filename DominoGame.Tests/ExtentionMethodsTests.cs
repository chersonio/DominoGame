using DominoGame.Helpers;

namespace DominoGame.Tests
{
    public class ExtentionMethodsTests
    {
        [Fact]
        public void ToDominos_NullInput_ExpectedException()
        {
            // Arrange
            var textInput = "";

            // Act
            var act = () => textInput.ToDominos();

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentNullException>(act);
            Assert.Equal("Cannot accept empty domino text input (Parameter 'dominoTextInput')", exception.Message);
        }

        [Theory]
        [InlineData("error")]
        [InlineData("[]")]
        public void ToDominos_WrongInputValue_ExpectedException(string textInput)
        {
            // Arrange
            // Act
            var act = () => textInput.ToDominos();

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal("Value does not fall within the expected range. Please check input following example: [1|2], [2|3], [3|1] (Parameter 'textDominoCouple')", exception.Message);
        }

        [Theory]
        [InlineData("[1|2]", 1)]
        [InlineData("[1|2], [2|1]", 2)]
        [InlineData("[1|2], [1|2]", 2)]
        [InlineData("[1|2], [2|3], [3|1]", 3)]
        [InlineData("[1|2], [1|2], [2|1]", 3)]
        [InlineData("[1|3], [4|5], [3|5], [1|4]", 4)]
        [InlineData("1|3, 4|5, 3|5, 1|4", 4)]
        public void ToDominos_CorrectInput_ExpectedSuccessful(string textInput, int expectedDominoCount)
        {
            // Arrange
            // Act
            var output = textInput.ToDominos();

            // Assert
            Assert.NotEmpty(output);
            Assert.Equal(expectedDominoCount, output.Count());
        }
    }
}
