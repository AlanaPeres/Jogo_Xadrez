using Jogo_Xadrez.board;
using System;


namespace Jogo_Xadrez.play
{
    class Torre : ChessPieces
    {
        private Match Partida;
        public Torre(Board tab, Color cor, Match partida) : base(tab, cor)
        {
            Partida = partida;
        }

        public override string ToString() => "T";
       
        private bool MovimentOk(Position pos)
        {
            ChessPieces p = Tab.Peca(pos);
            return p == null || p.Cor != this.Cor; // o método retorna se a posição está nula ou se possui alguma peça adversária, somente nessas hipóteses o rei pode se movimentar.
        }
        //uso o override para indicar que eu estou sobreescrevendo o método da super classe aqui.
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Position pos = new Position(0, 0);


            //acima
            pos.DefinirValores(Position.Linha - 1, Position.Coluna);

            while(Tab.ReadPosition(pos) && MovimentOk(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;

                //se em alguma das casas eu encontrar uma peça adviversária eu forço a parada do while.
                if(Tab.Peca(pos) != null && Tab.Peca(pos).Cor != this.Cor)
                {
                    break;
                }
                //caso eu não encontre outra peça adversária eu continuo verificando acima.
                pos.Linha = pos.Linha - 1;
            }


            //abaixo
            pos.DefinirValores(Position.Linha + 1, Position.Coluna);
            while (Tab.ReadPosition(pos) && MovimentOk(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                //se em alguma das casas eu encontrar uma peça adviversária eu forço a parada do while.
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != this.Cor)
                {
                    break;
                }
                //caso eu não encontre outra peça adversária eu continuo verificando abaixo.
                pos.Linha = pos.Linha + 1;
            }


            //direita
            pos.DefinirValores(Position.Linha, Position.Coluna + 1);
            while (Tab.ReadPosition(pos) && MovimentOk(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                //se em alguma das casas eu encontrar uma peça adviversária eu forço a parada do while.
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != this.Cor)
                {
                    break;
                }
                //caso eu não encontre outra peça adversária eu continuo verificando a direita
                pos.Coluna = pos.Coluna + 1;
            }


            //esquerda
            pos.DefinirValores(Position.Linha, Position.Coluna - 1);
            while (Tab.ReadPosition(pos) && MovimentOk(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                //se em alguma das casas eu encontrar uma peça adviversária eu forço a parada do while.
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != this.Cor)
                {
                    break;
                }
                //caso eu não encontre outra peça adversária eu continuo verificando a esquerda
                pos.Coluna = pos.Coluna - 1;
            }

            return mat;

        }
    }
}
