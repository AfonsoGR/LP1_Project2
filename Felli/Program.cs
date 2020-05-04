using System;

namespace Felli
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            GameLoop game;

            while (true)
            {
                game = new GameLoop();
                game.Start();

                Console.Clear();
                Console.WriteLine("Do you wish to play again?\nPress Y if " +
                    "you do any other key to leave");

                if (Console.ReadLine().ToUpper() != "Y")
                {
                    break;
                }
            }
        }
    }
}