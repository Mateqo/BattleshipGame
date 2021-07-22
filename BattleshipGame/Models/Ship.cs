using System.Collections.Generic;

namespace BattleshipGame.Models
{
    public class Ship
    {
        public int Size { get; set; }
        public bool isHorizontal { get; set; }
        public bool isDestroyed { get; set; }
        public List<PositionShip> Positions { get; set; } 
    }
}
