
namespace Jogo_Xadrez.board
{
    internal class ChessPieces
    {

        public Position Position { get; set; } //pode ser acessada por todas as classes.
        public Color Cor { get; protected set; }//pode ser acessada por ela e por suas subclasses.
        public int QuantidadeMovimentos { get; protected set; }//pode ser acessada por ela e por suas subclasses.
        public Board Tab { get; protected set; }

        public ChessPieces(Board tab, Color cor ) 
        {
            Position = null;
            Tab = tab;
            Cor = cor;
            QuantidadeMovimentos = 0;

        }
    }
}
