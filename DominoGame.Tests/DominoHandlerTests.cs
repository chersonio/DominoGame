using DominoGame.Entities;

namespace DominoGame.Tests
{
    public class DominoHandlerTests
    {
        #region FindDominoChain
        [Fact]
        void FindDominoChain_ExpectedSuccessful()
        {
            // Arrange
            var dominoes = new List<Domino>
            {
                new Domino(1, 2),
                new Domino(2, 3),
                new Domino(3, 1),
            };

            // Act
            var outputDominos = DominoHandler.FindDominoChain(dominoes);
            var result = string.Join(" ", outputDominos);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal("1|2 2|3 3|1", result);
        }

        [Fact]
        void FindDominoChain_TwoSameElements_ExpectedSuccessful()
        {
            // Arrange
            var dominoes = new List<Domino>
            {
                new Domino(1, 2),
                new Domino(2, 1),
            };

            // Act
            var outputDominos = DominoHandler.FindDominoChain(dominoes);
            var result = string.Join(" ", outputDominos);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal("1|2 2|1", result);
        }

        [Fact]
        void FindDominoChain_NullDominoes_ExpectedNull()
        {
            // Arrange
            var dominoes = new List<Domino>();

            // Act
            var outputDominos = DominoHandler.FindDominoChain(dominoes);

            // Assert
            Assert.Null(outputDominos);
        }

        [Fact]
        void FindDominoChain_OneDomino_ExpectedNull()
        {
            // Arrange
            var dominoes = new List<Domino>()
            {
                new Domino(1,5)
            };

            // Act
            var outputDominos = DominoHandler.FindDominoChain(dominoes);

            // Assert
            Assert.Null(outputDominos);
        }

        [Fact]
        void FindDominoChain_NoMatchForLastDomino_ExpectedNull()
        {
            // Arrange
            var dominoes = new List<Domino>()
            {
                new Domino(1,2),
                new Domino(2,4),
                new Domino(1,5),
            };

            // Act
            var outputDominos = DominoHandler.FindDominoChain(dominoes);

            // Assert
            Assert.Null(outputDominos);
        }

        [Fact] // ERROR!!!
        void FindDominoChain_DominoNoMatchingChain_ExpectedNull()
        {
            // Arrange
            var dominoes = new List<Domino>()
            {
                new Domino(4, 5),
                new Domino(5, 4),
                new Domino(5, 4),
            };

            // Act
            var outputDominos = DominoHandler.FindDominoChain(dominoes);

            // Assert
            Assert.Null(outputDominos);
        }

        [Fact]
        void FindDominoChain_NoChain_ExpectedNull()
        {
            // Arrange
            var dominoes = new List<Domino>()
            {
                new Domino(1,5),
                new Domino(2,3)
            };

            // Act
            var outputDominos = DominoHandler.FindDominoChain(dominoes);

            // Assert
            Assert.Null(outputDominos);
        }
        #endregion

        #region TrySortDominoChain

        [Fact]
        void TrySortDominoChain_NotEqualValues_ExpectedNull()
        {
            // Arrange
            var dominoes = new List<Domino>()
            {
                new Domino(1,5),
                new Domino(2,3)
            };

            // Act
            var outputDominos = DominoHandler.TrySortDominoChain(dominoes, dominoes.First());

            // Assert
            Assert.Null(outputDominos);
        }
        
        [Fact]
        void TrySortDominoChain_EqualValues_ExpectedSuccessful()
        {
            // Arrange
            var dominoes = new List<Domino>()
            {
                new Domino(5,1),
                new Domino(5,1)
            };

            // Act
            var outputDominos = DominoHandler.TrySortDominoChain(dominoes, dominoes.First());

            // Assert
            Assert.NotNull(outputDominos);
            Assert.Equal(dominoes.Count, outputDominos.Count);
        }

        #endregion
    }
}