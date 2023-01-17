using System;
using Jogo_Xadrez.board;
namespace Jogo_Xadrez
{
    internal class Print
    {

        public static void PrintBoard(Board Tab) 
        {
            for (int i = 0; i < Tab.Linhas; i++)
            {
                Console.Write(8 - i + " "); // para imprimir o número das linhas.

                for(int j = 0; j < Tab.Colunas; j++) 
                {
                    if(Tab.Peca(i,j) == null) // se não houver nenhuma peça na minha matriz eu imprimo um traço.
                    {
                        Console.Write("- ");
                    }
                    else // senão eu imprimo a peça 
                    {
                        Print.PrintPieces(Tab.Peca(i, j));
                        Console.Write(" ");
                    }

                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H ");
        }

        public static void PrintPieces(ChessPieces peca)
        {   // se a peça for branca, simplesmente imprime  a peça.
            if (peca.Cor == Color.Branca)
            {
                Console.Write(peca);
            }
            else
            {   //se não for branca, imprime Cyan.
                ConsoleColor aux = Console.ForegroundColor;

                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.Write(peca);

                Console.ForegroundColor = aux;

            }
        }
    
    }
}
