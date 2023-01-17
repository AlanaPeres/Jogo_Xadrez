using System;
using Jogo_Xadrez.board;


namespace Jogo_Xadrez
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board Tab = new Board(8, 8);
            Print.PrintBoard(Tab);
        }
    }
}
