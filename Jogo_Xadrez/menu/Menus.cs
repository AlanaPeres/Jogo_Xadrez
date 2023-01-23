using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Jogo_Xadrez.menu
{
    internal class Menus
    {

        public static void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" _  _   __   ____  ____  ____  ____ ");
            Console.WriteLine("( \\/ ) / _\\ (    \\(  _ \\(  __)(__  )");
            Console.WriteLine(" )  ( /    \\ ) D ( )   / ) _)  / _/ ");
            Console.WriteLine("(_/\\_)\\_/\\_/(____/(__\\_)(____)(____)");
            Console.WriteLine();

            Console.ResetColor();
            Console.WriteLine("0 - Encerrar Programa");
            Console.WriteLine("1 - Criar um novo Jogador");
            Console.WriteLine("2 - Iniciar Partida");
            Console.WriteLine("3 - Mostrar Ranking");
            Console.WriteLine("4 - Excluir Jogador");
            Console.Write("\nDigite a opção desejada: ");
        }



    }
}
