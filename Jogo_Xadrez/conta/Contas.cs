using Jogo_Xadrez.board;
using Jogo_Xadrez.play;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Threading;
using Jogo_Xadrez.menu;

namespace Jogo_Xadrez.conta
{
    internal class Contas
    {

        public string Nome { get; private set; } 

        public string Senha { get; private set; } 

        public int Pontos { get; set; }


        public Contas(string nome, string senha)
        {
            Nome = nome;

            Senha = senha;

            Pontos = 0;


        }

        public static void Register(List<Contas> Jogadores)
        {
            Console.WriteLine("Escolha um nome de usuário");

            string nome = Console.ReadLine();

            Console.WriteLine("Escolha uma senha de acesso:");

            string senha = Console.ReadLine();

            Contas shearch = Jogadores.Find(x => x.Nome == nome);

            if(shearch != null )
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nome de usuário indisponível");
                Console.ResetColor();
                Thread.Sleep(3000);
            }
            else
            {
                Jogadores.Add(new Contas(nome, senha));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Jogador cadastrado com sucesso! ");
                Console.ResetColor();
                Thread.Sleep(3000);
            }

            
        }

        private static bool ConfirmarDados(List<Contas> Jogadores, string nome, string senha)
        {


            foreach (Contas x in Jogadores)
            {
                if (nome == x.Nome)
                {
                    return true;
                }

                if(senha == x.Senha)
                {
                    return true;
                }
                
            }
            return false;
        }

        public static void Login(List<Contas> Jogadores)
        {
            Console.WriteLine("\nPara iniciar uma nova partida é necessário dois jogadores. ");

            Console.WriteLine("Entre com o usuário de cada jogador: ");

            Console.WriteLine("\nLOGIN JOGADOR 1: ");

            string jogador1 = Console.ReadLine();


            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("\nLOGIN JOGADOR 2: ");

            string jogador2 = Console.ReadLine();

         
            Console.ResetColor();

            int buscarIndex = Jogadores.FindIndex(x => x.Nome == jogador1);

            int buscaIndex2 = Jogadores.FindIndex(x => x.Nome == jogador2);

            if(buscarIndex == -1 && buscaIndex2 == -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Não foi possível inicar partida.");
                Console.WriteLine("Usuário ou senha não encontrado. Volte e cadastre os jogadores.");
                Console.ResetColor();
                Thread.Sleep(3000);
            }
            else
            {

                Match.Jogador1 = jogador1;

                Match.Jogador2 = jogador2;

                Match.StartPlay(Jogadores);
            }
           


        }


    }
}
