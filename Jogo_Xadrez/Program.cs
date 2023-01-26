using System;
using Jogo_Xadrez.board;
using Jogo_Xadrez;
using Jogo_Xadrez.play;
using Jogo_Xadrez.menu;
using Jogo_Xadrez.conta;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Data;
using System.Web.Script.Serialization;
using System.Web.Configuration;
using Newtonsoft.Json;
using System.Security.Principal;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Linq.Expressions;

namespace Jogo_Xadrez
{
    internal class Program
    {

        static void ReadList(List<Contas>Jogadores, string filePath)
        {
            dynamic stringJson = File.ReadAllText(filePath);
            if(!String.IsNullOrEmpty(stringJson))
            {
                    List<Contas> todosJogadores = JsonSerializer.Deserialize<List<Contas>>(stringJson);
                    todosJogadores.ForEach(usuario => Jogadores.Add(usuario));
              
            }
            
        }

        static void Main(string[] args)
        {
            List<Contas> Jogadores = new List<Contas>();
          
            string rootPath = @"C:\Users\alana\source\repos\Jogo_Xadrez\Jogo_Xadrez";
            string filePath = rootPath + "jogadores.json";
            ReadList(Jogadores, filePath);

            int opt = 0;

            do
            {
                Console.Clear();
                Menus.ShowMenu();
                bool converterEntrada = int.TryParse(Console.ReadLine(), out opt);

                switch (opt)
                {
                    case 0: Console.WriteLine("O programa esta sendo encerrado. Te espero em breve!! "); break;

                    case 1: Contas.Register(Jogadores, filePath); break;

                    case 2: Contas.Login(Jogadores, filePath); break;

                    case 3: Contas.Ranking(Jogadores, filePath); break;

                    case 4: Contas.DeleteUser(Jogadores, filePath); break;

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
