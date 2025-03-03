using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordScrambleGame
{
    public class Word
    {
        private string[] _words;
        private string _scrambledWord;
        private string _randomWord;
        private int _points;
        public string[] Words { get { return _words; } set { _words = value; } }
        public string ScrambledWord { get { return _scrambledWord; } set { _scrambledWord = value; } }
        public string RandomWord { get { return _randomWord; } set { _randomWord = value; } }

        public Word(string[] words)
        {
            _words = words;  
            _points = 0;
        }

        public void ScrambleWords()
        {
            Random rand = new Random();
            _randomWord = Words[rand.Next(Words.Length)];
            _scrambledWord = new string(_randomWord.ToCharArray().OrderBy(c => rand.Next()).ToArray());
        }

        public void DisplayResult()
        {
            Console.Write("Congratulations! ");
            Console.Write($"Total Points: {_points * 10} ");
        }

        public void StartGame()
        {
            ScrambleWords();
            Console.WriteLine("Welcome to the Word Scramble Game!");
            for (int i = 0; i < Words.Length; i++)
            {
                DisplayScrambledWords();
            }
            DisplayResult();
        }

        public void DisplayScrambledWords()
        {
            ScrambleWords();
            Console.WriteLine($"Unscramble this word: {ScrambledWord}");
            GetUserGuess();
        }

        public void GetUserGuess()
        {
            Console.Write("Your Guess: ");
            string userGuess = Console.ReadLine();
            while (!userGuess.Equals(_randomWord, StringComparison.OrdinalIgnoreCase))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong. Try again!");
                switch (_randomWord.ToLower())
                {
                    case "Programming":
                        Console.WriteLine("Hint: telling your computer what to do in a language it understands.");
                        break;
                    case "Computer":
                        Console.WriteLine("Hint: an electronic device.");
                        break;
                    case "developer":
                        Console.WriteLine("Hint: a person that writes programs");
                        break;
                    case "monitor":
                        Console.WriteLine("Hint: an output device that displays visuals");
                        break;
                    case "keyboard":
                        Console.WriteLine("Hint: an input device that allows you to type.");
                        break;
                    default:
                        Console.WriteLine("Hint: No hint available for this word.");
                        break;
                };                 
                Console.ResetColor();
                Console.Write("Your Guess: ");
                userGuess = Console.ReadLine();
            }
            if (userGuess.Equals(_randomWord, StringComparison.OrdinalIgnoreCase))
            {
                _points++;
                int points = _points * 10;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Correct! You have earned {points} points.");
                Console.ResetColor();
            }

        }
    }
}
