namespace DominoGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WelcomeMessage();

            var defaultDominosInput = "[2|1], [2|3], [1|3]";

            Console.WriteLine($"Provide an array of positive int couples, using the following pattern ");
            Console.WriteLine($"{defaultDominosInput}");
            Console.WriteLine("Input empty to use default example.");

            var dominoInput = Console.ReadLine();

            var result = DominoHandler.GetChain(string.IsNullOrWhiteSpace(dominoInput) ? defaultDominosInput : dominoInput);

            Console.WriteLine();

            if (result == null)
            {
                Console.WriteLine("No valid circular domino chain found.");
            }
            else
            {
                Console.WriteLine("Circular domino chain:");
                Console.WriteLine(string.Join(" ", result));
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Introduction for fun
        /// </summary>
        private static void WelcomeMessage()
        {
            string[] introduction = {
                "Welcome to game DominoGame!",
                "A domino of games!",
                "Domino of game a!",
                "IKEA did not provide instructions.",
                "Well... not actually a game 'cause it is a one trick pony and it's self solving.",
                "Consider it an AI, in case you are a simple user.",
                "Everything is an AI nowadays.",
                "I 'm an AI,",
                "            you 're an AI,",
                "                           everybody is an AI!",
                "Anyway. Where was I..? Oh right!"
            };


            foreach (var line in introduction)
            {
                foreach (var c in line)
                {
                    if (Console.KeyAvailable)
                    {
                        Console.Clear();
                        break;
                    }

                    Thread.Sleep(40);
                    Console.Write(c);
                }
                if (Console.KeyAvailable)
                {
                    Console.Clear();
                    break;
                }

                Thread.Sleep(line.Count() * 8);

                Console.WriteLine();
            }
        }
    }
}
