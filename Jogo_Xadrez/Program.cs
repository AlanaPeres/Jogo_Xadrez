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


                while (!partida.TheEnd)
                {
                    try
                    {
                        Console.Clear();


                        Print.PrintMatch(partida);

                        //Print.PrintBoard(partida.Tab);

                        //Console.WriteLine();

                        //Console.WriteLine("Agora é a vez do jogador " + partida.Play);

                        //Console.WriteLine("Aguardando a jogada: " + partida.JogadorAtual);

                        Console.WriteLine();

                        Console.Write("Digite a posição de origem: ");
                        // a posição de origem recebe o método ler posição do teclado e  retorna uma posição da Matriz.

                        Position origem = Print.ReadPosition().ToPosition();

                        partida.ValidarPosicaoOrigem(origem);

                        //a partir da posição de origem eu pego todos os movimentos possívei e guardo dentro desta matriz.
                        bool[,] posicoesPossiveis = partida.Tab.Peca(origem).MovimentosPossiveis();

                        Console.Clear();

                        Print.PrintBoard(partida.Tab, posicoesPossiveis);


                        Console.Write("Digite a posição de Destino: ");

                        Position destino = Print.ReadPosition().ToPosition();

                        partida.ValidarPosicaoDestino(origem, destino);

                        //partida.ExecutarMovimento(origem, destino);

                        partida.ExecutarJogada(origem, destino);
                    }
                    catch(BoardException e)
                    {
                        Console.WriteLine(e.Message);

                        Console.ReadLine();

                    }
                    
                }

               

            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }


            Console.ReadLine();
        }
    }
}
