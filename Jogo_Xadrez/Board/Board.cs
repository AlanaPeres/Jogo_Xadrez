using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogo_Xadrez.board
{
    internal class Board
    {

        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private ChessPieces[,] Matriz;



        public Board(int linhas, int colunas) 
        {
            Linhas= linhas;
            Colunas= colunas;
            Matriz = new ChessPieces[Linhas, Colunas];
        }

        public ChessPieces Peca(int linha, int coluna)
        {
            return Matriz[linha, coluna];
        }


    }
}
