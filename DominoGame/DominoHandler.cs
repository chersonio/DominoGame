using DominoGame.Entities;
using DominoGame.Helpers;
using DominoGame.Logging;

namespace DominoGame
{
    /// <summary>
    /// Creates a chain of dominoes from from a user's input.
    /// Domino matching is considered when the left part of a domino matches with the right part of another domino,
    /// and a chain is considered when dominoes matching in a list and the first domino's left value should match with the last domino's right value.
    /// If a chain is not possible, the program outputs an appropriate message in the logger.
    /// </summary>
    public static class DominoHandler
    {
        public static List<Domino>? GetChain(string userInput)
        {
            var dominoes = userInput.ToDominos().ToList();

            if (dominoes is null || !dominoes.Any())
            {
                Logger.LogError("Input dominoes list is null or empty.");
                return null;
            }

            var result = FindDominoChain(dominoes);

            return result;
        }

        public static List<Domino>? FindDominoChain(List<Domino> dominoes)
        {
            if (dominoes.Count() == 1)
            {
                Logger.LogError("Input dominoes list contains only one element");
                return null;
            }

            try
            {
                foreach (var startDomino in dominoes)
                {
                    Logger.LogInfo($"Building chain starting with domino: {startDomino}");

                    var result = TrySortDominoChain(dominoes, startDomino);

                    if (result != null)
                        return result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error occured: {ex.Message}");
                throw;
            }

            Logger.LogError($"No valid domino chain found.");

            return null;
        }

        public static List<Domino>? TrySortDominoChain(List<Domino> dominoes, Domino startingDomino)
        {
            Logger.LogInfo($"Trying to build chain with starting domino: {startingDomino}");

            var dominoChain = new List<Domino> { startingDomino };
            var remainingDominoes = new HashSet<Domino>(dominoes);
            remainingDominoes.Remove(startingDomino);

            while (remainingDominoes.Count > 0)
            {
                var lastDomino = dominoChain.LastOrDefault();

                if (lastDomino == null)
                {
                    Logger.LogError("Chain is empty");

                    return null;
                }

                var nextDomino = remainingDominoes.FirstOrDefault(domino => domino.Left == lastDomino.Right || domino.Right == lastDomino.Right);

                if (nextDomino == null)
                {
                    Logger.LogWarning($"No matching domino found for last domino: {lastDomino}");

                    return null;
                }

                Logger.LogInfo($"Matching the domino in the correct orientation");

                var matchedDomino = lastDomino.Right == nextDomino.Left ? nextDomino : nextDomino.Flip();
                dominoChain.Add(matchedDomino);
                remainingDominoes.Remove(nextDomino);

                Logger.LogInfo($"Added domino to chain: {matchedDomino}");
            }

            bool isCircular = dominoChain.First().Left == dominoChain.Last().Right;
            if (!isCircular)
            {
                Logger.LogWarning("Chain is not circular");
                return null;
            }

            Logger.LogInfo("Chain successfully built as circular");
            return dominoChain;
        }
    }
}
