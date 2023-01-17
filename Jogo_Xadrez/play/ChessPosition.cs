using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogo_Xadrez.play
{
    internal class ChessPosition
    {

        public char Coluna { get; set; }
        public int Linha { get; set; }

        public ChessPosition(char coluna, int linha)
        {
            Coluna = coluna;

            Linha = linha;
        }

        public override string ToString()
        {
            return "" + Coluna + Linha;
        }
    }
}
