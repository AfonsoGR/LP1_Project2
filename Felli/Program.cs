using System;

namespace Felli
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(5, 5);
            Renderer r = new Renderer(board);

            r.Render();
        }

    }
}
