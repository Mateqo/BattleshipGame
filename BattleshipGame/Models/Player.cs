using System.Collections.Generic;

namespace BattleshipGame.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public int? LastHitNoDestroyedPositionH { get; set; }
        public int? LastHitNoDestroyedPositionV { get; set; }
        public bool IsSecondShoot { get; set; } // w trzecim strzale 2 możliwe kierunki
        public bool IsHorizontalInThirdShoot { get; set; } // kierunek w trzecim strzale (mamy pewność pionowo statek lub poziomo)
        public char[,] Board { get; set; }
        public List<Ship> Ships { get; set; }
        public List<Position> Shoots { get; set; }

        public Player()
        {
            Board = new char[Configuration.VerticalSize, Configuration.HorizontalSize];
            Ships = new List<Ship>();
            Shoots = new List<Position>();


            for (int i = 0; i < Configuration.VerticalSize; i++)
                for (int j = 0; j < Configuration.HorizontalSize; j++)
                    Board[i, j] = '-';
        }
    }
}
