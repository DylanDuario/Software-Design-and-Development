using System;
using System.Collections.Generic;
using System.Linq;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            //[m1] Create List of Words to use for hangman
            List<string> words = new List<string>
            { 
                "Tree",
                "Dog",
                "Gorilla",
                "House",
                "Red",
                "Vintage",
                "Sour",
                "Twenty",
                "Ship",
                "Cat"
            };

            //[m2] Randomly pick from list
            Random R = new Random();
            string word = words[R.Next(words.Count)];

            //[m3] Give selected word to function
            HangMan(word);           
        }
        static void HangMan(string word)
        {
            //[h1] Lowers inputted string to lowercase
            word = word.ToLower();

            //[h2] Put all characters of string into a list
            List<char> letters = word.ToList();

            //[h3] Declare and initiate variables
            List<char> whitelist = new List<char> {' ' , ',', '.'};
            List<char> guessed = new List<char> { };
            int guesses = 8;

            while (true)
            {
                //[hc1] Output welcome and instructions
                Console.WriteLine("Welcome to HangMan!\nType in the blank and press enter to input a character" + 
                    "\nTry to guess correctly, or you'll lose a point...\nHave fun!\n===============");

                //[h4] For each char in letters, check if they're in guessed or whitelist and output
                foreach (char x in letters)
                {
                    if (guessed.Contains(x) || whitelist.Contains(x))
                    {
                        Console.Write(x);
                    }
                    else  
                    {
                        Console.Write("_");
                    }
                }

                //[h5] Output remaining guesses
                Console.Write("\nGuesses left: " + guesses);

                //[h6] Output guessed characters so far
                Console.Write("\nGuessed so far: ");
                foreach (char x in guessed)
                {
                    Console.Write(x + " ");
                }

                //[h7] Ask for user input
                Console.Write("\nInput a letter: ");

                //[h8] Check if input is char
                bool charTrue = false;
                char guessedChar = 'a';
                while (!charTrue)
                {
                    string input = Console.ReadLine().ToLower();
                    charTrue = char.TryParse(input, out guessedChar);
                }

                //[h9] Clear console
                Console.Clear();

                //[h10] if input is NOT in guessed
                if (!guessed.Contains(guessedChar))
                {
                    //[h11] Add input to guessed
                    guessed.Add(guessedChar);

                    //[h12] if input is NOT in letters
                    if (!letters.Contains(guessedChar))
                    {
                        //[h13] Reduce guesses by 1
                        guesses--;
                    }
                }

                //[h14] if chars in letters are have been guessed
                List<bool> done = new List<bool> { };
                foreach (char x in letters)
                {
                    if (guessed.Contains(x) || whitelist.Contains(x))
                    {
                        done.Add(true);
                    }
                    else 
                    {
                        done.Add(false);
                    }
                }
                if (!done.Contains(false))
                {
                    Console.WriteLine("You did it!\nThe word was: " + word);
                    break;
                }

                //[h15] if guesses is 0 or less
                if (guesses <= 0)
                {
                    Console.WriteLine("You failed...\nThe word was: " + word);
                    break;
                }
            }
        }
    }
}
