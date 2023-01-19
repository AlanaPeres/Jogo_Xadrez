using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogo_Xadrez.menu
{
    internal class Menus
    {

        public static void ShowMenu()
        {
            Console.WriteLine("Bem vindo(a) ao Jogo de Xadrez\n\n");

            Console.WriteLine("0 - Encerrar Programa");

            Console.WriteLine("1 - Criar um novo Jogador");

            Console.WriteLine("2 - Iniciar Partida");

            Console.WriteLine("3 - Mostrar Ranking");

            Console.WriteLine("4 - Excluir Jogador");

            Console.Write("\nDigite a opção desejada: ");
        }



    }
}
