using System;
using Jogo_Xadrez.board;


namespace Jogo_Xadrez.play
{
    internal class Match
    {
        //mecânica do jogo 

        public Board Tab { get; private set; }
        public int Play { get; private set; }
        public Color JogadorAtual { get; private set; }
        public bool TheEnd { get; private set; }


        public Match()
        {
            Tab = new Board(8,8);
            Play = 1;
            JogadorAtual = Color.Branca; // QUEM INICIA JOGANDO É SEMPRE QUEM ESTÁ COM AS PEÇAS BRANCAS.
            InsertPieces();
            TheEnd = false;
        }

        

        public void ExecutarMovimento(Position origem, Position destino)
        {
            ChessPieces p = Tab.RemovePiece(origem);

            p.IncrementarMovimentos();

            Tab.RemovePiece(destino);// se tiver alguma peça será retirada.

            ChessPieces pecaCapturada = Tab.RemovePiece(destino); 

            Tab.InsertPiece(p, destino);
        }

        public void ExecutarJogada(Position origem, Position destino)
        {
            ExecutarMovimento(origem, destino);
            Play++;
            TrocaVez();
        }

        public void ValidarPosicaoOrigem(Position pos)
        {  
            
            //valida se a posição escolhida pelo usuário possui alguma peça para movimentar.
            if(Tab.Peca(pos) == null)
            {
                throw new BoardException("Não existe peça na posição escolhida");
            }



            //valida se a peça de origem possui a mesma cor do jogador atual.
            if(JogadorAtual != Tab.Peca(pos).Cor)
            {
                throw new BoardException("A peça de origem escolhida não pertence ao jogador atual.");
            }


            //valida se existe movimentos disponíveis.
            if (!Tab.Peca(pos).ExisteMovimentosPossiveis())
            {
                throw new BoardException("Não há movimentos possíveis para a peça de origem escolhida");
            }
        }


        public void ValidarPosicaoDestino(Position origem, Position destino)
        {
            if (!Tab.Peca(origem).PodeMover(destino))
            {

                throw new BoardException("Posição de destino inválida");

            }


        }

        private void TrocaVez()
        {
            if(JogadorAtual == Color.Branca)
            {
                JogadorAtual = Color.Preta;
            }
            else
            {
                JogadorAtual = Color.Branca;
            }
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
            Tab.InsertPiece(new Rei(Tab, Color.Branca), new ChessPosition('d', 1).ToPosition());
            Tab.InsertPiece(new Torre(Tab, Color.Branca), new ChessPosition('d', 2).ToPosition());
            Tab.InsertPiece(new Torre(Tab, Color.Branca), new ChessPosition('e', 1).ToPosition());
            Tab.InsertPiece(new Torre(Tab, Color.Branca), new ChessPosition('e', 2).ToPosition());

        }
    }
}
