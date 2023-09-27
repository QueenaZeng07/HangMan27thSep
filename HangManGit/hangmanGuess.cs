using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Hangman_Guess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = ("queena");
            Console.WriteLine(word);

            Function(word, 'e');


            static Array Function(string wordd, char guess)
            {
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
}

	}
}
