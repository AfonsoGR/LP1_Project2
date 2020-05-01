using System;

namespace Felli
{
    public class Player
    {
        public Player(ColorChoice color)
        {
            ColorChoice colorChoice = color; 
        }

        public void PieceSelection()
        {
            Console.WriteLine("There will be 2 players, choose amongst "
                + "you who will be Player 1 and Player 2. " 
                + "Player 1 will choose his pieces first.\n"
                + "Player 1 choose which pieces you want to use:"
                + "\n\t>> Press B for the Black pieces <<"
                + "\n\t>> Press W for the White pieces <<");
            
            string pieceChoice = Console.ReadLine();
        
            pieceChoice.ToLower();

            if (pieceChoice == "b")
            {
                Console.WriteLine(">> Player 1 will control the Black pieces\n"
                + ">> Player 2 will control the White pieces\n");

                Player player = new Player((ColorChoice)0);
            }
            else if (pieceChoice == "w")
            {
                Console.WriteLine(">> Player 1 will control the White pieces\n"
                + ">> Player 2 will control the Black pieces\n");

                Player player = new Player((ColorChoice)1);
            }
            else
            {
                Console.WriteLine(">>>> PLEASE SELECT A VALID OPTION <<<<");

                PieceSelection();
            }
        }

        public void OrderSelection()
        {
            Console.WriteLine("Who goes/plays first?" 
                + "\n\t>> The Black pieces <<"
                + "\n\t>> The White pieces <<");

            int orderChoice = Convert.ToInt32(Console.ReadLine());

            if (orderChoice == 1)
            {
                Console.WriteLine("Player 1 will go/play first.");
            }
            else if (orderChoice == 2)
            {
                Console.WriteLine("Player 2 will go/play first.");
            }
            else
            {
                Console.WriteLine(">>>> PLEASE SELECT A VALID OPTION <<<<");

                OrderSelection();
            }
        }        
    }
}