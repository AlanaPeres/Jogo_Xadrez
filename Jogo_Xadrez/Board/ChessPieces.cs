
namespace Jogo_Xadrez.board
{
    abstract class ChessPieces
    {

        public Position Position { get; set; } //pode ser acessada por todas as classes.
        public Color Cor { get; protected set; }//pode ser acessada por ela e por suas subclasses.
        public int QuantidadeMovimentos { get; protected set; }
        public Board Tab { get; protected set; }



        public ChessPieces(Board tab, Color cor ) 
        {
            Position = null;
            Tab = tab;
            Cor = cor;
            QuantidadeMovimentos = 0;

        }

       

        public void IncrementarMovimentos()
        {
            QuantidadeMovimentos++;
        }

        public void DecrementarMovimentos()
        {
            QuantidadeMovimentos--;
        }

        //Percorre a matriz e verifica se existe uma posição válida disponível para movimentar.
        public bool ExisteMovimentosPossiveis()
        {
            bool[,] mat = MovimentosPossiveis();
            for (int i = 0; i < Tab.Linhas; i++)
            {
                for(int j = 0; j < Tab.Colunas; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        //testa os movimentos possiveis na matriz e verifica se é true.
        public bool MovimentoPossivel(Position pos)
        {
            return MovimentosPossiveis()[pos.Linha, pos.Coluna];
        }


        //matriz de valores bool pois eu quero saber quais os movimentos minhas peças podem fazer ou não no tabuleiro. Quando o movimento for possível o valor retornado é true.
        // como a classe ChessPiece representa todas as peças e cada movimento no xadrez é especifico eu crio essa classe abstrata para tratar ao mesmo tempo todas as peças do tabuleiro.
        public abstract bool[,] MovimentosPossiveis();
    }
}
