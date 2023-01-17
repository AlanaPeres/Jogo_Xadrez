using System;
using Jogo_Xadrez.board;
using Jogo_Xadrez;
using Jogo_Xadrez.play;
using System.Security.Cryptography;

namespace Jogo_Xadrez
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board Tab = new Board(8, 8);

            try
            {
                Match partida = new Match();
                Print.PrintBoard(partida.Tab);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }


            Console.ReadLine();
        }
    }
}
