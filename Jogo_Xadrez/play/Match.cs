using System.Collections.Generic;
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

        private HashSet<ChessPieces> Pecas;

        private HashSet<ChessPieces> PecasCapturadas;


        public Match()
        {
            Tab = new Board(8,8);

            Play = 1;

            JogadorAtual = Color.Branca; // QUEM INICIA JOGANDO É SEMPRE QUEM ESTÁ COM AS PEÇAS BRANCAS.

            TheEnd = false;

            Pecas = new HashSet<ChessPieces>();

            PecasCapturadas = new HashSet<ChessPieces>();

            InsertPieces();

        }

        

        public void ExecutarMovimento(Position origem, Position destino)
        {
            ChessPieces p = Tab.RemovePiece(origem);

            //p.IncrementarMovimentos();

            ChessPieces pecaCapturada = Tab.RemovePiece(destino);

            Tab.InsertPiece(p, destino);

            Tab.RemovePiece(destino);// se tiver alguma peça será retirada.

            //se eu capturar alguma peça eu armazeno esta peça na minha coleção de Peças capturadas.

            if (pecaCapturada != null)
            {
                PecasCapturadas.Add(pecaCapturada);
            }
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


        //Retorna todas as peças capturadas somente na cor informada.
        public HashSet<ChessPieces> CapturedPieces(Color cor)
        {
            HashSet<ChessPieces> aux = new HashSet<ChessPieces>();

            foreach(ChessPieces x in PecasCapturadas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }


        public HashSet<ChessPieces> PartsInPlay(Color cor)
        {
            HashSet<ChessPieces> aux = new HashSet<ChessPieces>();
            foreach (ChessPieces x in Pecas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            //retira todas as peças capturadas desta mesma cor, exceto aquelas que já foram capturadas. Desta forma eu tenho o valor das peças que ainda estão no jogo.
            aux.ExceptWith(CapturedPieces(cor));

            return aux;
        }

        //Dada uma coluna e linha de xadrez eu vou no tabuleiro da partida, coloco a peça e adiciono esta peça na minha coleção de peças. Quer dizer que esta peça faz parte da minha partida.
        public void InsertNewPiece(char coluna, int linha, ChessPieces peca)
        {

            Tab.InsertPiece(peca, new ChessPosition(coluna, linha).ToPosition());

            Pecas.Add(peca);

        }


        //cria a peça e armazena na coleção.
        private void InsertPieces()
        {
            InsertNewPiece('c', 1, new Torre(Tab, Color.Branca));
            InsertNewPiece('c', 2, new Torre(Tab, Color.Branca));
            InsertNewPiece('d', 1, new Rei(Tab, Color.Branca));
            InsertNewPiece('d', 2, new Torre(Tab, Color.Branca));
            InsertNewPiece('e', 1, new Torre(Tab, Color.Branca));
            InsertNewPiece('e', 2, new Torre(Tab, Color.Branca));



            InsertNewPiece('c', 7, new Torre(Tab, Color.Preta));
            InsertNewPiece('c', 8, new Torre(Tab, Color.Preta));
            InsertNewPiece('d', 7, new Torre(Tab, Color.Preta));
            InsertNewPiece('d', 8, new Torre(Tab, Color.Preta));
            InsertNewPiece('e', 7, new Torre(Tab, Color.Preta));
            InsertNewPiece('e', 8, new Torre(Tab, Color.Preta));

  

        }
    }
}
