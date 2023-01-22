using System;
using Jogo_Xadrez.board;
using System.Threading.Tasks;

namespace Jogo_Xadrez.play
{
    class Cavalo : ChessPieces
    {
        private Match Partida;
        public Cavalo(Board tab, Color cor, Match partida) : base(tab, cor)
        {
            Partida = partida;
        }

        public override string ToString() => "C";
       

        private bool MovimentoOk(Position pos)
        {
            ChessPieces p = Tab.Peca(pos);

            return p == null || p.Cor != Cor;

        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Position pos = new Position(0, 0);

            pos.DefinirValores(Position.Linha - 1, Position.Coluna - 2);
            if (Tab.ReadPosition(pos) && MovimentoOk(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }



            pos.DefinirValores(Position.Linha - 2, Position.Coluna - 1);
            if (Tab.ReadPosition(pos) && MovimentoOk(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }


            pos.DefinirValores(Position.Linha - 2, Position.Coluna +1);
            if (Tab.ReadPosition(pos) && MovimentoOk(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }


            pos.DefinirValores(Position.Linha - 1, Position.Coluna + 2);
            if (Tab.ReadPosition(pos) && MovimentoOk(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }


            pos.DefinirValores(Position.Linha + 1, Position.Coluna + 2);
            if (Tab.ReadPosition(pos) && MovimentoOk(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }


            pos.DefinirValores(Position.Linha +2, Position.Coluna + 1);
            if (Tab.ReadPosition(pos) && MovimentoOk(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }


            pos.DefinirValores(Position.Linha +2, Position.Coluna - 1);
            if (Tab.ReadPosition(pos) && MovimentoOk(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinirValores(Position.Linha + 1, Position.Coluna - 2);
            if (Tab.ReadPosition(pos) && MovimentoOk(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            return mat;
        }
    }

}