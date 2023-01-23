using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Jogo_Xadrez.board;
using Jogo_Xadrez.conta;
using Newtonsoft.Json;
using System.IO;


namespace Jogo_Xadrez.play
{
    internal class Match 
    {
        //mecânica do jogo 

        public Board Tab { get; private set; }

        public int Play { get; private set; }

        public Color JogadorAtual { get; private set; }

        public  static string Vez { get; private set; }

        public bool TheEnd { get; private set; }

        private HashSet<ChessPieces> Pecas;

        private HashSet<ChessPieces> PecasCapturadas;

        public bool Xeque { get; private set; }

        public static string Jogador1;   

        public static string Jogador2;

        public Match()
        {
            Tab = new Board(8,8);

            Play = 1;

            JogadorAtual = Color.Branca; // QUEM INICIA JOGANDO É SEMPRE QUEM ESTÁ COM AS PEÇAS BRANCAS.

            Vez = Jogador1;

            Jogador2 = "";

            TheEnd = false;

            Xeque = false;

            Pecas = new HashSet<ChessPieces>();

            PecasCapturadas = new HashSet<ChessPieces>();

            InsertPieces();


        }

        public static void StartPlay(List<Contas> Jogadores)
        {
            try
            {
                Board Tab = new Board(8, 8);

                Match partida = new Match();


                while (!partida.TheEnd)
                {
                    try
                    {
                        Console.Clear();


                        Print.PrintMatch(partida);


                        Console.WriteLine();

                        Console.Write("Digite a posição de origem: ");
                

                        Position origem = Print.ReadPosition().ToPosition();

                        partida.ValidarPosicaoOrigem(origem);

                        //a partir da posição de origem eu pego todos os movimentos possívei e guardo dentro desta matriz.
                        bool[,] posicoesPossiveis = partida.Tab.Peca(origem).MovimentosPossiveis();

                        Console.Clear();

                        Print.PrintBoard(partida.Tab, posicoesPossiveis);


                        Console.Write("Digite a posição de Destino: ");

                        Position destino = Print.ReadPosition().ToPosition();

                        partida.ValidarPosicaoDestino(origem, destino);


                        partida.ExecutarJogada(origem, destino);


                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);

                        Console.ReadLine();

                    }





                }

                Console.Clear();

                Print.PrintMatch(partida);


            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }

     

            Console.ReadLine();
        }


        //Tab.RemovePiece(destino) se tiver alguma peça será retirada.

        //se eu capturar alguma peça eu armazeno esta peça na minha coleção de Peças capturadas.
        public ChessPieces ExecutarMovimento(Position origem, Position destino)
        {
            ChessPieces p = Tab.RemovePiece(origem);

            p.IncrementarMovimentos();

            ChessPieces pecaCapturada = Tab.RemovePiece(destino);

            Tab.InsertPiece(p, destino);

            if (pecaCapturada != null)
            {
                PecasCapturadas.Add(pecaCapturada);
            }

            return pecaCapturada;
        }


        // Esse método desfaz a ultima jogada quando o jogador atual em seu ultimo movimento pode se colocar em Xeque.
        public void UndoMove(Position origem, Position destino, ChessPieces pecaCapturada)
        {

            ChessPieces p = Tab.RemovePiece(destino);

            p.DecrementarMovimentos();

           
            // Se foi capturada alguma peça eu insiro ela novamente na posição de destino e removo ela da minha coleção de peças Capturadas.
            if(pecaCapturada != null)
            {
                Tab.InsertPiece(pecaCapturada, destino);

                PecasCapturadas.Remove(pecaCapturada);
            }

            Tab.InsertPiece(p, origem);

        }



        public void ExecutarJogada(Position origem, Position destino)
        {
            ChessPieces pecaCapturada = ExecutarMovimento(origem, destino);

            if (InXeque(JogadorAtual))
            {

                UndoMove(origem, destino, pecaCapturada);

                throw new BoardException("Você não pode se colocar em Xeque!");
            }

            ChessPieces p = Tab.Peca(destino);

            if (InXeque(adversary(JogadorAtual)))
            {
                Xeque = true;
            }
            else
            {
                Xeque= false;
            }

            if (TestXequeMate(adversary(JogadorAtual))){

                TheEnd = true;

            }
            else
            {
                Play++;

                TrocaVez();

            }

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
            if (!Tab.Peca(origem).MovimentoPossivel(destino)) 
            {

                throw new BoardException("Posição de destino inválida");

            }


        }

        

        private void TrocaVez()
        {
            if(JogadorAtual == Color.Branca)
            {
                JogadorAtual = Color.Preta;

                Vez = Jogador2;

            }
            else
            {
                JogadorAtual = Color.Branca;

                Vez = Jogador1;
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

        //identifica a cor adversária para que eu possa criar uma matriz de movimentos possíveis e a partir desta matriz eu consigo retirar a informação para a lógica de Xeque.
        private Color adversary(Color cor)
        {
            if(cor == Color.Branca)
            {
                return Color.Preta;
            }
            else
            {
                return Color.Branca;
            }
        }

        //vai passar por minha coleção de peças em jogo e buscar o Rei de uma determinada cor.
        private ChessPieces Rei(Color cor)
        {
            foreach(ChessPieces x in PartsInPlay(cor))
            {
                if (x is Rei)
                {
                    return x;
                }
            }
            return null;
        }

        // Este método percorre uma matriz de possíveis movimentos das peças na cor adversária e verifica se o meu rei pode ser atingido. 
        public bool InXeque(Color cor)
        {
            ChessPieces R = Rei(cor);

            foreach(ChessPieces x in PartsInPlay(adversary(cor)))
            {
                bool[,] mat = x.MovimentosPossiveis();

                if (mat[R.Position.Linha, R.Position.Coluna])
                {
                    return true;
                }
            }

            return false;
        }

        //Esse método vai passar na matriz de possíveis movimentos para verificar se é possível sair do Xeque.
        public bool TestXequeMate(Color cor)
        {
            if (!InXeque(cor))
            {
                return false;
            }
            foreach(ChessPieces x in PartsInPlay(cor))
            {
                bool[,] mat = x.MovimentosPossiveis();

                for(int i = 0; i < Tab.Linhas; i++)
                {
                    for(int j = 0; j < Tab.Colunas; j++)
                    {
                        // Se existir algum movimento possível eu vou movimentar a peça e verificar mais uma vez se o jogador saiu do Xeque. 
                        if (mat[i, j])
                        {
                            Position origem = x.Position;

                            Position destino = new Position(i, j);

                            ChessPieces pecaCapturada = ExecutarMovimento(origem, destino);

                            bool testeXeque = InXeque(cor);

                            UndoMove(origem, destino, pecaCapturada);
                            
                            // caso o movimento tenha retirado o jogador de Xeque retornamos falso.
                            if (!testeXeque)
                            {
                                return false;
                            }


                        }

                    }
                }
            }
            // infelizmente é XequeMate.
            return true;
        }

        public void AtribuirResultado(List<Contas>Jogadores, string filePath)
        {
           

            if (JogadorAtual == Color.Branca)
            {
                Contas shearch = Jogadores.Find(x => x.Nome == Vez);

                shearch.Pontos++;

                string json = JsonConvert.SerializeObject(shearch);

                File.WriteAllText(filePath, json);


            }
            else
            {
                Contas shearch = Jogadores.Find(x => x.Nome == Vez);

                shearch.Pontos++;

                string json = JsonConvert.SerializeObject(shearch);

                File.WriteAllText(filePath, json);
            }

            
          

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
            InsertNewPiece('c', 1, new Torre(Tab, Color.Branca, this));
            //InsertNewPiece('b', 1, new Cavalo(Tab, Color.Branca, this));
            //InsertNewPiece('c', 1, new Bispo(Tab, Color.Branca, this));
            //InsertNewPiece('d', 1, new Dama(Tab, Color.Branca, this));
            InsertNewPiece('d', 1, new Rei(Tab, Color.Branca, this));
            //InsertNewPiece('f', 1, new Bispo(Tab, Color.Branca, this));
            //InsertNewPiece('g', 1, new Cavalo(Tab, Color.Branca, this));
            InsertNewPiece('h', 7, new Torre(Tab, Color.Branca, this));
            //InsertNewPiece('a', 2, new Peao(Tab, Color.Branca, this));
            //InsertNewPiece('b', 2, new Peao(Tab, Color.Branca, this));
            //InsertNewPiece('c', 2, new Peao(Tab, Color.Branca, this));
            //InsertNewPiece('d', 2, new Peao(Tab, Color.Branca, this));
            //InsertNewPiece('e', 2, new Peao(Tab, Color.Branca, this));
            //InsertNewPiece('f', 2, new Peao(Tab, Color.Branca, this));
            //InsertNewPiece('g', 2, new Peao(Tab, Color.Branca, this));
            //InsertNewPiece('h', 2, new Peao(Tab, Color.Branca, this));


            InsertNewPiece('b', 8, new Torre(Tab, Color.Preta, this));
            //InsertNewPiece('b', 8, new Cavalo(Tab, Color.Preta, this));
            //InsertNewPiece('c', 8, new Bispo(Tab, Color.Preta, this));
            //InsertNewPiece('d', 8, new Dama(Tab, Color.Preta, this));
            InsertNewPiece('a', 8, new Rei(Tab, Color.Preta, this));
            //InsertNewPiece('f', 8, new Bispo(Tab, Color.Preta, this));
            //InsertNewPiece('g', 8, new Cavalo(Tab, Color.Preta, this));
            //InsertNewPiece('h', 8, new Torre(Tab, Color.Preta, this));
            //InsertNewPiece('a', 7, new Peao(Tab, Color.Preta, this));
            //InsertNewPiece('b', 7, new Peao(Tab, Color.Preta, this));
            //InsertNewPiece('c', 7, new Peao(Tab, Color.Preta, this));
            //InsertNewPiece('d', 7, new Peao(Tab, Color.Preta, this));
            //InsertNewPiece('e', 7, new Peao(Tab, Color.Preta, this));
            //InsertNewPiece('f', 7, new Peao(Tab, Color.Preta, this));
            //InsertNewPiece('g', 7, new Peao(Tab, Color.Preta, this));
            //InsertNewPiece('h', 7, new Peao(Tab, Color.Preta, this));





        }
    }
}
