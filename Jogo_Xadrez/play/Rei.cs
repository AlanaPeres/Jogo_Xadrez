using Jogo_Xadrez.board;
using System;


namespace Jogo_Xadrez
{
    class Rei : ChessPieces //
    {
        public Rei(Board tab,Color cor) : base(tab,cor)
        {

        }

        public override string ToString()
        {
            return "R";
        }

    }
}
