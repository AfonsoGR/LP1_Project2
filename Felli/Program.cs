using System;

namespace Felli
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creates a new GameRules
            GameRules rules = new GameRules();
            rules.GR();

            GameLoop game = new GameLoop();
            game.Start();
        }
    }
}
