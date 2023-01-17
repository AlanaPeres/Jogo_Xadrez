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
                for(int j = 0; j < Tab.Colunas; j++) 
                {
                    if(Tab.Peca(i,j) == null) // se não houver nenhuma peça na minha matriz eu imprimo um traço.
                    {
                        Console.Write("- ");
                    }
                    else // senão eu imprimo a peça 
                    {
                        Console.Write(Tab.Peca(i, j) + " ");
                    }

                }
                Console.WriteLine();
            }
        }
    }
}
