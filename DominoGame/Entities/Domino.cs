
namespace DominoGame.Entities
{
    public class Domino
    {
        public int Left { get; set; }

        public int Right { get; set; }

        public Domino() { }

        public Domino(int left, int right)
        {
            Left = left;
            Right = right;
        }

        /// <summary>
        /// Reverses the positions of the Left and Right integers. 
        /// </summary>
        public Domino Flip()
        {
            return new Domino(Right, Left);
        }

        /// <summary>
        /// Converts the Domino  Left and Right integer values to string.
        /// </summary>
        /// <returns>The string representation of the Domino in Left|Right manner. Example 1|2. </returns>
        public override string ToString()
        {
            return $"{Left}|{Right}";
        }
    }
}
