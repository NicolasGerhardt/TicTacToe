using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welocme to Tic-Tac-Toe!!");

            do
            {
                Console.WriteLine("Let's play a game!");
                Game game = new Game();
                game.Loop();
            } while (PlayAgain());
            Console.WriteLine("Good Bye!");
        }

        private static bool PlayAgain()
        {
            while (true)
            {
                Console.Write("Do you want to play another game? (y/n): ");
                char key = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if ("Yy".Contains(key))
                {
                    Console.Clear();
                    Console.WriteLine();
                    return true;
                }
                else if ("Nn".Contains(key))
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("type y for yes or n for no");
                }
            }
        }
    }
}
