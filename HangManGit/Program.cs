using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Schema;

namespace hngmban
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string tobeguessed = "";
            Console.WriteLine(
                "choose difficulty, write easy for easy, medium for medium, and hard for hard. and if you do none of the above you'll have to run this code again.");
            string difficulty = Console.ReadLine();
            Console.WriteLine(chooseWord(difficulty, tobeguessed));



            int guesses = 0;
            char guess = 'a';
            int numTry = guesses;
            int l = tobeguessed.Length;
            string[] indexes = { "" };
            for (int n = 0; n < l; n++) ;
            {
                indexes[n] = "_";
            }
            Console.WriteLine(indexes);

            bool stop = false;
            if (stop == false)
            { Console.WriteLine(Guess(tobeguessed, guess));
                Console.WriteLine(Result(numTry));
                Console.WriteLine(UpdateGallows(guesses));
                Console.WriteLine("Have you got the word?");
                string word = Console.ReadLine();
                if (word == tobeguessed)
                {
                    stop = true;
                }
                else
                {
                    stop = false;
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


        public static string[] Guess(string wordd, char guess)
        {
            Console.WriteLine("please guess a letter");
            
            string[] indexes = new string[wordd.Length];
            for (int i = 0; i < wordd.Length; i++)
            {
                if (wordd[i] == guess)
                {
                    string index = Convert.ToString(i);
                    indexes[i] = index;
                    Console.WriteLine(indexes[i]);
                }
            }
            return indexes;
        }
    }
}