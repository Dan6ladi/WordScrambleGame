namespace WordScrambleGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "programming", "developer", "keyboard", "monitor", "computer" };
            Word word = new Word(words);
            word.StartGame();
            Console.ReadLine();
        }
    }
}
