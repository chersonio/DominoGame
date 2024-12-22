using DominoGame.Entities;
using DominoGame.Logging;

namespace DominoGame.Helpers
{
    public static class ExtentionMethods
    {
        /// <summary>
        /// Creates a collection of Dominoes from a string of comma ", " separated couples and "|" seperated int values.
        /// </summary>
        /// <param name="dominoTextInput">String of numbers ", " and "|" separated .</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<Domino> ToDominos(this string dominoTextInput)
        {
            if (string.IsNullOrWhiteSpace(dominoTextInput))
            {
                var errorMessage = "Cannot accept empty domino text input";
                Logger.LogError(errorMessage);
                throw new ArgumentNullException(nameof(dominoTextInput), errorMessage);
            }

            List<Domino> dominoResults = new List<Domino>();

            // Clean and separate with comma
            var textCouples = dominoTextInput.Replace("[", "").Replace("]", "").Trim(' ').Split(',');

            // Split rows into couples
            var dominoTextCouples = textCouples.Select(x => x.Split('|')).ToList();

            if (dominoTextCouples is null || dominoTextCouples.Count() == 0)
            {
                var errorMessage = "Cannot parse domino text input. Please check input following example: [1|2], [2|3], [3|1]";
                Logger.LogError(errorMessage);
                throw new ArgumentNullException(nameof(dominoTextInput), errorMessage);
            }

            try
            {
                // Create and populate Dominos list
                foreach (var textDominoCouple in dominoTextCouples)
                {
                    var errorMessage = "Value does not fall within the expected range. Please check input following example: [1|2], [2|3], [3|1]";
                    if (!int.TryParse(textDominoCouple.First(), out int left))
                        throw new ArgumentException(errorMessage, nameof(textDominoCouple));

                    if (!int.TryParse(textDominoCouple.Last(), out int right))
                        throw new ArgumentException(errorMessage, nameof(textDominoCouple));

                    dominoResults.Add(new Domino(left, right));
                }
                dominoResults = dominoTextCouples.Select(x => new Domino(int.Parse(x.First()), int.Parse(x.Last()))).ToList();
            }
            catch (Exception ex)
            {
                Logger.LogError("Error converting string to int values. Please check input following example: [1|2], [2|3], [3|1]");
                throw;
            }

            return dominoResults;
        }
    }
}
