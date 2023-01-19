using System;
using Jogo_Xadrez.board;
using Jogo_Xadrez;
using Jogo_Xadrez.play;
using Jogo_Xadrez.menu;
using Jogo_Xadrez.conta;
using System.Collections.Generic;
using System.Threading;

namespace Jogo_Xadrez
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Contas> Jogadores = new List<Contas>();

            int opt = 0;
            

            do
            {
                Console.Clear();

                Menus.ShowMenu();

                bool converterEntrada = int.TryParse(Console.ReadLine(), out opt);


                switch (opt)
                {
                    case 0:

                        Console.WriteLine("O programa esta sendo encerrado. Volte sempre!! ");

                        break;
                    case 1:

                        Contas.Register(Jogadores);
                       

                        break;

                    case 2:

                        Contas.Login(Jogadores);

                        

                        break;

                        case 3:

                        //mostrar ranking
                        break;


                    case 4:
                        //excluir resetar jogador.
                        break;

                       default:

                                 
                                 Console.ForegroundColor = ConsoleColor.Red;

                                 Console.WriteLine("Opção inválida, tente novamente.");

                                 Console.ResetColor();

                                 Thread.Sleep(3000);
                        break;



                }




            } while (opt != 0);

            
        }
    }
}
