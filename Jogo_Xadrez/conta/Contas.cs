using Jogo_Xadrez.board;
using Jogo_Xadrez.play;
using System;
using System.Collections.Generic;
using System.Threading;
using Jogo_Xadrez.menu;
using System.IO;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Jogo_Xadrez.conta
{
    internal class Contas
    {
       

        public string Nome { get; private set; } 
        public string Senha { get; private set; } 
        public int Pontos { get; set; }


        public Contas(string nome, string senha, int pontos)
        {
            Nome = nome;
            Senha = senha;
            Pontos = pontos;


        }

        public override string ToString()
        {
            return $"User: {Nome} | Pontos {Pontos}";
        }

        static void SerelizarJson(List<Contas>Jogadores, string filePath)
        {
            string jsonString = JsonSerializer.Serialize(Jogadores);
            File.WriteAllText(filePath, jsonString);
        }


        public static void  Register(List<Contas> Jogadores, string filePath)
        {
            Console.WriteLine("Escolha um nome de usuário");
            string nome = Console.ReadLine();
            Console.WriteLine("Escolha uma senha de acesso:");
            string senha = Console.ReadLine();
            int pontos = 0;
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
                Contas novaConta = new Contas(nome, senha, pontos);
                Jogadores.Add(novaConta);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Jogador cadastrado com sucesso! ");
                Console.ResetColor();
                Thread.Sleep(2000);
                SerelizarJson(Jogadores, filePath);



            }

            
        }
       

        public static void Login(List<Contas> Jogadores, string filePath)
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

            if(buscarIndex != -1 && buscaIndex2 != -1)
            {
                Match.Jogador1 = jogador1;

                Match.Jogador2 = jogador2;

                Match.StartPlay(Jogadores);
            }
            else
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Não foi possível inicar partida.");
                Console.WriteLine("Usuário não encontrado. Volte e cadastre os jogadores.");
                Console.ResetColor();
                Thread.Sleep(3000);


            }


        }

        public static void ShowUser(List<Contas> Jogadores, string filePath)
        {
            Jogadores.ForEach(x => Console.WriteLine($"Jogador {x.Nome} | Pontos: {x.Pontos}"));
        }

        public static void Ranking(List<Contas> Jogadores, string filePath)
        {
            Console.Clear();
            int[] pontos = new int[Jogadores.Count];
            List<string> list = new List<string>();


            for(int i = 0; i < Jogadores.Count; i++)
            {
                pontos[i] = Jogadores[i].Pontos;
                list.Add(Jogadores[i].Nome);
            }

            Array.Sort(pontos);
            Array.Reverse(pontos);

            for(int j = 0; j < Jogadores.Count; j++)
            {
                int index = Jogadores.FindIndex(x => x.Pontos == pontos[j] && list.Exists(jogador => x.Nome == jogador));
                Console.WriteLine($"Jogador(a): {Jogadores[index].Nome} |Pontos Acumulados: {pontos[j]}  ");
                list.Remove(Jogadores[index].Nome);
                
            }

            Thread.Sleep(3000);
        }

        public static void DeleteUser(List<Contas> Jogadores, string filePath)
        {
            Console.Clear();
            Console.WriteLine("\n DELETAR USUÁRIO \n");
            Console.WriteLine("User a ser Deletado: ");
            string UserDeletado = Console.ReadLine();
            Console.WriteLine("Senha: ");
            string senha =  Console.ReadLine();
            int buscarIndex = Jogadores.FindIndex(x => x.Nome == UserDeletado && Jogadores.Exists(y => y.Senha == senha));


            if(buscarIndex != -1 )
            {
                Contas deletar = Jogadores.Find(x => x.Nome == UserDeletado);
                Jogadores.Remove(deletar);
                SerelizarJson(Jogadores, filePath);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Usuário deletado com sucesso.");
                Console.ResetColor();
                Thread.Sleep(3000);

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Não foi possível deletar esta conta.");
                Console.WriteLine("MOTIVO: Usuário ou senha incorretos.");
                Console.ResetColor();
                Thread.Sleep(3000);
            }
        }
    }
}
