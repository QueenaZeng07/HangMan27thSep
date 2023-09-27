using System;

namespace hang_man_person3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int NumTry = 6;
            Console.WriteLine(Result(NumTry));
        }


        public static string Result(int NumTry)
        {
            string result = "";
            if (NumTry < 12)
            {
                result = "This is your" + Convert.ToString(NumTry) + "try";
                NumTry = NumTry + 1;
            }
            else
            {
                result = "SORRY. GAME OVER";
            }

            return result;
        }
    }
    
}