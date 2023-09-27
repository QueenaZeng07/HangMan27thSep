namespace UpdateGallows_Function
{
    internal class Program
    {
        static void Main(string[] args) {

            Console.WriteLine(UpdateGallows(0));

            static string UpdateGallows(int guesses) {


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
                
            }
        }
    }
