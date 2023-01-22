using System;
using Jogo_Xadrez.board;

namespace Jogo_Xadrez.play
{
    class Bispo : ChessPieces
    {
        private Match Partida;
        public Bispo(Board tab, Color cor, Match partida) : base(tab, cor)
        {
            Partida = partida;
        }

        public override string ToString()
        {
            return "B";
        }

        private bool MovimentoOk(Position pos)
        {
            ChessPieces p = Tab.Peca(pos);

            return p == null || p.Cor != Cor;

        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Position pos = new Position(0,0);

            //Bispo se move nas diagonais 

            pos.DefinirValores(Position.Linha - 1, Position.Coluna - 1);
            while(Tab.ReadPosition(pos) && MovimentoOk(pos)) 
            {
                mat[pos.Linha, pos.Coluna] = true;
                if(Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor )
                {
                    break;

                }

                pos.DefinirValores(pos.Linha - 1, pos.Coluna - 1);

            }

            
            pos.DefinirValores(Position.Linha - 1, Position.Coluna + 1);
            while (Tab.ReadPosition(pos) && MovimentoOk(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != this.Cor)
                {
                    break;

                }

                pos.DefinirValores(pos.Linha - 1, pos.Coluna + 1);

            }

            pos.DefinirValores(Position.Linha + 1, Position.Coluna + 1);
            while (Tab.ReadPosition(pos) && MovimentoOk(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != this.Cor)
                {
                    break;

                }

                pos.DefinirValores(pos.Linha + 1, pos.Coluna + 1);

            }

            
            pos.DefinirValores(Position.Linha + 1, Position.Coluna - 1);
            while (Tab.ReadPosition(pos) && MovimentoOk(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != this.Cor)
                {
                    break;

                }

                pos.DefinirValores(pos.Linha + 1, pos.Coluna - 1);

            }

            return mat;

        }

    }
    
    
}
