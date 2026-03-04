using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Security.AccessControl;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GuessNumber
{
    internal class Program
    {
        int min = 0;
        int max = 0;
        int count = 0;
        int countGame = 0;
        int left = 0;
        int right = 100;
        int counter = 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public int? GetNumber()
        {
            int attempt = 10;
            for (int i = 0; i < 3; i++)
            {
                if (!int.TryParse(Console.ReadLine(), out attempt)
                    || attempt > right || attempt < left)
                    Console.WriteLine($"Input number from[{left};{right}]");
                else break;
                if (i == 2)
                {
                    Console.WriteLine("fuuuuuu");
                    return null;
                }
            }
            return attempt;
        }

        public bool CompareNumber(int attempt, int number)
        {
            if (number > attempt)
                Console.WriteLine("Your number is greater");
            else if (number < attempt)
                Console.WriteLine("Your number is less");
            else
            {
                Console.WriteLine("Your win!");
                return true;
            }
            return false;
        }

        public void PlayGame(int number)
        {
            while (true)
            {
                Console.WriteLine($"input number from [{left};{right}]");

                int? result = GetNumber();
                if (result == null)
                    return;
                int attempt = result.Value;
                bool flag = CompareNumber(attempt, number);
                if (flag == true)
                    break;
            }
        }
       
        static void Main(string[] args)
        {
            Random rnd = new Random();

            Program program = new Program();
            char answer = 'Y';
            do
            {
                int number = rnd.Next(program.left, program.right+1);
                program.PlayGame(number);
                Console.WriteLine("Play again?");
                answer = Convert.ToChar(Console.Read());
            } while (answer == 'y');
            //Console.WriteLine($"mon ={min} max = {max} avg={(double)count / countGame}");
        }
    }
}
