using System;
using Jogo_Xadrez.board;

namespace Jogo_Xadrez.play
{
    class Bispo : ChessPieces
    {
        public Bispo(Board tab, Color cor) : base(tab, cor)
        {

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

            //noroeste
            pos.DefinirValores(Position.Linha - 1, Position.Coluna - 1);
            while(Tab.ReadPosition(pos) && MovimentoOk(pos)) 
            {
                mat[pos.Linha, pos.Coluna] = true;
                if(Tab.Peca(pos) != null && Tab.Peca(pos).Cor != this.Cor )
                {
                    break;

                }

                pos.DefinirValores(pos.Linha - 1, pos.Coluna - 1);

            }

            //nordeste
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

            //sudeste
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

            //sudoeste
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
