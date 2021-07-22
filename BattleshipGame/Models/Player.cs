using System.Collections.Generic;

namespace BattleshipGame.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public int? LastHitNoDestroyedPositionH { get; set; }
        public int? LastHitNoDestroyedPositionV { get; set; }
        public bool IsSecondShoot { get; set; } // in third shoot 2 possible direction 
        public bool IsHorizontalInThirdShoot { get; set; } // possible direction in third shoot
        public char[,] Board { get; set; }
        public List<Ship> Ships { get; set; }
        public List<Position> Shoots { get; set; }

        public Player()
        {
            Board = new char[Configuration.HorizontalSize, Configuration.VerticalSize];
            Ships = new List<Ship>();

            for (int i = 0; i < Configuration.HorizontalSize; i++)
                for (int j = 0; j < Configuration.VerticalSize; j++)
                    Board[i, j] = '-';
        }
    }
}
