using System.Collections.Generic;

namespace BattleshipGame.Models
{
    public class Ship
    {
        public int Size { get; set; }
        public List<Position> Positions { get; set; }
    }
}
