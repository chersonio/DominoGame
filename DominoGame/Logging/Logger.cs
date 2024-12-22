namespace DominoGame.Logging
{
    public static class Logger
    {
        public static void LogInfo(string message)
        {
            GetColorForLevel("Info: ", LogLevel.Info);
            Console.WriteLine(message);
        }

        public static void LogWarning(string message)
        {
            GetColorForLevel("Warning: ", LogLevel.Warning);
            Console.WriteLine(message);
        }
        public static void LogError(string message)
        {
            GetColorForLevel("Error: ", LogLevel.Error);
            Console.WriteLine(message);
        }

        private static void GetColorForLevel(string text, LogLevel logLevel)
        {
            if (logLevel == LogLevel.Error)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (logLevel == LogLevel.Warning)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.Write(text);
            Console.ResetColor();
        }

    }
}
