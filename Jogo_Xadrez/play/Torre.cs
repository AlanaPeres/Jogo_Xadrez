using Jogo_Xadrez.board;
using System;


namespace Jogo_Xadrez.play
{
    class Torre : ChessPieces
    {
        public Torre(Board tab, Color cor) : base(tab, cor)
        {

        }

        public override string ToString()
        {
            return "T";
        }

    }
}
