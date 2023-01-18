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

        public ChessPieces Peca(Position pos)
        {
            return Matriz[pos.Linha, pos.Coluna];
        }

        
        public void InsertPiece(ChessPieces p, Position pos)
        {
            if (ThereIsChessPiece(pos))
            {

                throw new BoardException("Já existe uma peça nessa posição");
            }
            Matriz[pos.Linha, pos.Coluna] = p;

            p.Position = pos;
        }

        public ChessPieces RemovePiece(Position pos)
        {   
            // caso não tenha nenhuma peça na posição informada, não retorna nada.
            if(Peca(pos) == null)
            {
                return null;
            }
            // caso tenha alguma peça nesta posição eu jogo a peça encontrada para a variável aux e no lugar desta peça a posição volta a ser nula.
            ChessPieces aux = Peca(pos);

            aux.Position = null;

            Matriz[pos.Linha, pos.Coluna] = null;

            return aux;
        }
        //Verifica se a posição recebida é válida.
        public bool ReadPosition(Position pos)
        {
            if(pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna < 0 || pos.Coluna>= Colunas)
            {
                return false;
            }
                

            return true;
        }

        //Recebe uma posição que não é válida e lança uma excessão personalizada (BoardException)
        public void ValidatePosition(Position pos)
        {
            if(!ReadPosition(pos))
            {
                throw new BoardException("Posição inválida");
            }

        }

        //verifica se existe uma peça em determinada posição.

        public bool ThereIsChessPiece(Position pos)
        {
            ValidatePosition(pos);
            return Peca(pos) != null;

        }



    }
}
