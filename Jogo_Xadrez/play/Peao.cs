using System;
using Jogo_Xadrez.board;

namespace Jogo_Xadrez.play
{
    internal class Peao : ChessPieces
    {
        private Match Partida;
        public Peao(Board tab, Color cor, Match partida) : base(tab, cor)
        {
           Partida = partida;
        }

        public override string ToString() => "P";
        

       private bool  ExisteInimigo(Position pos)
        {
            ChessPieces p = Tab.Peca(pos);

            return p != null && p.Cor != Cor;


        }


        private bool Livre(Position pos) => Tab.Peca(pos) == null;
       

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Position pos = new Position(0, 0);

            if (Cor == Color.Branca)
            {
                pos.DefinirValores(Position.Linha - 1, Position.Coluna);
                if(Tab.ReadPosition(pos) && Livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Position.Linha - 2, Position.Coluna);
                Position p2 = new Position(Position.Linha - 1, Position.Coluna);   
                if(Tab.ReadPosition(p2) && Livre(p2) && Tab.ReadPosition(pos) && Livre(pos) && QuantidadeMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Position.Linha - 1, Position.Coluna - 1);
                if (Tab.ReadPosition(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;

                }

                pos.DefinirValores(Position.Linha - 1, Position.Coluna + 1);
                if (Tab.ReadPosition(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;

                }


            }
            else
            {

                pos.DefinirValores(Position.Linha + 1, Position.Coluna);
                if (Tab.ReadPosition(pos) && Livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;

                }

                pos.DefinirValores(Position.Linha + 2, Position.Coluna);
                Position p2 = new Position(Position.Linha + 1, Position.Coluna);
                if (Tab.ReadPosition(p2) && Livre(p2) && Tab.ReadPosition(pos) && Livre(pos) && QuantidadeMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }


                pos.DefinirValores(Position.Linha + 1, Position.Coluna - 1);
                if (Tab.ReadPosition(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;

                }


                pos.DefinirValores(Position.Linha + 1, Position.Coluna + 1);
                if (Tab.ReadPosition(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;

                }
            }

            return mat;
        }
    }
}
