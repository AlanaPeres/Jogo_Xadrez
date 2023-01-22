using System;
using Jogo_Xadrez.board;

namespace Jogo_Xadrez.play
{
    class Dama : ChessPieces
    {
        private Match Partida;
        public Dama(Board Tab, Color cor, Match partida) : base(Tab, cor)
        {
            Partida = partida;
        }

        public override string ToString() => "D";
        

        private bool MovimentoOk(Position pos)
        {
            ChessPieces p = Tab.Peca(pos);

            return p == null || p.Cor != Cor;

        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Position pos = new Position(0, 0);

            //acima
            pos.DefinirValores(Position.Linha - 1, Position.Coluna);
            while (Tab.ReadPosition(pos) && MovimentoOk(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                //se em alguma das casas eu encontrar uma peça adviversária eu forço a parada do while.
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor)
                {
                    break;
                }
                //caso eu não encontre outra peça adversária eu continuo verificando acima.
                pos.DefinirValores(pos.Linha - 1, pos.Coluna);


            }


            //abaixo
            pos.DefinirValores(Position.Linha + 1, Position.Coluna);
            while (Tab.ReadPosition(pos) && MovimentoOk(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                //se em alguma das casas eu encontrar uma peça adviversária eu forço a parada do while.
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor)
                {
                    break;
                }
                //caso eu não encontre outra peça adversária eu continuo verificando abaixo.
                pos.DefinirValores(pos.Linha + 1, pos.Coluna);
            }


            //direita
            pos.DefinirValores(Position.Linha, Position.Coluna + 1);
            while (Tab.ReadPosition(pos) && MovimentoOk(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                //se em alguma das casas eu encontrar uma peça adviversária eu forço a parada do while.
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor)
                {
                    break;
                }
                //caso eu não encontre outra peça adversária eu continuo verificando a direita
                pos.DefinirValores(pos.Linha, pos.Coluna + 1);
            }


            //esquerda
            pos.DefinirValores(Position.Linha, Position.Coluna - 1);
            while (Tab.ReadPosition(pos) && MovimentoOk(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                //se em alguma das casas eu encontrar uma peça adviversária eu forço a parada do while.
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor)
                {
                    break;
                }

                pos.DefinirValores(pos.Linha, pos.Coluna - 1);
                //caso eu não encontre outra peça adversária eu continuo verificando a esquerda

            }

            //noroeste
            pos.DefinirValores(Position.Linha - 1, Position.Coluna - 1);
            while (Tab.ReadPosition(pos) && MovimentoOk(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor)
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
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor)
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
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor)
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
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor)
                {
                    break;

                }

                pos.DefinirValores(pos.Linha + 1, pos.Coluna - 1);

            }

            return mat;
        }
    }
}
