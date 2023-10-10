using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Xml.Schema;

namespace hngmban
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string tobeguessed = "";
            Console.WriteLine("choose difficulty, write easy for easy, medium for medium, and hard for hard. and if you do none of the above you'll have to run this code again.");
            string difficulty = Console.ReadLine();
            tobeguessed = chooseWord(difficulty, tobeguessed);
            

            char[] underscore = new char[tobeguessed.Length];

            for (int i = 0; i < tobeguessed.Length; i++)
            {
                underscore[i] = '_';


            }

            int guesses = 0;
            char guess = 'a';
            


            bool stop = false;
            while (stop == false)
            {
                int numTry = guesses;
                



                Console.WriteLine(underscore);
                Console.WriteLine("input letter or word!");
                string guessed_word = Console.ReadLine();
                if (guessed_word.Length == 1)
                {
                    char guessed_lettr = char.Parse(guessed_word);
                    int[] indexesinword = Guess(tobeguessed, guessed_lettr);

                    if (indexesinword.Length > 0)
                    {
                        Console.WriteLine("your guess was correct");

                    }

                    for (int i = 0; i < indexesinword.Length; i++)
                    {
                        underscore[indexesinword[i]] = guessed_lettr;
                        Console.WriteLine(indexesinword[i]);

                    }

                    Console.WriteLine(underscore);
                }
                else {
                    if (guessed_word == tobeguessed)
                    {
                        stop = true;
                    }
                    else
                    {
                        stop = false;
                        Console.WriteLine(UpdateGallows(guesses));
                    }

                }








            }


        }

        public static string UpdateGallows(int guesses)
        {


            if (guesses == 0)
            {
                return ("");
            }

            else if (guesses == 1)
            {
                return ("  +---+\r\n  |   |\r\n      |\r\n      |\r\n      |\r\n      |\r\n=========");
            }

            else if (guesses == 2)
            {
                return ("  +---+\r\n  |   |\r\n  O   |\r\n      |\r\n      |\r\n      |\r\n=========");
            }

            else if (guesses == 3)
            {
                return ("  +---+\r\n  |   |\r\n  O   |\r\n  |   |\r\n      |\r\n      |\r\n=========");
            }

            else if (guesses == 4)
            {
                return ("  +---+\r\n  |   |\r\n  O   |\r\n /|   |\r\n      |\r\n      |\r\n=========");
            }
            else if (guesses == 5)
            {
                return ("  +---+\r\n  |   |\r\n  O   |\r\n /|\\  |\r\n      |\r\n      |\r\n=========");
            }
            else if (guesses == 6)
            {
                return ("  +---+\r\n  |   |\r\n  O   |\r\n /|\\  |\r\n /    |\r\n      |\r\n=========");
            }
            else
                return ("  +---+\r\n  |   |\r\n  O   |\r\n /|\\  |\r\n / \\  |\r\n      |\r\n=========");
        }


        public static string Result(int numTry)
        {
            string result = "";
            if (numTry < 12)
            {
                result = "This is your" + Convert.ToString(numTry) + "try";
                numTry = numTry + 1;
            }
            else
            {
                result = "SORRY. GAME OVER";
            }

            return result;
        }

        public static string GenEasywords()
        {
            string[] easywords = new string[3];
            easywords[0] = "shape";
            easywords[1] = "count";
            easywords[2] = "finds";
            Random rnd = new Random();
            return (easywords[rnd.Next(0, 3)]);
        }

        static string GenMedwords()
        {
            string[] medwords = new string[3];
            medwords[0] = "zebra";
            medwords[1] = "jungle";
            medwords[2] = "bedazzle";
            Random rnd = new Random();
            return (medwords[rnd.Next(0, 3)]);
        }

        static string GenHardwords()
        {
            string[] hardwords = new string[3];
            hardwords[0] = "zigzag";
            hardwords[1] = "melancholy";
            hardwords[2] = "croquet";
            Random rnd = new Random();
            return (hardwords[rnd.Next(0, 3)]);
        }




        static string chooseWord(string emh, string word)
        {
            if (emh == "easy")
            {
                word = GenEasywords();
            }
            else if (emh == "medium")
            {
                word = GenMedwords();
            }
            else if (emh == "hard")
            {
                word = GenHardwords();
            }
            else
            {
                Console.WriteLine("Invalid input");
            }

            Console.WriteLine(emh + " word chosen!");
            return word;

        }

        static string Gallows(int life)
        {
            //prints the gallows
            string[] gallows = new string[7];
            gallows[0] = "  +---+\n  |   |\n      |\n      |\n      |\n      |\n=========";
            gallows[1] = "  +---+\n  |   |\n  O   |\n      |\n      |\n      |\n=========";
            gallows[2] = "  +---+\n  |   |\n  O   |\n  |   |\n      |\n      |\n=========";
            gallows[3] = "  +---+\n  |   |\n  O   |\n /|   |\n      |\n      |\n=========";
            gallows[4] = "  +---+\n  |   |\n  O   |\n /|\\  |\n      |\n      |\n=========";
            gallows[5] = "  +---+\n  |   |\n  O   |\n /|\\  |\n /    |\n      |\n=========";
            gallows[6] = "  +---+\n  |   |\n  O   |\n /|\\  |\n / \\  |\n      |\n=========";
            return gallows[life];
        }

        public static string updateScreen(char guess, string screen, string correct)
        {
            string new_screen = "";
            for (int i = 0; i < correct.Length; i++)
            {
                if (correct[i] == guess)
                {
                    new_screen = new_screen + guess;
                }
                else
                {
                    new_screen = new_screen + screen[i];
                }
            }

            return
                new_screen;
        }

        static bool checkExists(char guess, HashSet<char> correct)
        {
            if (correct.Contains(guess))
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public static int[] Guess(string wordd, char guess)
        {
            Console.WriteLine("please guess a letter");

            int[] indexes = new int[wordd.Length];
            int indexesI = 0;


            for (int i = 0; i < wordd.Length; i++)
            {
                if (wordd[i] == guess)
                {

                    indexes[indexesI] = i;
                    indexesI++;
                    
                }
            }
            return indexes.Take(indexesI).ToArray(); // Return first indexesI items
        }
    }
}
