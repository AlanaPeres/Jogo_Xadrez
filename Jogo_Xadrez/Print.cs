using System;
using System.Collections.Generic;
using System.Threading;
using Jogo_Xadrez.board;
using Jogo_Xadrez.play;
namespace Jogo_Xadrez
{
    internal class Print
    {

        public static void PrintBoard(Board Tab) 
        {
            for (int i = 0; i < Tab.Linhas; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(8 - i + " "); // para imprimir o número das linhas.
                Console.ResetColor();
                for(int j = 0; j < Tab.Colunas; j++) 
                {                   
                        Print.PrintPieces(Tab.Peca(i, j));
                      
                }
                Console.WriteLine();
                
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  a b c d e f g h ");
            Console.ResetColor();

        }

        public static void PrintBoard(Board Tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundo = Console.BackgroundColor;
            ConsoleColor corDeFundoAlterada = ConsoleColor.DarkGreen;
            for (int i = 0; i < Tab.Linhas; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(8 - i + " "); // para imprimir o número das linhas.
                Console.ResetColor();
                for (int j = 0; j < Tab.Colunas; j++)
                {

                    if (posicoesPossiveis[i,j] == true) // se a posição estiver marcada como uma posição possível de movimento o fundo é alterado.
                    {
                        Console.BackgroundColor = corDeFundoAlterada;
                    }else
                    {
                        Console.BackgroundColor = fundo;
                    }

                    Print.PrintPieces(Tab.Peca(i, j));

                    Console.BackgroundColor = fundo;

                }
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  a b c d e f g h ");
            Console.ResetColor();
            Console.BackgroundColor = fundo;

        }



        // Lê o que o usuário digitar (letra e numero)
        public static ChessPosition ReadPosition()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");// "" força a converter para string

            //if (coluna != 'a' || coluna != 'b' || coluna != 'c' || coluna !=  'd' || coluna != 'e' || coluna != 'f' || coluna != 'g' || coluna != 'h')
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    throw new BoardException("\nPosição inválida, tente novamente.");
            //    Console.ResetColor();
            //}
            //if (linha != 1 || linha != 2 || linha != 3 || linha != 4 || linha != 5 || linha != 6 || linha != 7 || linha != 8 )
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    throw new BoardException("\nPosição inválida, tente novamente.");
            //    Console.ResetColor();

            //}
            return new ChessPosition(coluna, linha);

        }

        public static void PrintPieces(ChessPieces peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {

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
                Console.Write(" ");
            }

        }


        public static void PrintMatch(Match partida)
        {
            Print.PrintBoard(partida.Tab);
            Console.WriteLine();
            PrintCapturedPieces(partida);
            Console.WriteLine("\n\nJOGADA " + partida.Play);

            if (!partida.TheEnd)
            {
                Console.WriteLine("Aguardando a jogada: " + partida.JogadorAtual);

                if (partida.Xeque)
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" _  _  ____   __   _  _  ____ ");
                    Console.WriteLine("( \\/ )(  __) /  \\ / )( \\(  __)");
                    Console.WriteLine(" )  (  ) _) (  O )) \\/ ( ) _) ");
                    Console.WriteLine("(_/\\_)(____) \\__\\)\\____/(____)");
                    Console.ResetColor();
                    Thread.Sleep(3000);
                }

            }
            else
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" _  _  ____   __   _  _  ____        _  _   __   ____  ____ ");
                Console.WriteLine("( \\/ )(  __) /  \\ / )( \\(  __) ___  ( \\/ ) / _\\ (_  _)(  __)");
                Console.WriteLine(" )  (  ) _) (  O )) \\/ ( ) _) (___) / \\/ \\/    \\  )(   ) _) ");
                Console.WriteLine("(_/\\_)(____) \\__\\)\\____/(____)      \\_)(_/\\_/\\_/ (__) (____)");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Vencedor: " + partida.JogadorAtual);
                Console.ResetColor();
                Thread.Sleep(3000);
                

            }

           
        }

        public static void PrintCapturedPieces(Match partida)
        {
            
            Console.WriteLine("Peças capturadas no jogo: ");
            Console.Write("Brancas: ");
            PrintCollection(partida.CapturedPieces(Color.Branca));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            PrintCollection(partida.CapturedPieces(Color.Preta));
            Console.ForegroundColor = aux;
            Console.WriteLine();
          
        }

        public static void PrintCollection(HashSet<ChessPieces> Collection)
        {

            foreach(ChessPieces x in Collection)
            {
                Console.Write(x + " ");
            }


        }
    }
}
