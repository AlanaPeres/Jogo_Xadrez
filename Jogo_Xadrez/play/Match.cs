using System;
using Jogo_Xadrez.board;


namespace Jogo_Xadrez.play
{
    internal class Match
    {
        //mecânica do jogo 

        public Board Tab { get; private set; }
        private int Play;
        private Color JogadorAtual;


        public Match()
        {
            Tab = new Board(8,8);
            Play = 1;
            JogadorAtual = Color.Branca; // QUEM INICIA JOGANDO É SEMPRE QUEM ESTÁ COM AS PEÇAS BRANCAS.
            InsertPieces();
        }

        

        public void ExecutarMovimento(Position origem, Position destino)
        {
            ChessPieces p = Tab.RemovePiece(origem);

            p.IncrementarMovimentos();

            Tab.RemovePiece(destino);// se tiver alguma peça será retirada.

            ChessPieces pecaCapturada = Tab.RemovePiece(destino); 

            Tab.InsertPiece(p, destino);
        }

        private void InsertPieces()
        {

            Tab.InsertPiece(new Torre(Tab, Color.Preta), new ChessPosition('c', 7).ToPosition());
            Tab.InsertPiece(new Torre(Tab, Color.Preta), new ChessPosition('c', 8).ToPosition());
            Tab.InsertPiece(new Torre(Tab, Color.Preta), new ChessPosition('d', 7).ToPosition());
            Tab.InsertPiece(new Torre(Tab, Color.Preta), new ChessPosition('d', 8).ToPosition());
            Tab.InsertPiece(new Torre(Tab, Color.Preta), new ChessPosition('e', 7).ToPosition());
            Tab.InsertPiece(new Torre(Tab, Color.Preta), new ChessPosition('e', 8).ToPosition());

            Tab.InsertPiece(new Torre(Tab, Color.Branca), new ChessPosition('c', 1).ToPosition());
            Tab.InsertPiece(new Torre(Tab, Color.Branca), new ChessPosition('c', 2).ToPosition());
            Tab.InsertPiece(new Torre(Tab, Color.Branca), new ChessPosition('d', 1).ToPosition());
            Tab.InsertPiece(new Torre(Tab, Color.Branca), new ChessPosition('d', 2).ToPosition());
            Tab.InsertPiece(new Torre(Tab, Color.Branca), new ChessPosition('e', 1).ToPosition());
            Tab.InsertPiece(new Torre(Tab, Color.Branca), new ChessPosition('e', 2).ToPosition());

        }
    }
}
