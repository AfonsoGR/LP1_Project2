using System;

namespace Felli
{
    class Program
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
                    "you do, press any other key to leave");

                if (Console.ReadLine().ToUpper() != "Y")
                {
                    break;
                }
            }
        }
    }
}