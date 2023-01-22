using Jogo_Xadrez.board;
using System;


namespace Jogo_Xadrez.play
{
    class Rei : ChessPieces 
    {
        private Match Partida;
        public Rei(Board tab,Color cor, Match partida) : base(tab,cor)
        {
            Partida = partida;
        }

        public override string ToString() => "R";
       

        private bool MovimentOk(Position pos)
        {
            ChessPieces p = Tab.Peca(pos);
            return p == null || p.Cor != this.Cor; // o método retorna se a posição está nula ou se possui alguma peça adversária, somente nessas hipóteses o rei pode se movimentar.
        }



        //uso o override para indicar que eu estou sobreescrevendo o método da super classe aqui.
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Position pos = new Position(0,0);


            //acima
            pos.DefinirValores(Position.Linha - 1, Position.Coluna);
            if (Tab.ReadPosition(pos) && MovimentOk(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //nordeste
            pos.DefinirValores(Position.Linha - 1, Position.Coluna + 1);
            if (Tab.ReadPosition(pos) && MovimentOk(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }


            //direita
            pos.DefinirValores(Position.Linha, Position.Coluna+ 1);
            if (Tab.ReadPosition(pos) && MovimentOk(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }


            //sudeste
            pos.DefinirValores(Position.Linha + 1, Position.Coluna + 1);
            if (Tab.ReadPosition(pos) && MovimentOk(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }



            //abaixo
            pos.DefinirValores(Position.Linha + 1, Position.Coluna);
            if (Tab.ReadPosition(pos) && MovimentOk(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }


            //sudoeste
            pos.DefinirValores(Position.Linha + 1, Position.Coluna - 1);
            if (Tab.ReadPosition(pos) && MovimentOk(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }


            //esquerda
            pos.DefinirValores(Position.Linha, Position.Coluna - 1);
            if (Tab.ReadPosition(pos) && MovimentOk(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }


            //noroeste
            pos.DefinirValores(Position.Linha - 1, Position.Coluna - 1);
            if (Tab.ReadPosition(pos) && MovimentOk(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            return mat;

        }
    }
}

