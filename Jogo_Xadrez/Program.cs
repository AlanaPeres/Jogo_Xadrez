using System;
using Jogo_Xadrez.board;
using Jogo_Xadrez;


namespace Jogo_Xadrez
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board Tab = new Board(8, 8);

            try
            {
                Tab.ColocarPeca(new Torre(Tab, Color.Preta), new Position(0, 0));
                Tab.ColocarPeca(new Torre(Tab, Color.Preta), new Position(1, 3));
                Tab.ColocarPeca(new Rei(Tab, Color.Preta), new Position(9, 2));

                Print.PrintBoard(Tab);
            }catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }

            

            Console.ReadLine();
        }
    }
}
