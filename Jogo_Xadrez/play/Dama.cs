using System;
using Jogo_Xadrez.board;

namespace Jogo_Xadrez.play
{
    class Dama : ChessPieces
    {
        public Dama(Board tab, Color cor) : base(tab, cor)
        {

        }

        public override string ToString()
        {
            return "D";
        }

        private bool MovimentoOk(Position pos)
        {
            ChessPieces p = Tab.Peca(pos);

            return p == null || p.Cor != Cor;

        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Position pos = new Position(0, 0);

            //Esquerda
            pos.DefinirValores(Position.Linha, Position.Coluna - 1);
            while(Tab.ReadPosition(pos) && MovimentoOk(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;

                if(Tab.Peca(pos) != null && Tab.Peca(pos).Cor != this.Cor)
                {
                    break;
                }

                pos.DefinirValores(pos.Linha, pos.Coluna - 1);
            }
            
            //Direita
            pos.DefinirValores(Position.Linha, Position.Coluna + 1);
            while (Tab.ReadPosition(pos) && MovimentoOk(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;

                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != this.Cor)
                {
                    break;
                }

                pos.DefinirValores(pos.Linha, pos.Coluna + 1);
            }


            // acima
            pos.DefinirValores(Position.Linha -1 , Position.Coluna);
            while (Tab.ReadPosition(pos) && MovimentoOk(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;

                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != this.Cor)
                {
                    break;
                }

                pos.DefinirValores(pos.Linha -1 , pos.Coluna);
            }

            //Abaixo
            pos.DefinirValores(Position.Linha + 1, Position.Coluna);
            while (Tab.ReadPosition(pos) && MovimentoOk(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;

                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != this.Cor)
                {
                    break;
                }

                pos.DefinirValores(pos.Linha, pos.Coluna + 1);
            }

            //Noroeste
            pos.DefinirValores(Position.Linha - 1, Position.Coluna -1);
            while (Tab.ReadPosition(pos) && MovimentoOk(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;

                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != this.Cor)
                {
                    break;
                }

                pos.DefinirValores(pos.Linha -1, pos.Coluna - 1);
            }

            //Nordeste
            pos.DefinirValores(Position.Linha - 1, Position.Coluna + 1);
            while (Tab.ReadPosition(pos) && MovimentoOk(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;

                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != this.Cor)
                {
                    break;
                }

                pos.DefinirValores(pos.Linha - 1 , pos.Coluna + 1);
            }

            //Sudestes
            pos.DefinirValores(Position.Linha + 1, Position.Coluna + 1);
            while (Tab.ReadPosition(pos) && MovimentoOk(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;

                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != this.Cor)
                {
                    break;
                }

                pos.DefinirValores(pos.Linha +1, pos.Coluna + 1);
            }

            //Sudoeste 
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
