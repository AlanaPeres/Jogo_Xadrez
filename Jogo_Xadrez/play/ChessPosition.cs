using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jogo_Xadrez.board;

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
        // transforma as posições de entrada em posições da Matriz.
        public Position ToPosition()
        {
            return new Position(8 - Linha, Coluna - 'a'); 
        }
        public override string ToString() => "" + Coluna + Linha;
        
    }
}
