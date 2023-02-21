namespace Hangman
{
    internal class Program
    {
        static string correctWord = "hangman";
        static char[]? letters;
        static Player player;

        static void Main(string[] args)
        {
            try
            {
            StartGame();
            PlayGame();
            EndGame();

            }
            catch (Exception)
            {
                Console.WriteLine("Oops!");
            }
           
        }
        static void StartGame()
        {
            letters = new char[correctWord.Length];
            for (int i = 0; i < correctWord.Length; i++)
                letters[i] = '-';
            AskForUsersName();
        }

        static void AskForUsersName()
        {
            Console.WriteLine("Please enter your name: ");
            string input = Console.ReadLine()!;

            if (input.Length >= 2)
            {
                player = new Player(input);
                Console.WriteLine($"Hello {input}");
            }
            else
            {
                Console.WriteLine("Name needs to be at least 2 charachters");
                AskForUsersName();
            }
        }
        static void PlayGame()
        {
            do
            {
                Console.Clear();
                DisplayMaskedWord();
                char guessedLetter = AskForLetter();
                CheckLetter(guessedLetter);
            } while (correctWord != new string(letters));

            Console.Clear();
        }

        private static void CheckLetter(char guessedLetter)
        {
            for (int i = 0; i < correctWord.Length; i++)
            {
                if (guessedLetter == correctWord[i])
                {
                    letters![i] = guessedLetter;
                    player.Score++;
                }
            }
        }

        static void DisplayMaskedWord()
        {
            Console.WriteLine("What is the word?");
            foreach (char c in letters!)
                Console.Write(c);
            Console.WriteLine();
        }
        static char AskForLetter()
        {
            string input;
            do
            {
                Console.WriteLine("Enter a letter:");
                input = Console.ReadLine()!;
            } while (input.Length != 1);

            var letter = input[0];

            if (!player.GuessedLetters.Contains(letter))
                player.GuessedLetters.Add(letter);

            return letter;
        }
        static void EndGame()
        {
            Console.WriteLine("Game Over!");
            Console.WriteLine($"Thanks for playing {player.Name}");
            Console.WriteLine($"Your guesses: {player.GuessedLetters.Count} Your Score: {player.Score}");
        }
    }
}